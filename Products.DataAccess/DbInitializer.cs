namespace Products.DataAccess
{
    public class DbInitializer
    {
        public static void Initialize(ProductsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
