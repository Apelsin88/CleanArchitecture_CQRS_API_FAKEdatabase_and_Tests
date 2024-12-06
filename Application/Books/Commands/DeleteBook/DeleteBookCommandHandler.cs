using Application.Books.Commands.DeleteBook;
using Domain;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly FakeDatabase _fakeDatabase;

        public DeleteBookCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                throw new ArgumentException("Book ID must be a positive integer.", nameof(request.Id));
            }

            var bookToDelete = _fakeDatabase.GetBookById(request.Id);
            if (bookToDelete == null)
            {
                throw new KeyNotFoundException($"No book found with ID {request.Id}.");
            }

            bool isDeleted = _fakeDatabase.DeleteBook(request.Id);
            return Task.FromResult(isDeleted);
        }
    }
}
