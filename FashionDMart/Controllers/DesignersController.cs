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
    public class DesignersController : Controller
    {
        private readonly FashionDMartContext _context;

        public DesignersController(FashionDMartContext context)
        {
            _context = context;
        }

        // GET: Designers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Designer.ToListAsync());
        }

        // GET: Designers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designer = await _context.Designer
                .FirstOrDefaultAsync(m => m.id == id);
            if (designer == null)
            {
                return NotFound();
            }

            return View(designer);
        }

        // GET: Designers/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Manage()
        {
            return View();
        }
        public IActionResult Wrong()
        {
            return View();
        }

        // POST: Designers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Password")] Designer designer)
        {
            if (designer.Name.Equals("designer@gmail.com") && designer.Password.Equals("1234"))
            {
                return RedirectToAction(nameof(Manage));
            }
            else {
                return RedirectToAction(nameof(Wrong));
            }
            
        }

        // GET: Designers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designer = await _context.Designer.FindAsync(id);
            if (designer == null)
            {
                return NotFound();
            }
            return View(designer);
        }

        // POST: Designers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Password")] Designer designer)
        {
            if (id != designer.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(designer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesignerExists(designer.id))
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
            return View(designer);
        }

        // GET: Designers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designer = await _context.Designer
                .FirstOrDefaultAsync(m => m.id == id);
            if (designer == null)
            {
                return NotFound();
            }

            return View(designer);
        }

        // POST: Designers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var designer = await _context.Designer.FindAsync(id);
            _context.Designer.Remove(designer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesignerExists(int id)
        {
            return _context.Designer.Any(e => e.id == id);
        }
    }
}
