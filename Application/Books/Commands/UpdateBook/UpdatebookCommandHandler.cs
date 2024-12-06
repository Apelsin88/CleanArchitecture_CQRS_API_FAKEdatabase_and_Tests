using Domain;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.UpdateBook
{
    public class UpdatebookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly FakeDatabase _fakeDatabase;

        public UpdatebookCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                throw new ArgumentException("Book ID must be greater than 0.", nameof(request.Id));
            }

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                throw new ArgumentNullException(nameof(request.Title), "Title cannot be null or empty.");
            }
                
            if (string.IsNullOrWhiteSpace(request.Genre))
            {
                throw new ArgumentNullException(nameof(request.Genre), "Genre cannot be null or empty.");
            }
                
            Book bookToUpdate = _fakeDatabase.GetBookById(request.Id);
            if (bookToUpdate == null)
            {
                throw new KeyNotFoundException($"No book found with ID {request.Id}.");
            }

            bookToUpdate.Title = request.Title;
            bookToUpdate.Genre = request.Genre;

            return Task.FromResult(bookToUpdate);
        }
    }
}
