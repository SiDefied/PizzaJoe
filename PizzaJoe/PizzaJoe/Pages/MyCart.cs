using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaJoe.Entities;
using PizzaJoe;
using PizzaJoe.DataModel;
using System.Linq;
using System.Collections.Generic;

namespace PizzaJoe.Pages
{
    public class CartModel : PageModel
    {
        private readonly ILogger<CartModel> _logger;

        public CartModel(ILogger<CartModel> logger)
        {
            _logger = logger;
        }

        public List<CartItem> cart { get; set; }
        public double Total { get; set; }

        public void OnGet()
        {
            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            Total = cart.Sum(i => i.Product.Price * i.Quantity);
        }

        public IActionResult OnGetBuyNow(string id)
        {
            var productModel = new PizzaModel();
            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
                cart.Add(new CartItem
                {
                    Product = productModel.find(id),
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                int index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(new CartItem
                    {
                        Product = productModel.find(id),
                        Quantity = 1
                    });
                }
                else
                {
                    cart[index].Quantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToPage("Cart");
        }

        public IActionResult OnGetDelete(string id)
        {
            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("Cart");
        }

        public IActionResult OnPostUpdate(int[] quantities)
        {
            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            for (var i = 0; i < cart.Count; i++)
            {
                cart[i].Quantity = quantities[i];
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("Cart");
        }

        private int Exists(List<CartItem> cart, string id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}