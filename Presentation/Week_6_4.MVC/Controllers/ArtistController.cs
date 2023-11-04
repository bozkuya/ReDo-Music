using Microsoft.AspNetCore.Mvc;
using Week_6_4.Domain.Entities;
using Week_6_4.Persistence.Contexts;  
using System.Linq;

namespace YourAppNamespace.Controllers
{
    public class ArtistController : Controller
    {
        private readonly ApplicationDbContext _context; 

        public ArtistController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Artist
        public IActionResult Index()
        {
            var artists = _context.Artists.ToList(); // Fetch all artists from the database
            return View(artists);
        }

        // GET: Artist/Add
        public IActionResult Add()
        {
            // Assuming you have a method to get instruments. Replace with your actual data access code.
            ViewBag.Instruments = _context.Instruments.ToList(); 
            return View();
        }

        // POST: Artist/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add([FromForm] Artist artist, int[] instrumentIds)
        {
            if (ModelState.IsValid)
            {
                // Assuming Artist has a Genres and Instruments navigation property
                artist.Instruments = _context.Instruments.Where(i => instrumentIds.Contains(i.Id)).ToList();

                _context.Artists.Add(artist);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // If we got this far, something failed; redisplay form with instruments
            ViewBag.Instruments = _context.Instruments.ToList(); 
            return View(artist);
        }

        // GET: Artist/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = _context.Artists.Find(id);
            if (artist == null)
            {
                return NotFound();
            }

            ViewBag.Instruments = _context.Instruments.ToList();
            return View(artist);
        }

        // POST: Artist/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [FromForm] Artist artist, int[] instrumentIds)
        {
            if (id != artist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    artist.Instruments = _context.Instruments.Where(i => instrumentIds.Contains(i.Id)).ToList();
                    _context.Update(artist);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistExists(artist.Id))
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
            ViewBag.Instruments = _context.Instruments.ToList();
            return View(artist);
        }

        // GET: Artist/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = _context.Artists
                .FirstOrDefault(m => m.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // POST: Artist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var artist = _context.Artists.Find(id);
            _context.Artists.Remove(artist);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistExists(int id)
        {
            return _context.Artists.Any(e => e.Id == id);
        }
    }
}
