using Microsoft.AspNetCore.Mvc;
using RestoranJelaRPA.Models;

namespace RestoranJelaRPA.Controllers
{
    public class ReceptiAPIcontroller : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;
        public ReceptiAPIcontroller(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
