//using Application.Authors.Commands.DeleteAuthor;
//using Application.Books.Commands.DeleteBook;
//using Infrastructure.Database;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestProject.AuthorTests
//{
//    [TestFixture]
//    public class DeleteAuthorTests
//    {
//        private FakeDatabase _fakeDatabase;
//        private DeleteAuthorCommandHandler _handler;
//        private int _nonExistentId;

//        [SetUp]
//        public void SetUp()
//        {
//            _fakeDatabase = new FakeDatabase();
//            _handler = new DeleteAuthorCommandHandler(_fakeDatabase);
//            _nonExistentId = _fakeDatabase.Authors.Max(author => author.Id + 1);
//        }

//        [Test]
//        [TestCase(1, true)] // Valid ID
//        [TestCase(-1, false)] // Invalid negative ID
//        [TestCase(0, false)] // Invalid zero ID
//        public async Task Handle_DeleteAuthorCommandHandler_Validations(int authorId, bool expectedOutcome)
//        {
//            // Arrange
//            var command = new DeleteAuthorCommand(authorId);

//            // Act & Assert
//            if (authorId <= 0)
//            {
//                Assert.ThrowsAsync<ArgumentException>(async () =>
//                    await _handler.Handle(command, CancellationToken.None));
//            }
//            else if (authorId == _nonExistentId)
//            {
//                Assert.ThrowsAsync<KeyNotFoundException>(async () =>
//                    await _handler.Handle(command, CancellationToken.None));
//            }
//            else
//            {
//                var result = await _handler.Handle(command, CancellationToken.None);
//                Assert.That(result, Is.EqualTo(expectedOutcome));
//                Assert.That(_fakeDatabase.Authors.Exists(author => author.Id == authorId), Is.False);
//            }
//        }
//    }
//}
