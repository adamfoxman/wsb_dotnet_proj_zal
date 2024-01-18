using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proj_zal.Data;
using proj_zal.Models;

namespace proj_zal.Controllers
{
    public class ArtistsController : Controller
    {
        // private readonly ApplicationDbContext _artistService;
        private readonly IGenericService<Artist> _artistService;

        public ArtistsController(IGenericService<Artist> artistService)
        {
            _artistService = artistService;
        }

        // GET: Artists
        public async Task<IActionResult> Index()
        {
            return _artistService.GetAllAsync() != null ?
                        View(await _artistService.GetAllAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Artists'  is null.");
        }

        // GET: Artists/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _artistService.GetAllAsync() == null)
            {
                return NotFound();
            }

            var artist = await _artistService.GetAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // GET: Artists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtistId,Name,Description,Genre")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                artist.ArtistId = Guid.NewGuid();
                await _artistService.AddAsync(artist);
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: Artists/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _artistService.GetAsync(id) == null)
            {
                return NotFound();
            }

            var artist = await _artistService.GetAsync(id);
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ArtistId,Name,Description,Genre")] Artist artist)
        {
            if (id != artist.ArtistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _artistService.UpdateAsync(artist);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistExists(artist.ArtistId))
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
            return View(artist);
        }

        // GET: Artists/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _artistService.GetAsync(id) == null)
            {
                return NotFound();
            }

            var artist = await _artistService.GetAsync(id);
            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_artistService.GetAllAsync() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Artists'  is null.");
            }
            var artist = await _artistService.GetAsync(id);
            if (artist != null)
            {
                await _artistService.DeleteAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ArtistExists(Guid id)
        {
            return _artistService.GetAsync(id) != null;
        }
    }
}
