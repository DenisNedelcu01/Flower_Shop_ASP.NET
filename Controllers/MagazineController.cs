using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlowerShop.Models;
using FlowerShop.Services;
using Microsoft.AspNetCore.Authorization;

namespace FlowerShop.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class MagazineController : Controller
    {
        private readonly MagazinService _magazinService;
        private readonly ProdusService _produsService;

        public MagazineController(MagazinService magazinService, ProdusService produsService)
        {
            _magazinService = magazinService;
            _produsService = produsService;
        }

        public IActionResult Index()
        {
            var magazin = _magazinService.GetMagazin();
            return View(magazin);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazin = _magazinService.GetMagazin().FirstOrDefault(m => m.MagazinId == id);
            if (magazin == null)
            {
                return NotFound();
            }

            return View(magazin);
        }

        // GET: Magazin/Create
        public IActionResult Create()
        {
            ViewData["ProdusID"] = new SelectList(_produsService.GetProdus(), "ProdusID", "Nume");
            return View();
        }

        // POST: Magazin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MagazinId,Adresa,Cantitate,ProdusID")] Magazin magazin)
        {
            if (ModelState.IsValid)
            {
                _magazinService.AddMagazin(magazin);
                _magazinService.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdusID"] = new SelectList(_produsService.GetProdus(), "ProdusID", "NumeProdus", magazin.ProdusId);
            return View(magazin);
        }

        // GET: Magazin/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazin = _magazinService.GetMagazin().FirstOrDefault(m => m.MagazinId == id);

            if (magazin == null)
            {
                return NotFound();
            }
            ViewData["ProdusID"] = new SelectList(_produsService.GetProdus(), "ProdusID", "NumeProdus");
            return View(magazin);
        }

        // POST: Magazin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, [Bind("MagazinId,Adresa,Cantitate,ProdusID")] Magazin magazin)
        {
            if (id != magazin.MagazinId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _magazinService.UpdateMagazin(magazin);
                    _magazinService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MagazinExists(magazin.MagazinId))
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
            ViewData["ProdusID"] = new SelectList(_produsService.GetProdus(), "ProdusID", "NumeProdus");
            return View(magazin);
        }

        // GET: Magazin/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazin = _magazinService.GetMagazin().FirstOrDefault(m => m.MagazinId == id);
            if (magazin == null)
            {
                return NotFound();
            }

            return View(magazin);
        }

        // POST: Magazin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var magazin = _magazinService.GetMagazinByCondition(b => b.MagazinId == id).FirstOrDefault();
            _magazinService.DeleteMagazin(magazin);
            _magazinService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool MagazinExists(int id)
        {
            return _magazinService.GetMagazin().Any(e => e.MagazinId == id);
        }
    }
}
