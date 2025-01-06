using Application.Interfaces.RepositoryInterfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, string>
    {
        private readonly IAuthorRepository _authorRepository;

        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Task<string> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                throw new ArgumentException("Author ID must be a positive integer.", nameof(request.Id));
            }

            var authorToDelete = _authorRepository.DeleteAuthorById(request.Id);
            if (authorToDelete == null)
            {
                throw new KeyNotFoundException($"No Author found with ID {request.Id}.");
            }

            return Task.FromResult("Author deleted");
        }
    }
}
