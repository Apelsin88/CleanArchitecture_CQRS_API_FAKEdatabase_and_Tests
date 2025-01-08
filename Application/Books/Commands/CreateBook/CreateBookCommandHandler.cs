//using Domain;
//using Infrastructure.Database;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Books.Commands.CreateBook
//{
//    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
//    {
//        private readonly FakeDatabase _fakeDatabase;

//        public CreateBookCommandHandler(FakeDatabase fakeDatabase)
//        {
//            _fakeDatabase = fakeDatabase;
//        }

//        public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
//        {
//            if (string.IsNullOrEmpty(request.Title) || string.IsNullOrEmpty(request.Genre))
//            {
//                throw new ArgumentException("Title and Genre must be provided.");
//            }

//            var existingBook = _fakeDatabase.Books.FirstOrDefault(b => b.Title == request.Title);
//            if (existingBook != null)
//            {
//                throw new InvalidOperationException("A book with the same title already exists.");
//            }

//            var newBook = _fakeDatabase.AddNewBook(request.Title, request.Genre);

//            return newBook;
//        }
//    }
//}
