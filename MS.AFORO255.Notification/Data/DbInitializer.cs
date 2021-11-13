using MS.AFORO255.Notification.Repositories;

namespace MS.AFORO255.Notification.Data
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
