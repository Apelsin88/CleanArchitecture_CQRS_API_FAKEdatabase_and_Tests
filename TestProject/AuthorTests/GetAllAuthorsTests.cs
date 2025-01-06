//using Application.Authors.Queries.GetAllAuthors;
//using Application.Books.Queries.GetAllBooks;
//using Infrastructure.Database;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestProject.AuthorTests
//{
//    [TestFixture]
//    public class GetAllAuthorsTests
//    {
//        private FakeDatabase _fakeDatabase;
//        private GetAllAuthorsQueryHandler _handler;

//        [SetUp]
//        public void SetUp()
//        {
//            _fakeDatabase = new FakeDatabase();
//            _handler = new GetAllAuthorsQueryHandler(_fakeDatabase);
//        }

//        [Test]
//        public async Task Handle_ShouldReturnAllAuthors_WhenAuthorsExist()
//        {
//            // Arrange
//            var expectedAuthors = _fakeDatabase.Authors;
//            var query = new GetAllAuthorsQuery();

//            // Act
//            var result = await _handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.That(result, Is.Not.Null);
//            Assert.That(result.Count, Is.EqualTo(expectedAuthors.Count));
//        }

//        [Test]
//        public void Handle_ShouldThrowException_WhenDatabaseIsNull()
//        {
//            // Arrange
//            _fakeDatabase = null;
//            _handler = new GetAllAuthorsQueryHandler(_fakeDatabase);
//            var query = new GetAllAuthorsQuery();

//            // Act & Assert
//            Assert.ThrowsAsync<NullReferenceException>(
//                async () => await _handler.Handle(query, CancellationToken.None),
//                "The author database returned null."
//            );
//        }
//    }
//}
