//using Application.Books.Commands.CreateBook;
//using Infrastructure.Database;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestProject.BookTests
//{
//    [TestFixture]
//    public class CreateBookTests
//    {
//        private FakeDatabase _fakeDatabase;
//        private CreateBookCommandHandler _handler;

//        [SetUp]
//        public void SetUp()
//        {
//            _fakeDatabase = new FakeDatabase();
//            _handler = new CreateBookCommandHandler(_fakeDatabase);
//        }

//        [Test]
//        public async Task Handle_CreateBookCommand_ShouldReturnNewBook()
//        {
//            // Arrange
//            var command = new CreateBookCommand("New Book", "Fiction");

//            // Act
//            var result = await _handler.Handle(command, default);

//            // Assert
//            Assert.That(result, Is.Not.Null);
//            Assert.That(result.Title, Is.EqualTo("New Book"));
//            Assert.That(result.Genre, Is.EqualTo("Fiction"));
//        }

//        [Test]
//        public void Handle_CreateBookCommand_WithEmptyTitle_ShouldThrowArgumentException()
//        {
//            // Arrange
//            var command = new CreateBookCommand("", "Fiction");

//            // Act & Assert
//            Assert.ThrowsAsync<ArgumentException>(async () =>
//                await _handler.Handle(command, default));
//        }

//        [Test]
//        public void Handle_CreateBookCommand_WithEmptyGenre_ShouldThrowArgumentException()
//        {
//            // Arrange
//            var command = new CreateBookCommand("New Book", "");

//            // Act & Assert
//            Assert.ThrowsAsync<ArgumentException>(async () =>
//                await _handler.Handle(command, default));
//        }

//        [Test]
//        public void Handle_CreateBookCommand_WithDuplicateTitle_ShouldThrowInvalidOperationException()
//        {
//            // Arrange
//            _fakeDatabase.AddNewBook("Existing Book", "Fiction");
//            var command = new CreateBookCommand("Existing Book", "Non-Fiction");

//            // Act & Assert
//            Assert.ThrowsAsync<InvalidOperationException>(async () =>
//                await _handler.Handle(command, default));
//        }
//    }
//}
