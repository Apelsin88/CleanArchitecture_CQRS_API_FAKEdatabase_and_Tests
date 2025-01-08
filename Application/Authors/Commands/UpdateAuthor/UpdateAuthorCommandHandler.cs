//using Domain;
//using Infrastructure.Database;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Authors.Commands.UpdateAuthor
//{
//    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Author>
//    {
//        private readonly FakeDatabase _fakeDatabase;

//        public UpdateAuthorCommandHandler(FakeDatabase fakeDatabase)
//        {
//            _fakeDatabase = fakeDatabase;
//        }

//        public Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
//        {
//            if (request.Id <= 0)
//            {
//                throw new ArgumentException("Author ID must be greater than 0.", nameof(request.Id));
//            }

//            if (string.IsNullOrWhiteSpace(request.Name))
//            {
//                throw new ArgumentNullException(nameof(request.Name), "Name cannot be null or empty.");
//            }
                
//            Author authorToUpdate = _fakeDatabase.GetAuthorById(request.Id);
//            if (authorToUpdate == null)
//            {
//                throw new KeyNotFoundException($"No author found with ID {request.Id}.");
//            }

//            authorToUpdate.Name = request.Name;

//            return Task.FromResult(authorToUpdate);
//        }
//    }
//}
