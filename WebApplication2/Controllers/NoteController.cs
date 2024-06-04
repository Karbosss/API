using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace NoteManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private static List<Note> _notes = new List<Note>()
        {
            new Note { Id = 1, Title = "Note 1", Content = "Content of Note 1", CreatedAt = DateTime.Now },
            new Note { Id = 2, Title = "Note 2", Content = "Content of Note 2", CreatedAt = DateTime.Now },
            new Note { Id = 3, Title = "Note 3", Content = "Content of Note 3", CreatedAt = DateTime.Now }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Note>> GetAllNotes()
        {
            return Ok(_notes);
        }

        [HttpGet("{id}")]
        public ActionResult<Note> GetNoteById(int id)
        {
            var note = _notes.Find(n => n.Id == id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }

        [HttpPost]
        public ActionResult<Note> AddNote([FromBody] Note note)
        {
            note.Id = _notes.Count + 1;
            note.CreatedAt = DateTime.Now;
            _notes.Add(note);
            return CreatedAtAction(nameof(GetNoteById), new { id = note.Id }, note);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateNote(int id, [FromBody] Note note)
        {
            var existingNote = _notes.Find(n => n.Id == id);
            if (existingNote == null)
            {
                return NotFound();
            }
            existingNote.Title = note.Title;
            existingNote.Content = note.Content;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNoteById(int id)
        {
            var noteToDelete = _notes.Find(n => n.Id == id);
            if (noteToDelete == null)
            {
                return NotFound();
            }
            _notes.Remove(noteToDelete);
            return NoContent();
        }


        public class Note
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public DateTime CreatedAt { get; set; }
        }
    }
}