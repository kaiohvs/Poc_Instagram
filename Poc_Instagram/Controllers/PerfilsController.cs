using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Poc_Instagram.Data;
using Poc_Instagram.Models;

namespace Poc_Instagram.Controllers
{
    public class PerfilsController : Controller
    {
        private readonly BdContext _context;

        public PerfilsController(BdContext context)
        {
            _context = context;
        }

        // GET: Perfils
        public async Task<IActionResult> Index()
        {
              return View(await _context.Perfil.ToListAsync());
        }

        // GET: Perfils/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Perfil == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfil
                .FirstOrDefaultAsync(m => m.IdPerfil == id);
            if (perfil == null)
            {
                return NotFound();
            }

            return View(perfil);
        }

        // GET: Perfils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Perfils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPerfil,Name")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perfil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(perfil);
        }

        // GET: Perfils/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Perfil == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfil.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }
            return View(perfil);
        }

        // POST: Perfils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdPerfil,Name")] Perfil perfil)
        {
            if (id != perfil.IdPerfil)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perfil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerfilExists(perfil.IdPerfil))
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
            return View(perfil);
        }

        // GET: Perfils/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Perfil == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfil
                .FirstOrDefaultAsync(m => m.IdPerfil == id);
            if (perfil == null)
            {
                return NotFound();
            }

            return View(perfil);
        }

        // POST: Perfils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Perfil == null)
            {
                return Problem("Entity set 'BdContext.Perfil'  is null.");
            }
            var perfil = await _context.Perfil.FindAsync(id);
            if (perfil != null)
            {
                _context.Perfil.Remove(perfil);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerfilExists(long id)
        {
          return _context.Perfil.Any(e => e.IdPerfil == id);
        }
    }
}
