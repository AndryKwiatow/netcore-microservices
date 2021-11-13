using MS.AFORO255.Account.Repositories;
using System.Linq;

namespace MS.AFORO255.Account.Data
{
    public class DbInitializer
    {
        public static void Initialize(ContextDatabase context)
        {
            context.Database.EnsureCreated();


            if (context.Customer.Any())
            {
                return;   // DB has been seeded
            }

            var customers = new Models.Customer[]
            {
                new Models.Customer{IdCustomer=1,FullName="Ivan Cuadros",Email="icuadros@aforo255.com"},
                new Models.Customer{IdCustomer=2,FullName="Leonel Messis",Email="lmessi@aforo255.com"},
                new Models.Customer{IdCustomer=3,FullName="Paolo Guerrero",Email="pguerrero@aforo255.com"},
                new Models.Customer{IdCustomer=4,FullName="Andrea Pirlo",Email="apirlo@aforo255.com"}
            };

            foreach (Models.Customer s in customers)
            {
                context.Customer.Add(s);
            }


            if (context.Account.Any())
            {
                return;   // DB has been seeded
            }

            var accounts = new Models.Account[]
            {
                new Models.Account{IdAccount=1,TotalAmount=1000,IdCustomer=1},
                new Models.Account{IdAccount=2,TotalAmount=5000,IdCustomer=2},
                new Models.Account{IdAccount=3,TotalAmount=2000,IdCustomer=4},
                new Models.Account{IdAccount=4,TotalAmount=3000,IdCustomer=1},
                new Models.Account{IdAccount=5,TotalAmount=6000,IdCustomer=3},
                 new Models.Account{IdAccount=6,TotalAmount=500,IdCustomer=3},
                new Models.Account{IdAccount=7,TotalAmount=800,IdCustomer=1},
                new Models.Account{IdAccount=8,TotalAmount=100,IdCustomer=4},
                new Models.Account{IdAccount=9,TotalAmount=20,IdCustomer=2},
                new Models.Account{IdAccount=10,TotalAmount=1000,IdCustomer=3}
            };

            foreach (Models.Account s in accounts)
            {
                context.Account.Add(s);
            }



            context.SaveChanges();
        }
    }
}
