using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SongsListsController : Controller
    {
        private readonly SongsListContext _context;

        public SongsListsController(SongsListContext context)
        {
            _context = context;
        }

        // GET: SongsLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.SongsList.ToListAsync());
        }

        // GET: SongsLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songsList = await _context.SongsList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (songsList == null)
            {
                return NotFound();
            }

            return View(songsList);
        }

        // GET: SongsLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SongsLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,Length,YoutubeUrl,ImageUrl")] SongsList songsList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(songsList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(songsList);
        }

        // GET: SongsLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songsList = await _context.SongsList.FindAsync(id);
            if (songsList == null)
            {
                return NotFound();
            }
            return View(songsList);
        }

        // POST: SongsLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,Length,YoutubeUrl,ImageUrl")] SongsList songsList)
        {
            if (id != songsList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(songsList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongsListExists(songsList.Id))
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
            return View(songsList);
        }

        // GET: SongsLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songsList = await _context.SongsList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (songsList == null)
            {
                return NotFound();
            }

            return View(songsList);
        }

        // POST: SongsLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var songsList = await _context.SongsList.FindAsync(id);
            _context.SongsList.Remove(songsList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongsListExists(int id)
        {
            return _context.SongsList.Any(e => e.Id == id);
        }
    }
}
