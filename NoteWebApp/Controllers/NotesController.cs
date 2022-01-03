using Microsoft.AspNetCore.Mvc;
using NoteWebApp.Data;
using NoteWebApp.Models;

namespace NoteWebApp.Controllers
{
    public class NotesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public NotesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Note> notes = _db.Notes.ToList();
            return View(notes);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note note)
        {
            if (note.Title == note.Content)
            {
                ModelState.AddModelError("Title", "The title and the content can't be the same");
            }

            if (ModelState.IsValid)
            {
                _db.Notes.Add(note);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(note);
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // var note = _db.Notes.SingleOrDefault(n => n.Id == id);
            var note = _db.Notes.Find(id);
            return View(note);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Note note)
        {
            if (note.Title == note.Content)
            {
                ModelState.AddModelError("Title", "The title and the content can't be the same");
            }

            if (ModelState.IsValid)
            {
                _db.Notes.Update(note);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(note);
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // var note = _db.Notes.SingleOrDefault(n => n.Id == id);
            var note = _db.Notes.Find(id);
            return View(note);
        }

        // POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var note = _db.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }

            _db.Notes.Remove(note);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
