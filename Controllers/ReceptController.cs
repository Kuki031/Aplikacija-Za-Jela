using Microsoft.AspNetCore.Mvc;
using RestoranJelaRPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace RestoranJelaRPA.Controllers
{
    public class ReceptController : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;

        public ReceptController(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_repozitorijUpita.PopisRecepata());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,NazivJela,Opis")] Recept recept)
        {
            if (ModelState.IsValid)
            {
                _repozitorijUpita.Create(recept);
                return RedirectToAction("Index");
            }

            return View(recept);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var recept = _repozitorijUpita.DohvatiReceptSIdom(Convert.ToInt32(id));
            if (recept == null)
            {
                return NotFound();
            }
            return View(recept);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id,NazivJela,Opis")] Recept recept)
        {
            if (id != recept.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Update(recept);
                return RedirectToAction("Index");
            }
            return View(recept);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var recept = _repozitorijUpita.DohvatiReceptSIdom(Convert.ToInt32(id));
            if (recept == null)
            {
                return NotFound();
            }
            return View(recept);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var recept = _repozitorijUpita.DohvatiReceptSIdom(Convert.ToInt32(id));
            _repozitorijUpita.Delete(recept);
            return RedirectToAction("Index");
        }
    }
}

