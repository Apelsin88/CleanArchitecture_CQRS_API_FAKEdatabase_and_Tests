//using Application.Books.Queries.GetAllBooks;
//using Application.Books.Queries.GetBook;
//using Infrastructure.Database;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestProject.BookTests
//{
//    [TestFixture]
//    public class GetAllBooksTests
//    {
//        private FakeDatabase _fakeDatabase;
//        private GetAllBooksQueryHandler _handler;

//        [SetUp]
//        public void SetUp()
//        {
//            _fakeDatabase = new FakeDatabase();
//            _handler = new GetAllBooksQueryHandler(_fakeDatabase);
//        }

//        [Test]
//        public async Task Handle_ShouldReturnAllBooks_WhenBooksExist()
//        {
//            // Arrange
//            var expectedBooks = _fakeDatabase.Books;
//            var query = new GetAllBooksQuery();

//            // Act
//            var result = await _handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.That(result, Is.Not.Null);
//            Assert.That(result.Count, Is.EqualTo(expectedBooks.Count));
//        }

//        [Test]
//        public void Handle_ShouldThrowException_WhenDatabaseIsNull()
//        {
//            // Arrange
//            _fakeDatabase = null;
//            _handler = new GetAllBooksQueryHandler(_fakeDatabase);
//            var query = new GetAllBooksQuery();

//            // Act & Assert
//            Assert.ThrowsAsync<NullReferenceException>(
//                async () => await _handler.Handle(query, CancellationToken.None),
//                "The book database returned null."
//            );
//        }
//    }
//}
