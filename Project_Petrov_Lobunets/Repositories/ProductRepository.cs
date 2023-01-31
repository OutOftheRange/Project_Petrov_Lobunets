using Project_Petrov_Lobunets.Areas.Identity.Data;
using Project_Petrov_Lobunets.Models.ShoppingCart.Models;
using System.Linq.Expressions;

namespace Project_Petrov_Lobunets.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Product product)
        {
            var productDB = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if (productDB != null)
            {
                productDB.Name = product.Name;
                productDB.Description = product.Description;
                productDB.Price = product.Price;
                if (product.ImageUrl != null)
                {
                    productDB.ImageUrl = product.ImageUrl;
                }
            }
        }
    }
}
