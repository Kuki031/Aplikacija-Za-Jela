using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestoranJelaRPA.Models;

namespace RestoranJelaRPA.Controllers
{
    public class ProizvodController : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;
        public ProizvodController(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }

        public IActionResult Index()
        {
            return View(_repozitorijUpita.PopisProizvod());
        }
 
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv");
            int sljedeciId = _repozitorijUpita.SljedeciId();
            Proizvod proizvod = new Proizvod() { Id = sljedeciId };
            return View(proizvod);

         
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Naziv,Cijena,SlikaUrl,Sastojci,KategorijaId")] Proizvod proizvod)
        {
            ModelState.Remove("Kategorija"); // uklanjanje veze

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Create(proizvod);
                return RedirectToAction("Index");
            }
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", proizvod.KategorijaId);
            return View(proizvod);
        }






       
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvod = _repozitorijUpita.DohvatiProizvodSIdom(Convert.ToInt32(id));

            if (proizvod == null)
            {
                return NotFound();
            }
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", proizvod.KategorijaId);
            return View(proizvod);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id,Naziv,DatumIzlaska,Cijena,SlikaUrl,Sastojci,KategorijaId")] Proizvod proizvod)
        {
            if (id != proizvod.Id)
            {
                return NotFound();
            }
            ModelState.Remove("Kategorija");
            if (ModelState.IsValid)
            {
                _repozitorijUpita.Update(proizvod);
                return RedirectToAction("Index");
            }
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", proizvod.KategorijaId);
            return View(proizvod);
        }

       
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvod = _repozitorijUpita.DohvatiProizvodSIdom(Convert.ToInt32(id));
            if (proizvod == null)
            {
                return NotFound();
            }
            return View(proizvod);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var proizvod = _repozitorijUpita.DohvatiProizvodSIdom(id);
            _repozitorijUpita.Delete(proizvod);
            return RedirectToAction("Index");
        }

        
        public ActionResult SearchIndex(string tipJela, string searchString)
        {
            var tip = new List<string>();

            var tipUpit = _repozitorijUpita.PopisKategorija();

            ViewData["tipJela"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Naziv", "Naziv", tipUpit);

            var proizvodi = _repozitorijUpita.PopisProizvod();

            if (!String.IsNullOrWhiteSpace(searchString))
            {
                proizvodi = proizvodi.Where(s => s.Naziv.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            if (string.IsNullOrWhiteSpace(tipJela))
                return View(proizvodi);
            else
            {
                return View(proizvodi.Where(x => x.Kategorija.Naziv == tipJela));
            }












        }
    }
}

