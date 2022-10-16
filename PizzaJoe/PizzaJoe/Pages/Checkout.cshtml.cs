using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaJoe.Entities;
using PizzaJoe;
using PizzaJoe.DataModel;

namespace PizzaPortal.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly ILogger<CheckoutModel> _logger;

        public CheckoutModel(ILogger<CheckoutModel> logger)
        {
            _logger = logger;
        }
        //public double checkout { get; set; }

        //public double Total { get; set; }


        public List<CartItem> cart { get; set; }
        public double Total { get; set; }

        //(HttpContext.Session, "Checkout");
        public void OnGet()
        {
            //checkout = SessionHelper.GetObjectFromJson<double>(HttpContext.Session, "checkout");

            //Total = checkout.Sum(i => i.Product.Price * i.Quantity);
            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            Total = cart.Sum(i => i.Product.Price * i.Quantity);

        }
    }
}
