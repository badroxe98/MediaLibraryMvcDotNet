using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniProjetKhaoudi.Models;

namespace MiniProjetKhaoudi.Controllers
{
    public class VideoGamesController : Controller
    {
        private readonly MiniProjetKhaoudiContext _context;

        public VideoGamesController(MiniProjetKhaoudiContext context)
        {
            _context = context;
        }

        // GET: VideoGames
        public async Task<IActionResult> Index(string VideoGameGenre, string searchString)
        {
            IQueryable<String> genreQuery = from m in _context.VideoGame
                                               orderby m.genre
                                               select m.genre;
            var games = from m in _context.VideoGame
                        select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                games = games.Where(s => s.Title.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(VideoGameGenre))
            {
                games = games.Where(x => x.genre == VideoGameGenre);
            }
            var VideoGameGenreVM = new VideoGameGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Games = await games.ToListAsync()
            };
            return View(VideoGameGenreVM);
        }

        // GET: VideoGames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VideoGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,genre,Developer,Plateform,ReleaseDate,Rating")] VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(videoGame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(videoGame);
        }

        // GET: VideoGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoGame = await _context.VideoGame.FindAsync(id);
            if (videoGame == null)
            {
                return NotFound();
            }
            return View(videoGame);
        }

        // POST: VideoGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,genre,Developer,Plateform,ReleaseDate,Rating")] VideoGame videoGame)
        {
            if (id != videoGame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videoGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoGameExists(videoGame.Id))
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
            return View(videoGame);
        }

        // GET: VideoGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoGame = await _context.VideoGame
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videoGame == null)
            {
                return NotFound();
            }

            return View(videoGame);
        }

        // POST: VideoGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var videoGame = await _context.VideoGame.FindAsync(id);
            _context.VideoGame.Remove(videoGame);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoGameExists(int id)
        {
            return _context.VideoGame.Any(e => e.Id == id);
        }
    }
}
