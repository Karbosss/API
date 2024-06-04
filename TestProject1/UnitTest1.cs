using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NoteManagerAPI.Controllers;
using Xunit;

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
        public void GetAllNotes_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetAllNotes();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var notes = Assert.IsType<List<NotesController.Note>>(okResult.Value);
            Assert.Equal(3, notes.Count);
        }

        [Fact]
        public void GetNoteById_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetNoteById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var note = Assert.IsType<NotesController.Note>(okResult.Value);
            Assert.Equal(1, note.Id);
        }

        [Fact]
        public void GetNoteById_ReturnsNotFoundResult()
        {
            // Act
            var result = _controller.GetNoteById(999);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void AddNote_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var newNote = new NotesController.Note
            {
                Title = "Test Note",
                Content = "Test Content"
            };

            // Act
            var result = _controller.AddNote(newNote);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var note = Assert.IsType<NotesController.Note>(createdAtActionResult.Value);
            Assert.Equal("Test Note", note.Title);
            Assert.Equal("Test Content", note.Content);
        }

        [Fact]
        public void UpdateNote_ReturnsNoContentResult()
        {
            // Arrange
            var updatedNote = new NotesController.Note
            {
                Title = "Updated Note",
                Content = "Updated Content"
            };

            // Act
            var result = _controller.UpdateNote(1, updatedNote);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void UpdateNote_ReturnsNotFoundResult()
        {
            // Arrange
            var updatedNote = new NotesController.Note
            {
                Title = "Updated Note",
                Content = "Updated Content"
            };

            // Act
            var result = _controller.UpdateNote(999, updatedNote);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteNoteById_ReturnsNoContentResult()
        {
            // Act
            var result = _controller.DeleteNoteById(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteNoteById_ReturnsNotFoundResult()
        {
            // Act
            var result = _controller.DeleteNoteById(999);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
