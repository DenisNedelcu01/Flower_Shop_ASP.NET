using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlowerShop.Models;
using FlowerShop.Services;

namespace FlowerShop.Controllers
{
    [Authorize]
    public class GaleriiController : Controller
    {
        private readonly GalerieService _galerieService;

        public GaleriiController(GalerieService galerieService)
        {
            _galerieService = galerieService;
        }

        public IActionResult Index()
        {
            var galerie = _galerieService.GetGalerie();
            return View(galerie);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galerie = _galerieService.GetGalerie().FirstOrDefault(m => m.GalerieId == id);
            if (galerie == null)
            {
                return NotFound();
            }

            return View(galerie);
        }

        // GET: Galerie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Galerie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("GalerieId,Name,Link")] Galerie galerie)
        {
            if (ModelState.IsValid)
            {
                _galerieService.AddGalerie(galerie);
                _galerieService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(galerie);
        }

        // GET: Galerie/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galerie = _galerieService.GetGalerie().FirstOrDefault(m => m.GalerieId == id);

            if (galerie == null)
            {
                return NotFound();
            }
            return View(galerie);
        }

        // POST: Galerie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, [Bind("GalerieId,Nume,Link")] Galerie galerie)
        {
            if (id != galerie.GalerieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _galerieService.UpdateGalerie(galerie);
                    _galerieService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GalerieExists(galerie.GalerieId))
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
            return View(galerie);
        }

        // GET: Galerie/Delete/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galerie = _galerieService.GetGalerie().FirstOrDefault(m => m.GalerieId == id);
            if (galerie == null)
            {
                return NotFound();
            }

            return View(galerie);
        }

        // POST: Galerie/Delete/5
        [Authorize(Roles = "User")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            var galerie = _galerieService.GetGalerieByCondition(b => b.GalerieId == id).FirstOrDefault();
            _galerieService.DeleteGalerie(galerie);
            _galerieService.Save();
            return RedirectToAction(nameof(Index));

        }
        private bool GalerieExists(int id)
        {
            return _galerieService.GetGalerie().Any(e => e.GalerieId == id);
        }
    }
}
