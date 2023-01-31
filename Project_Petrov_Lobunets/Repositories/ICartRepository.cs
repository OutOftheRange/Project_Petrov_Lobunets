using Project_Petrov_Lobunets.Models.ShoppingCart.Models;

namespace Project_Petrov_Lobunets.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {

        void Update(Cart cart);
    }
}