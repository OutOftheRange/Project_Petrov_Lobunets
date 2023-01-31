using Project_Petrov_Lobunets.Models.ShoppingCart.Models;

namespace Project_Petrov_Lobunets.Areas.Identity.ViewModels
{
    public class CategoryVM
    {
        public Category Category { get; set; } = new Category();

        public IEnumerable<Category> categories { get; set; } = new List<Category>();
    }
}
