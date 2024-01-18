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
    public class AlbumsController : Controller
    {
        private readonly IGenericService<Album> _albumService;

        public AlbumsController(IGenericService<Album> albumService)
        {
            _albumService = albumService;
        }

        // GET: Albums
        public async Task<IActionResult> Index()
        {
            return _albumService.GetAllAsync() != null ?
                        View(await _albumService.GetAllAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Albums'  is null.");
        }

        // GET: Albums/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _albumService.GetAsync(id) == null)
            {
                return NotFound();
            }

            var album = await _albumService.GetAsync(id);

            return View(album);
        }

        // GET: Albums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ArtistId,ReleaseDate,Genre,Description")] Album album)
        {
            if (ModelState.IsValid)
            {
                album.Id = Guid.NewGuid();
                await _albumService.AddAsync(album);
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        // GET: Albums/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _albumService.GetAsync(id) == null)
            {
                return NotFound();
            }

            var album = await _albumService.GetAsync(id);

            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,ArtistId,ReleaseDate,Genre,Description")] Album album)
        {
            if (id != album.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _albumService.UpdateAsync(album);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.Id))
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
            return View(album);
        }

        // GET: Albums/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _albumService.GetAsync(id) == null)
            {
                return NotFound();
            }

            var album = await _albumService.GetAsync(id);

            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_albumService.GetAllAsync() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Albums'  is null.");
            }
            var album = await _albumService.GetAsync(id);
            if (album != null)
            {
                await _albumService.DeleteAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(Guid id)
        {
            return _albumService.GetAsync(id) != null;
        }
    }
}
