using Xunit;
using NoteManagerAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace NoteManagerAPI.Tests
{
    public class UnitTest1
    {
        private NotesController _controller;

        public UnitTest1()
        {
            _controller = new NotesController();
        }

       

        [Fact]
        public void GetNoteById_ReturnsNotFoundResult()
        {
            
            var result = _controller.GetNoteById(999);

            
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void AddNote_ReturnsCreatedAtActionResult()
        {
           
            var newNote = new NotesController.Note
            {
                Title = "Test Note",
                Content = "Test Content"
            };

            
            var result = _controller.AddNote(newNote);

            
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var note = Assert.IsType<NotesController.Note>(createdAtActionResult.Value);
            Assert.Equal("Test Note", note.Title);
            Assert.Equal("Test Content", note.Content);
        }

        

        [Fact]
        public void UpdateNote_ReturnsNotFoundResult()
        {
            
            var updatedNote = new NotesController.Note
            {
                Title = "Updated Note",
                Content = "Updated Content"
            };

            
            var result = _controller.UpdateNote(999, updatedNote);

            
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteNoteById_ReturnsNoContentResult()
        {
            
            var result = _controller.DeleteNoteById(1);

            
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteNoteById_ReturnsNotFoundResult()
        {
            
            var result = _controller.DeleteNoteById(999);

            
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
