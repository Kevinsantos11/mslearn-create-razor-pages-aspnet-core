using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;


namespace ContosoPizza.Pages
{
    public class pizzalistmodel : PageModel
    {
        private readonly PizzaService _Service;
        public IList<Pizza> pizzalist { get; set; } = default!;

        public pizzalistmodel(PizzaService service)
        {
            _Service = service;
        }
        public void OnGet()
        {
            pizzalist = _Service.GetPizzas();
        }
    }
}
