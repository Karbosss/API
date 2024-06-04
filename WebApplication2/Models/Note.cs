using System;

namespace NoteManagerAPI.Models
{
    public class Note
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
