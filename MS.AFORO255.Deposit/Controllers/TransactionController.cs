using Aforo255.Cross.Event.Src.Bus;
using Microsoft.AspNetCore.Mvc;
using MS.AFORO255.Deposit.DTOs;
using MS.AFORO255.Deposit.Messages.Commands;
using MS.AFORO255.Deposit.Services;
using System;

namespace MS.AFORO255.Deposit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IEventBus _bus;
        private readonly IAccountService _accountService;

        public TransactionController(ITransactionService transactionService, IEventBus bus, IAccountService accountService)
        {
            _transactionService = transactionService;
            _bus = bus;
            _accountService = accountService;
        }

        [HttpPost("Deposit")]
        public IActionResult Deposit([FromBody] TransactionRequest request)
        {
            Models.Transaction transaction = new Models.Transaction()
            {
                AccountId = request.AccountId,
                Amount = request.Amount,
                CreationDate = DateTime.Now.ToShortDateString(),
                Type = "Deposit"
            };
            transaction = _transactionService.Deposit(transaction);

            bool isProccess = _accountService.Execute(transaction);
            if (isProccess)
            {
                var transactionCreateCommand = new TransactionCreateCommand(
                   idTransaction: transaction.Id,
                   amount: transaction.Amount,
                   type: transaction.Type,
                   creationDate: transaction.CreationDate,
                   accountId: transaction.AccountId
                );
                _bus.SendCommand(transactionCreateCommand);

                var notificationCreateCommand = new NotificationCreateCommand(
                               idTransaction: transaction.Id,
                               amount: transaction.Amount,
                               type: transaction.Type,
                               messageBody: $"Se proceso el {transaction.Type} con el monto de {transaction.Amount} de su cuenta {transaction.AccountId}",
                               address: "test@aforo255.com",
                               accountId: transaction.AccountId
                            );
                _bus.SendCommand(notificationCreateCommand);
            }

            return Ok(transaction);
        }
    }
}
