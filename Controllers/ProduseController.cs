using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlowerShop.Models;
using FlowerShop.Services;
using Microsoft.AspNetCore.Authorization;

namespace FlowerShop.Controllers
{
    [Authorize]
    public class ProduseController : Controller
    {
        private readonly ProdusService _produsService;
        private readonly GalerieService _galerieService;

        public ProduseController(ProdusService produsService, GalerieService galerieService)
        {
            _produsService = produsService;
            _galerieService = galerieService;
        }

        public IActionResult Index()
        {
            var produs = _produsService.GetProdus();
            return View(produs);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produs = _produsService.GetProdus().FirstOrDefault(m => m.ProdusID == id);
            if (produs == null)
            {
                return NotFound();
            }

            return View(produs);
        }

        public IActionResult Create()
        {
            ViewBag.GalerieId = new SelectList(_galerieService.GetGalerie(), "GalerieId", "Nume");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ProdusID, Nume, Pret, Stoc, GalerieId")] Produs produs)
        {
            if (ModelState.IsValid)
            {
                _produsService.AddProdus(produs);
                _produsService.Save();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.GalerieId = new SelectList(_galerieService.GetGalerie(), "GalerieId", "Nume", produs.GalerieId);
            return View(produs);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produs = _produsService.GetProdus().FirstOrDefault(m => m.ProdusID == id);
            if (produs == null)
            {
                return NotFound();
            }

            ViewBag.GalerieId = new SelectList(_galerieService.GetGalerie(), "GalerieId", "Nume", produs.GalerieId);
            return View(produs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ProdusID, Nume, Pret, Stoc, GalerieId")] Produs produs)
        {
            if (id != produs.ProdusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _produsService.UpdateProdus(produs);
                    _produsService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdusExists(produs.ProdusID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.GalerieId = new SelectList(_galerieService.GetGalerie(), "GalerieId", "Nume", produs.GalerieId);
            return View(produs);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produs = _produsService.GetProdus().FirstOrDefault(m => m.ProdusID == id);
            if (produs == null)
            {
                return NotFound();
            }

            return View(produs);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var produs = _produsService.GetProdusByCondition(b => b.ProdusID == id).FirstOrDefault();
            _produsService.DeleteProdus(produs);
            _produsService.Save();
            return RedirectToAction(nameof(Index));
        }
        private bool ProdusExists(int id)
        {
            return _produsService.GetProdus().Any(e => e.ProdusID == id);
        }

    }
}
