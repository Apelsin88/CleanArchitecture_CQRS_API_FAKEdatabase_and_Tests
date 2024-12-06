using Application.Books.Commands.UpdateBook;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.BookTests
{
    [TestFixture]
    public class UpdateBookTests
    {
        private FakeDatabase _fakeDatabase;
        private UpdatebookCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _fakeDatabase = new FakeDatabase();
            _handler = new UpdatebookCommandHandler(_fakeDatabase);
        }

        [Test]
        public async Task Handle_ValidUpdate_ReturnsUpdatedBook()
        {
            // Arrange
            var book = _fakeDatabase.Books[0];
            var command = new UpdateBookCommand("Updated Title", "Updated Genre", book.Id);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(book.Id));
            Assert.That(result.Title, Is.EqualTo("Updated Title"));
            Assert.That(result.Genre, Is.EqualTo("Updated Genre"));
        }

        [Test]
        public void Handle_InvalidId_ThrowsArgumentException()
        {
            // Arrange
            var command = new UpdateBookCommand("Updated Title", "Updated Genre", -1);

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(command, CancellationToken.None));
            Assert.That(ex.Message, Does.Contain("Book ID must be greater than 0"));
        }

        [Test]
        public void Handle_NonExistentId_ThrowsKeyNotFoundException()
        {
            // Arrange
            int nonExistentId = _fakeDatabase.Books.Count + 1;
            var command = new UpdateBookCommand("Updated Title", "Updated Genre", nonExistentId);

            // Act & Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
            Assert.That(ex.Message, Does.Contain($"No book found with ID {nonExistentId}"));
        }

        [Test]
        public void Handle_NullTitle_ThrowsArgumentNullException()
        {
            // Arrange
            var book = _fakeDatabase.Books[0];
            var command = new UpdateBookCommand(null, "Updated Genre", book.Id);

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(command, CancellationToken.None));
            Assert.That(ex.Message, Does.Contain("Title cannot be null or empty."));
        }

        [Test]
        public void Handle_NullGenre_ThrowsArgumentNullException()
        {
            // Arrange
            var book = _fakeDatabase.Books[0];
            var command = new UpdateBookCommand("Updated Title", null, book.Id);

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(command, CancellationToken.None));
            Assert.That(ex.Message, Does.Contain("Genre cannot be null or empty."));
        }
    }
}
