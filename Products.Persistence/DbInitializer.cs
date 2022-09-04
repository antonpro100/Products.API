namespace Products.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(ProductsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
