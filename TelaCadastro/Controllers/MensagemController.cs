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
    public class MensagemController : Controller
    {
        private readonly Context _context;

        public MensagemController(Context context)
        {
            _context = context;
        }

        // GET: Mensagem
        public async Task<IActionResult> Index()
        {
              return _context.mensagem != null ? 
                          View(await _context.mensagem.ToListAsync()) :
                          Problem("Entity set 'Context.mensagem'  is null.");
        }

        // GET: Mensagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.mensagem == null)
            {
                return NotFound();
            }

            var mensa = await _context.mensagem
                .FirstOrDefaultAsync(m => m.id == id);
            if (mensa == null)
            {
                return NotFound();
            }

            return View(mensa);
        }

        // GET: Mensagem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mensagem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,cadastroid,mensagem")] Mensa mensa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mensa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mensa);
        }

        // GET: Mensagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.mensagem == null)
            {
                return NotFound();
            }

            var mensa = await _context.mensagem.FindAsync(id);
            if (mensa == null)
            {
                return NotFound();
            }
            return View(mensa);
        }

        // POST: Mensagem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,cadastroid,mensagem")] Mensa mensa)
        {
            if (id != mensa.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mensa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MensaExists(mensa.id))
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
            return View(mensa);
        }

        // GET: Mensagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.mensagem == null)
            {
                return NotFound();
            }

            var mensa = await _context.mensagem
                .FirstOrDefaultAsync(m => m.id == id);
            if (mensa == null)
            {
                return NotFound();
            }

            return View(mensa);
        }

        // POST: Mensagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.mensagem == null)
            {
                return Problem("Entity set 'Context.mensagem'  is null.");
            }
            var mensa = await _context.mensagem.FindAsync(id);
            if (mensa != null)
            {
                _context.mensagem.Remove(mensa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensaExists(int id)
        {
          return (_context.mensagem?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
