using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TelaCadastro.Models;

namespace TelaCadastro.Controllers
{
    public class TelaCadastroController : Controller
    {
        private readonly Context _context;

        public TelaCadastroController(Context context)
        {
            _context = context;
        }

        // GET: TelaCadastro
        public async Task<IActionResult> Index()
        {
              return _context.telacadastro != null ? 
                          View(await _context.telacadastro.ToListAsync()) :
                          Problem("Entity set 'Context.telacadastro'  is null.");
        }

        // GET: TelaCadastro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.telacadastro == null)
            {
                return NotFound();
            }

            var telaCad = await _context.telacadastro
                .FirstOrDefaultAsync(m => m.id == id);
            if (telaCad == null)
            {
                return NotFound();
            }

            return View(telaCad);
        }

        // GET: TelaCadastro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TelaCadastro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,email,senha,datanascimento,genero")] TelaCad telaCad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telaCad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(telaCad);
        }

        // GET: TelaCadastro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.telacadastro == null)
            {
                return NotFound();
            }

            var telaCad = await _context.telacadastro.FindAsync(id);
            if (telaCad == null)
            {
                return NotFound();
            }
            return View(telaCad);
        }

        // POST: TelaCadastro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,email,senha,datanascimento,genero")] TelaCad telaCad)
        {
            if (id != telaCad.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telaCad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelaCadExists(telaCad.id))
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
            return View(telaCad);
        }

        // GET: TelaCadastro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.telacadastro == null)
            {
                return NotFound();
            }

            var telaCad = await _context.telacadastro
                .FirstOrDefaultAsync(m => m.id == id);
            if (telaCad == null)
            {
                return NotFound();
            }

            return View(telaCad);
        }

        // POST: TelaCadastro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.telacadastro == null)
            {
                return Problem("Entity set 'Context.telacadastro'  is null.");
            }
            var telaCad = await _context.telacadastro.FindAsync(id);
            if (telaCad != null)
            {
                _context.telacadastro.Remove(telaCad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelaCadExists(int id)
        {
          return (_context.telacadastro?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
