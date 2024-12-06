using Domain;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Queries.GetBook
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, Book>
    {
        private readonly FakeDatabase _fakeDatabase;

        public GetBookQueryHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<Book> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null.");
            }
            if (request.Id <= 0)
            {
                throw new ArgumentException("Book ID must be a positive integer",nameof(request.Id));
            }
            var book = _fakeDatabase.GetBookById(request.Id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {request.Id} was not found.");
            }
            return Task.FromResult(book);
        }
    }
}
