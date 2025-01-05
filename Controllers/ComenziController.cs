using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlowerShop.Models;
using FlowerShop.Services;

namespace FlowerShop.Controllers
{
    [Authorize(Roles="Administrator")]
    public class ComenziController : Controller
    {
        private readonly ComandaService _comandaService;
        private readonly ProdusService _produsService;

        public ComenziController(ComandaService comandaService, ProdusService produsService)
        {
            _comandaService = comandaService;
            _produsService = produsService;
        }

        public IActionResult Index()
        {
            var comenzi = _comandaService.GetComanda();
            return View(comenzi);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = _comandaService.GetComanda()
                                         .FirstOrDefault(m => m.ComandaId == id);

            if (comanda == null)
            {
                return NotFound();
            }

            return View(comanda);
        }

        // GET: Comanda/Create
        public IActionResult Create()
        {
            ViewData["ProdusID"] = new SelectList(_produsService.GetProdus(), "ProdusID", "Nume");
            return View();
        }

        // POST: Comanda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ComandaId,ProdusID,DataComanda, Cost")] Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                _comandaService.AddComanda(comanda);
                _comandaService.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdusID"] = new SelectList(_produsService.GetProdus(), "ProdusID", "Nume", comanda.ProdusId);
            return View(comanda);
        }

        // GET: Comanda/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = _comandaService.GetComanda().FirstOrDefault(m => m.ComandaId == id);
            if (comanda == null)
            {
                return NotFound();
            }
            ViewData["ProdusID"] = new SelectList(_produsService.GetProdus(), "ProdusID", "Nume", comanda.ProdusId);
            return View(comanda);
        }

        // POST: Comanda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ComandaId,ProdusID,DataComanda, Cost")] Comanda comanda)
        {
            if (id != comanda.ComandaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _comandaService.UpdateComanda(comanda);
                    _comandaService.Save();
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!ComandaExists(comanda.ComandaId))
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
            ViewData["ProdusID"] = new SelectList(_produsService.GetProdus(), "ProdusID", "ProdusID", comanda.ProdusId);
            return View(comanda);
        }

        // GET: Comenzi/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = _comandaService.GetComanda()
                .FirstOrDefault(m => m.ComandaId == id);
            if (comanda == null)
            {
                return NotFound();
            }

            return View(comanda);
        }

        // POST: Comenzi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var comanda = _comandaService.GetComandaByCondition(b => b.ComandaId == id).FirstOrDefault();
            _comandaService.DeleteComanda(comanda);
            _comandaService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool ComandaExists(int id)
        {
            return _comandaService.GetComanda().Any(e => e.ComandaId == id);
        }
    }
}
