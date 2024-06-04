using NoteManagerAPI.Models;
using System.Collections.Generic;

namespace NoteManagerAPI.Services
{
    public interface INoteService
    {
        IEnumerable<Note> GetAllNotes();
        Note GetNoteById(int id);
        void AddNote(Note note);
        void UpdateNoteContent(int id, string content);
        void DeleteNoteById(int id);
        IEnumerable<Note> SearchNotes(string title);
    }
}
