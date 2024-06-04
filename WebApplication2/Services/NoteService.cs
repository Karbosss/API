using System;
using System.Collections.Generic;
using System.Linq;
using NoteManagerAPI.Models;

namespace NoteManagerAPI.Services
{
    public class NoteService : INoteService
    {
        private readonly List<Note> _notes;

        public NoteService()
        {
            _notes = new List<Note>();
        }

        public IEnumerable<Note> GetAllNotes()
        {
            return _notes;
        }

        public Note GetNoteById(int id)
        {
            return _notes.FirstOrDefault(note => note.Id == id);
        }

        public void AddNote(Note note)
        {
            note.Id = _notes.Any() ? _notes.Max(n => n.Id) + 1 : 1;
            note.CreatedAt = DateTime.Now;
            _notes.Add(note);
        }

        public void UpdateNoteContent(int id, string content)
        {
            var noteToUpdate = _notes.FirstOrDefault(note => note.Id == id);
            if (noteToUpdate != null)
            {
                noteToUpdate.Content = content;
            }
        }

        public void DeleteNoteById(int id)
        {
            var noteToDelete = _notes.FirstOrDefault(note => note.Id == id);
            if (noteToDelete != null)
            {
                _notes.Remove(noteToDelete);
            }
        }

        public IEnumerable<Note> SearchNotes(string title)
        {
            return _notes.Where(note => note.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        }
    }
}

