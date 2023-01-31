using Project_Petrov_Lobunets.Areas.Identity.Data;

namespace Project_Petrov_Lobunets.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public ICartRepository Cart { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(context);
            Product = new ProductRepository(context);
            Cart = new CartRepository(context);
        }

        public void Save() 
        { 
            _context.SaveChanges();
        }
    }
}
