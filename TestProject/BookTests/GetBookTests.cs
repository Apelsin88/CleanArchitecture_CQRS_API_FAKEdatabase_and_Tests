//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Domain;
//using Application.Books.Queries.GetBook;
//using Infrastructure.Database;

//namespace TestProject.BookTests
//{
//    [TestFixture]
//    public class GetBookTests
//    {
//        private FakeDatabase _fakeDatabase;
//        private GetBookQueryHandler _handler;

//        [SetUp]
//        public void SetUp()
//        {
//            _fakeDatabase = new FakeDatabase();
//            _handler = new GetBookQueryHandler(_fakeDatabase);
//        }

//        [Test]
//        [TestCase(1, null, null)] // Valid case
//        [TestCase(999, typeof(KeyNotFoundException), "Book with ID 999 was not found.")] // Invalid ID
//        [TestCase(-1, typeof(ArgumentException), "Book ID must be a positive integer")] // Negative ID
//        [TestCase(null, typeof(ArgumentNullException), "Request cannot be null.")] // Null request
//        public async Task Handle_GetBookQueryHandler_CombinedTests(int? bookId, Type? expectedException, string? expectedMessage)
//        {
//            // Arrange
//            GetBookQuery query = bookId.HasValue ? new GetBookQuery(bookId.Value) : null;

//            if (expectedException == null)
//            {
//                // Act
//                var result = await _handler.Handle(query, CancellationToken.None);

//                // Assert
//                Assert.That(result, Is.Not.Null);
//                Assert.That(result.Id, Is.EqualTo(bookId));
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
