using Project_Petrov_Lobunets.Areas.Identity.Data;
using System.Linq.Expressions;
using Project_Petrov_Lobunets.Models.ShoppingCart.Models;
    namespace Project_Petrov_Lobunets.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private ApplicationDbContext _context;
        public CartRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Cart cart)
        {
            var cartDB = _context.Carts.FirstOrDefault(x => x.Id == cart.Id);
            if (cartDB != null)
            {
                cartDB.Id = cart.Id;
                cartDB.ProductId = cart.ProductId;
                cartDB.ApplicationUserId = cart.ApplicationUserId;
                cartDB.ApplicationUser = cart.ApplicationUser;
                cartDB.Count = cart.Count;
               
            }

        }
        public void IncrementCartItem(Cart? cartItem, int count)
        {

        }
    }
}
