using Microsoft.AspNetCore.Mvc;
using ArtistManagementApp.DAL.Interface;
using ArtistManagementApp.Models;

namespace ArtistManagementApp.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistInterface _artistRepository;

        public ArtistController(IArtistInterface artistRepository)
        {
            _artistRepository = artistRepository;
        }

        // GET: /Artist/Index
        public IActionResult Index()
        {
            var artists = _artistRepository.GetAllArtists();
            return View(artists);
        }

        // GET: /Artist/Details/{id}
        public IActionResult Details(int id)
        {
            var artist = _artistRepository.GetArtistById(id);

            if (artist == null)
            {
                return NotFound(); // 404 Not Found
            }

            return View(artist);
        }

        // GET: /Artist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Artist/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Artist artist)
        {
            if (ModelState.IsValid)
            {
                _artistRepository.AddArtist(artist);
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        // GET: /Artist/Edit/{id}
        public IActionResult Edit(int id)
        {
            var artist = _artistRepository.GetArtistById(id);

            if (artist == null)
            {
                return NotFound(); // 404 Not Found
            }

            return View(artist);
        }

        // POST: /Artist/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Artist updatedArtist)
        {
            if (id != updatedArtist.ArtistId)
            {
                return BadRequest(); // 400 Bad Request
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _artistRepository.UpdateArtist(updatedArtist);
                }
                catch (ArgumentException)
                {
                    return NotFound(); // 404 Not Found
                }

                return RedirectToAction("Index");
            }

            return View(updatedArtist);
        }

        // GET: /Artist/Delete/{id}
        public IActionResult Delete(int id)
        {
            var artist = _artistRepository.GetArtistById(id);

            if (artist == null)
            {
                return NotFound(); // 404 Not Found
            }

            return View(artist);
        }

        // POST: /Artist/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var deletedArtist = _artistRepository.DeleteArtist(id);

            if (deletedArtist == null)
            {
                return NotFound(); // 404 Not Found
            }

            return RedirectToAction("Index");
        }
    }
}
