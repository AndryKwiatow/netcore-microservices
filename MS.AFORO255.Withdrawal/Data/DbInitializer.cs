using MS.AFORO255.Withdrawal.Repositories;

namespace MS.AFORO255.Withdrawal.Data
{
    public class DbInitializer
    {
        public static void Initialize(ContextDatabase context)
        {
            context.Database.EnsureCreated();
            context.SaveChanges();
        }
    }
}
