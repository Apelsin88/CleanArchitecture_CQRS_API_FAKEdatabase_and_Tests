using Application.Books.Commands.DeleteBook;
using Domain;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, bool>
    {
        private readonly FakeDatabase _fakeDatabase;

        public DeleteAuthorCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                throw new ArgumentException("Author ID must be a positive integer.", nameof(request.Id));
            }

            var AuthorToDelete = _fakeDatabase.GetAuthorById(request.Id);
            if (AuthorToDelete == null)
            {
                throw new KeyNotFoundException($"No Author found with ID {request.Id}.");
            }

            bool isDeleted = _fakeDatabase.DeleteAuthor(request.Id);
            return Task.FromResult(isDeleted);
        }
    }
}
