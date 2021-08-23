using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FashionDMart.Data;
using FashionDMart.Models;

namespace FashionDMart.Controllers
{
    public class DCollectionsController : Controller
    {
        private readonly FashionDMartContext _context;

        public DCollectionsController(FashionDMartContext context)
        {
            _context = context;
        }

        // GET: DCollections
        public async Task<IActionResult> Index()
        {
            return View(await _context.DCollections.ToListAsync());
        }

        // GET: DCollections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dCollections = await _context.DCollections
                .FirstOrDefaultAsync(m => m.id == id);
            if (dCollections == null)
            {
                return NotFound();
            }

            return View(dCollections);
        }

        // GET: DCollections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DCollections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Qty,Price,dTime")] DCollections dCollections)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dCollections);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dCollections);
        }

        // GET: DCollections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dCollections = await _context.DCollections.FindAsync(id);
            if (dCollections == null)
            {
                return NotFound();
            }
            return View(dCollections);
        }

        // POST: DCollections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Qty,Price,dTime")] DCollections dCollections)
        {
            if (id != dCollections.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dCollections);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DCollectionsExists(dCollections.id))
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
            return View(dCollections);
        }

        // GET: DCollections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dCollections = await _context.DCollections
                .FirstOrDefaultAsync(m => m.id == id);
            if (dCollections == null)
            {
                return NotFound();
            }

            return View(dCollections);
        }

        // POST: DCollections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dCollections = await _context.DCollections.FindAsync(id);
            _context.DCollections.Remove(dCollections);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DCollectionsExists(int id)
        {
            return _context.DCollections.Any(e => e.id == id);
        }
    }
}
