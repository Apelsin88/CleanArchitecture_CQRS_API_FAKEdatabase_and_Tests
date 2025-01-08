//using Application.Books.Commands.DeleteBook;
//using Infrastructure.Database;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestProject.BookTests
//{
//    [TestFixture]
//    public class DeleteBookTests
//    {
//        private FakeDatabase _fakeDatabase;
//        private DeleteBookCommandHandler _handler;
//        private int _nonExistentId;

//        [SetUp]
//        public void SetUp()
//        {
//            _fakeDatabase = new FakeDatabase();
//            _handler = new DeleteBookCommandHandler(_fakeDatabase);
//            _nonExistentId = _fakeDatabase.Books.Max(b => b.Id + 1);
//        }

//        [Test]
//        [TestCase(1, true)] // Valid ID
//        [TestCase(-1, false)] // Invalid negative ID
//        [TestCase(0, false)] // Invalid zero ID
//        public async Task Handle_DeleteBookCommandHandler_Validations(int bookId, bool expectedOutcome)
//        {
//            // Arrange
//            var command = new DeleteBookCommand(bookId);

//            // Act & Assert
//            if (bookId <= 0)
//            {
//                Assert.ThrowsAsync<ArgumentException>(async () =>
//                    await _handler.Handle(command, CancellationToken.None));
//            }
//            else if (bookId == _nonExistentId)
//            {
//                Assert.ThrowsAsync<KeyNotFoundException>(async () =>
//                    await _handler.Handle(command, CancellationToken.None));
//            }
//            else
//            {
//                var result = await _handler.Handle(command, CancellationToken.None);
//                Assert.That(result, Is.EqualTo(expectedOutcome));
//                Assert.That(_fakeDatabase.Books.Exists(b => b.Id == bookId), Is.False);
//            }
//        }
//    }
//}
