using Application.Interfaces.RepositoryInterfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Author>
    {
        private readonly IAuthorRepository _authorRepository;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Author newAuthorToAdd = new Author(1, request.Name);
                _authorRepository.AddAuthor(newAuthorToAdd);
                return await Task.FromResult(newAuthorToAdd);

            }
            catch
            {
                throw new Exception("Author not added");
            }
            
        }
    }
}
