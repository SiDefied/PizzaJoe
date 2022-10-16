using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaJoe.DataModel;
using PizzaJoe.Entities;

namespace PizzaJoe.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<PizzaProduct> pizzaProducts;

        public void OnGet()
        {
            PizzaModel pizzaModel = new PizzaModel();
            pizzaProducts = pizzaModel.findAll();

        }
    }
}