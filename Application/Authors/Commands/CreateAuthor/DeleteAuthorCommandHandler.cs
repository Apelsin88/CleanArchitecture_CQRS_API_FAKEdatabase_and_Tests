using Domain;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands.CreateAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Author>
    {
        private readonly FakeDatabase _fakeDatabase;

        public DeleteAuthorCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public async Task<Author> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new ArgumentException("Name must be provided.");
            }

            var existingAuthor = _fakeDatabase.Authors.FirstOrDefault(author => author.Name == request.Name);
            if (existingAuthor != null)
            {
                throw new InvalidOperationException("A author with the same name already exists.");
            }

            var newAuthor = _fakeDatabase.AddNewAuthor(request.Name);

            return newAuthor;
        }
    }
}
