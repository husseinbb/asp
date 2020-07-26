using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
//using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT.Models;

namespace PROJECT.Controllers
{
    public class RawMaterialController : Controller
    {
        private readonly ApplicationDbContext _db;
        public RawMaterialController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.RawMaterials.ToListAsync());
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RawMaterial rawMaterial)
        {
            if (ModelState.IsValid)
            {
                _db.RawMaterials.Add(rawMaterial);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rawMaterial);
        }

        //Get - Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var raw = await _db.RawMaterials.FindAsync(id);
            if (raw == null)
            {
                return NotFound();
            }
            return View(raw);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RawMaterial raw)
        {
            if (ModelState.IsValid)
            {
                _db.Update(raw);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(raw);
        }

        //Get - DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var raw = await _db.RawMaterials.FindAsync(id);
            if (raw == null)
            {
                return NotFound();
            }
            return View(raw);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ? id)
        {

            var raw = await _db.RawMaterials.FindAsync(id);

            if (raw == null)
            {
                return NotFound();
            }
            _db.RawMaterials.Remove(raw);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var raw = await _db.RawMaterials.FindAsync(id);
            if (raw == null)
            {
                return NotFound();
            }
            return View(raw);
        }


    }
}
