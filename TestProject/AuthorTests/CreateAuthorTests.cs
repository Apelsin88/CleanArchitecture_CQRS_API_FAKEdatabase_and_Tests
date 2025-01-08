
//using Application.Authors.Commands.CreateAuthor;
//using Application.Books.Commands.CreateBook;
//using Infrastructure.Database;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestProject.AuthorTests
//{
//    [TestFixture]
//    public class CreateAuthorTests
//    {
//        private FakeDatabase _fakeDatabase;
//        private DeleteAuthorCommandHandler _handler;

//        [SetUp]
//        public void SetUp()
//        {
//            _fakeDatabase = new FakeDatabase();
//            _handler = new DeleteAuthorCommandHandler(_fakeDatabase);
//        }

//        [Test]
//        public async Task Handle_CreateAuthorCommand_ShouldReturnNewAuthor()
//        {
//            // Arrange
//            var command = new CreateAuthorCommand("New Author Name");

//            // Act
//            var result = await _handler.Handle(command, default);

//            // Assert
//            Assert.That(result, Is.Not.Null);
//            Assert.That(result.Name, Is.EqualTo("New Author Name"));
//        }

//        [Test]
//        public void Handle_CreateAuthorCommand_WithEmptyName_ShouldThrowArgumentException()
//        {
//            // Arrange
//            var command = new CreateAuthorCommand("");

//            // Act & Assert
//            Assert.ThrowsAsync<ArgumentException>(async () =>
//                await _handler.Handle(command, default));
//        }

//        [Test]
//        public void Handle_CreateAuthorCommand_WithDuplicateName_ShouldThrowInvalidOperationException()
//        {
//            // Arrange
//            _fakeDatabase.AddNewAuthor("Existing Author");
//            var command = new CreateAuthorCommand("Existing Author");

//            // Act & Assert
//            Assert.ThrowsAsync<InvalidOperationException>(async () =>
//                await _handler.Handle(command, default));
//        }
//    }
//}
