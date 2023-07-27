using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;


namespace ContosoPizza.Pages
{
    public class pizzalistmodel : PageModel
    {
        [BindProperty]
        public Pizza NewPizza { get; set; } = default!;
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

        public IActionResult Onpost()
        {
            if(!ModelState.IsValid ||  NewPizza == null)
            {
                return Page();
            }
            _Service.AddPizza(NewPizza);
            return RedirectToAction("Get");
        }
        public IActionResult OnPostDelete(int id)
        {
            _Service.DeletePizza(id);

            return RedirectToAction("get");

        }

    }
}
