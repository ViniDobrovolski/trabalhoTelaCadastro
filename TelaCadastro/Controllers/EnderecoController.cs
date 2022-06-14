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
    public class EnderecoController : Controller
    {
        private readonly Context _context;

        public EnderecoController(Context context)
        {
            _context = context;
        }

        // GET: Endereco
        public async Task<IActionResult> Index()
        {
              return _context.endereco != null ? 
                          View(await _context.endereco.ToListAsync()) :
                          Problem("Entity set 'Context.endereco'  is null.");
        }

        // GET: Endereco/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.endereco == null)
            {
                return NotFound();
            }

            var ender = await _context.endereco
                .FirstOrDefaultAsync(m => m.id == id);
            if (ender == null)
            {
                return NotFound();
            }

            return View(ender);
        }

        // GET: Endereco/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Endereco/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,cadastroid,rua,numero,cep,cidade,estado")] Ender ender)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ender);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ender);
        }

        // GET: Endereco/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.endereco == null)
            {
                return NotFound();
            }

            var ender = await _context.endereco.FindAsync(id);
            if (ender == null)
            {
                return NotFound();
            }
            return View(ender);
        }

        // POST: Endereco/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,cadastroid,rua,numero,cep,cidade,estado")] Ender ender)
        {
            if (id != ender.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ender);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderExists(ender.id))
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
            return View(ender);
        }

        // GET: Endereco/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.endereco == null)
            {
                return NotFound();
            }

            var ender = await _context.endereco
                .FirstOrDefaultAsync(m => m.id == id);
            if (ender == null)
            {
                return NotFound();
            }

            return View(ender);
        }

        // POST: Endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.endereco == null)
            {
                return Problem("Entity set 'Context.endereco'  is null.");
            }
            var ender = await _context.endereco.FindAsync(id);
            if (ender != null)
            {
                _context.endereco.Remove(ender);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderExists(int id)
        {
          return (_context.endereco?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
