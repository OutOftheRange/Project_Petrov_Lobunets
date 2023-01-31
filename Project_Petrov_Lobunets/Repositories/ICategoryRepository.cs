using Project_Petrov_Lobunets.Models.ShoppingCart.Models;

namespace Project_Petrov_Lobunets.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}