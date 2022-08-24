using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebLocadora.Context;
using WebLocadora.Models;

namespace WebLocadora.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FilmesController : Controller
    {
        private readonly AppDbContext _context;

        public FilmesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Filmes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Filmes.Include(f => f.FilmeCategoria);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/Filmes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Filmes == null)
            {
                return NotFound();
            }

            var filme = await _context.Filmes
                .Include(f => f.FilmeCategoria)
                .FirstOrDefaultAsync(m => m.FilmeId == id);
            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // GET: Admin/Filmes/Create
        public IActionResult Create()
        {
            ViewData["FilmeCategoriaId"] = new SelectList(_context.FilmeCategorias, "FilmeCategoriaId", "FilmeCategoriaId");
            return View();
        }

        // POST: Admin/Filmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FilmeId,FilmeNome,Preco,Disponivel,FilmeImg,Preferido,FilmeCategoriaId")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmeCategoriaId"] = new SelectList(_context.FilmeCategorias, "FilmeCategoriaId", "FilmeCategoriaId", filme.FilmeCategoriaId);
            return View(filme);
        }

        // GET: Admin/Filmes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Filmes == null)
            {
                return NotFound();
            }

            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)
            {
                return NotFound();
            }
            ViewData["FilmeCategoriaId"] = new SelectList(_context.FilmeCategorias, "FilmeCategoriaId", "FilmeCategoriaId", filme.FilmeCategoriaId);
            return View(filme);
        }

        // POST: Admin/Filmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FilmeId,FilmeNome,Preco,Disponivel,FilmeImg,Preferido,FilmeCategoriaId")] Filme filme)
        {
            if (id != filme.FilmeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeExists(filme.FilmeId))
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
            ViewData["FilmeCategoriaId"] = new SelectList(_context.FilmeCategorias, "FilmeCategoriaId", "FilmeCategoriaId", filme.FilmeCategoriaId);
            return View(filme);
        }

        // GET: Admin/Filmes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Filmes == null)
            {
                return NotFound();
            }

            var filme = await _context.Filmes
                .Include(f => f.FilmeCategoria)
                .FirstOrDefaultAsync(m => m.FilmeId == id);
            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // POST: Admin/Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Filmes == null)
            {
                return Problem("Entity set 'AppDbContext.Filmes'  is null.");
            }
            var filme = await _context.Filmes.FindAsync(id);
            if (filme != null)
            {
                _context.Filmes.Remove(filme);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmeExists(int id)
        {
          return _context.Filmes.Any(e => e.FilmeId == id);
        }
    }
}
