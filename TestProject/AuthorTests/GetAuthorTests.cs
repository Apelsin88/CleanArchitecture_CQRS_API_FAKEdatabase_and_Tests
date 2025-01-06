//using Application.Authors.Queries.GetAuthor;
//using Application.Books.Queries.GetBook;
//using Infrastructure.Database;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestProject.AuthorTests
//{
//    [TestFixture]
//    public class GetAuthorTests
//    {
//        private FakeDatabase _fakeDatabase;
//        private GetAuthorQueryHandler _handler;

//        [SetUp]
//        public void SetUp()
//        {
//            _fakeDatabase = new FakeDatabase();
//            _handler = new GetAuthorQueryHandler(_fakeDatabase);
//        }

//        [Test]
//        [TestCase(1, null, null)] // Valid case
//        [TestCase(999, typeof(KeyNotFoundException), "Author with ID 999 was not found.")] // Invalid ID
//        [TestCase(-1, typeof(ArgumentException), "Author ID must be a positive integer")] // Negative ID
//        [TestCase(null, typeof(ArgumentNullException), "Request cannot be null.")] // Null request
//        public async Task Handle_GetAuthorQueryHandler_CombinedTests(int? authorId, Type? expectedException, string? expectedMessage)
//        {
//            // Arrange
//            GetAuthorQuery query = authorId.HasValue ? new GetAuthorQuery(authorId.Value) : null;

//            if (expectedException == null)
//            {
//                // Act
//                var result = await _handler.Handle(query, CancellationToken.None);

//                // Assert
//                Assert.That(result, Is.Not.Null);
//                Assert.That(result.Id, Is.EqualTo(authorId));
//            }
//            else
//            {
//                // Act & Assert
//                var ex = Assert.ThrowsAsync(expectedException, async () =>
//                    await _handler.Handle(query, CancellationToken.None)
//                );

//                Assert.That(ex.Message, Does.Contain(expectedMessage));
//            }
//        }
//    }
//}
