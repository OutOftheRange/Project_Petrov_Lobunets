using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Petrov_Lobunets.Models;
using Project_Petrov_Lobunets.Models.ShoppingCart.Models;
using Project_Petrov_Lobunets.Repositories;
using System.Diagnostics;
using System.Security.Claims;
namespace Project_Petrov_Lobunets.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitofwork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitofwork)
        {
            _logger = logger;
            _unitofwork = unitofwork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitofwork.Product.GetAll(includeProperties: "Category");

            return View(products);
        }

        [HttpGet]
        public IActionResult Details(int? productId)
        {
            Cart cart = new Cart()
            {
                Product = _unitofwork.Product.GetT(x => x.Id == productId, includeProperties: "Category"),
                Count = 1,
                ProductId = (int)productId
            };
            return View(cart);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]

        public IActionResult Details(Cart cart)
        {
            if(ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                cart.ApplicationUserId = claims.Value;

                var cartItem = _unitofwork.Cart.GetT(x => x.ProductId == cart.ProductId && x.ApplicationUserId == claims.Value);
                if (cartItem != null)
                {
                    _unitofwork.Cart.Add(cart);
                    _unitofwork.Save();
                    HttpContext.Session.SetInt32("SessionCart", _unitofwork.Cart.GetAll(x => x.ApplicationUserId == claims.Value).ToList().Count);
                }
                else
                {
                    _unitofwork.Save();
                }

            }
            return RedirectToAction("Index");   
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}