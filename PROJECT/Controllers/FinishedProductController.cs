using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT.Models;

namespace PROJECT.Controllers
{
    public class FinishedProductController : Controller 
    { 

    private readonly ApplicationDbContext _db;
    public FinishedProductController(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _db.FinishedProducts.ToListAsync());
    }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FinishedProduct finished)
        {
            if (ModelState.IsValid)
            {
                _db.FinishedProducts.Add(finished);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(finished);
        }

        //Get - Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fin = await _db.FinishedProducts.FindAsync(id);
            if (fin == null)
            {
                return NotFound();
            }
            return View(fin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FinishedProduct fin)
        {
            if (ModelState.IsValid)
            {
                _db.Update(fin);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(fin);
        }

        //Get - DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fin = await _db.FinishedProducts.FindAsync(id);
            if (fin == null)
            {
                return NotFound();
            }
            return View(fin);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {

            var fin = await _db.FinishedProducts.FindAsync(id);

            if (fin == null)
            {
                return NotFound();
            }
            _db.FinishedProducts.Remove(fin);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fin = await _db.FinishedProducts.FindAsync(id);
            if (fin == null)
            {
                return NotFound();
            }
            return View(fin);
        }

    }
}
