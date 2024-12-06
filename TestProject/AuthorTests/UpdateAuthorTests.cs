using Application.Authors.Commands.UpdateAuthor;
using Application.Books.Commands.UpdateBook;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.AuthorTests
{
    [TestFixture]
    public class UpdateAuthorTests
    {
        private FakeDatabase _fakeDatabase;
        private UpdateAuthorCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _fakeDatabase = new FakeDatabase();
            _handler = new UpdateAuthorCommandHandler(_fakeDatabase);
        }

        [Test]
        public async Task Handle_ValidUpdate_ReturnsUpdatedAuthor()
        {
            // Arrange
            var author = _fakeDatabase.Authors[0];
            var command = new UpdateAuthorCommand("Updated Name", author.Id);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(author.Id));
            Assert.That(result.Name, Is.EqualTo("Updated Name"));
        }

        [Test]
        public void Handle_InvalidId_ThrowsArgumentException()
        {
            // Arrange
            var command = new UpdateAuthorCommand("Updated Name", -1);

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(command, CancellationToken.None));
            Assert.That(ex.Message, Does.Contain("Author ID must be greater than 0"));
        }

        [Test]
        public void Handle_NonExistentId_ThrowsKeyNotFoundException()
        {
            // Arrange
            int nonExistentId = _fakeDatabase.Authors.Count + 1;
            var command = new UpdateAuthorCommand("Updated Name", nonExistentId);

            // Act & Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
            Assert.That(ex.Message, Does.Contain($"No author found with ID {nonExistentId}"));
        }

        [Test]
        public void Handle_NullName_ThrowsArgumentNullException()
        {
            // Arrange
            var book = _fakeDatabase.Authors[0];
            var command = new UpdateAuthorCommand(null, book.Id);

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(command, CancellationToken.None));
            Assert.That(ex.Message, Does.Contain("Name cannot be null or empty."));
        }
    }
}
