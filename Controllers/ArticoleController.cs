using System;
using System.Collections.Generic;
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
    [Authorize(Roles ="User")]
    public class ArticoleController : Controller
    {
        private readonly ArticolService _articolService;

        public ArticoleController(ArticolService articolService)
        {
            _articolService = articolService;
        }

        public IActionResult Index()
        {
            var articol = _articolService.GetArticol();
            return View(articol);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articol = _articolService.GetArticol().FirstOrDefault(m => m.ArticolID == id);
            if (articol == null)
            {
                return NotFound();
            }

            return View(articol);
        }
        // GET: Articole/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articole/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ArticolID,Titlu,Continut")] Articol articol)
        {
            if (ModelState.IsValid)
            {
                _articolService.AddArticol(articol);
                _articolService.Save();
                return RedirectToAction(nameof(Create));
            }
            return View(articol);
        }

        // GET: Articole/Edit/5
 
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articol = _articolService.GetArticol().FirstOrDefault(m => m.ArticolID == id);
            if (articol == null)
            {
                return NotFound();
            }
            return View(articol);
        }

        // POST: Articole/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ArticolID,Titlu,Continut")] Articol articol)
        {
            if (id != articol.ArticolID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _articolService.UpdateArticol(articol);
                    _articolService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticolExists(articol.ArticolID))
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
            return View(articol);
        }

        [Authorize(Roles ="Administrator")]
        // GET: Articole/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articol = _articolService.GetArticol().FirstOrDefault(m => m.ArticolID == id);
            if (articol == null)
            {
                return NotFound();
            }

            return View(articol);
        }

        // POST: Articole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var articol = _articolService.GetArticolByCondition(b => b.ArticolID == id).FirstOrDefault();
            _articolService.DeleteArticol(articol);
            _articolService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticolExists(int id)
        {
            return _articolService.GetArticol().Any(e => e.ArticolID == id);
        }
    }
}
