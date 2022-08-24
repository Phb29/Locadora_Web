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
    public class AdminFilmeCategoriasController : Controller
    {
        private readonly AppDbContext _context;

        public AdminFilmeCategoriasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminFilmeCategorias
        public async Task<IActionResult> Index()
        {
              return View(await _context.FilmeCategorias.ToListAsync());
        }

        // GET: Admin/AdminFilmeCategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FilmeCategorias == null)
            {
                return NotFound();
            }

            var filmeCategoria = await _context.FilmeCategorias
                .FirstOrDefaultAsync(m => m.FilmeCategoriaId == id);
            if (filmeCategoria == null)
            {
                return NotFound();
            }

            return View(filmeCategoria);
        }

        // GET: Admin/AdminFilmeCategorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminFilmeCategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FilmeCategoriaId,NomeGenero,Descricao")] FilmeCategoria filmeCategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmeCategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmeCategoria);
        }

        // GET: Admin/AdminFilmeCategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FilmeCategorias == null)
            {
                return NotFound();
            }

            var filmeCategoria = await _context.FilmeCategorias.FindAsync(id);
            if (filmeCategoria == null)
            {
                return NotFound();
            }
            return View(filmeCategoria);
        }

        // POST: Admin/AdminFilmeCategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FilmeCategoriaId,NomeGenero,Descricao")] FilmeCategoria filmeCategoria)
        {
            if (id != filmeCategoria.FilmeCategoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmeCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeCategoriaExists(filmeCategoria.FilmeCategoriaId))
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
            return View(filmeCategoria);
        }

        // GET: Admin/AdminFilmeCategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FilmeCategorias == null)
            {
                return NotFound();
            }

            var filmeCategoria = await _context.FilmeCategorias
                .FirstOrDefaultAsync(m => m.FilmeCategoriaId == id);
            if (filmeCategoria == null)
            {
                return NotFound();
            }

            return View(filmeCategoria);
        }

        // POST: Admin/AdminFilmeCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FilmeCategorias == null)
            {
                return Problem("Entity set 'AppDbContext.FilmeCategorias'  is null.");
            }
            var filmeCategoria = await _context.FilmeCategorias.FindAsync(id);
            if (filmeCategoria != null)
            {
                _context.FilmeCategorias.Remove(filmeCategoria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmeCategoriaExists(int id)
        {
          return _context.FilmeCategorias.Any(e => e.FilmeCategoriaId == id);
        }
    }
}
