//using Domain;
//using Infrastructure.Database;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Authors.Queries.GetAuthor
//{
//    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, Author>
//    {
//        private readonly FakeDatabase _fakeDatabase;

//        public GetAuthorQueryHandler(FakeDatabase fakeDatabase)
//        {
//            _fakeDatabase = fakeDatabase;
//        }

//        public Task<Author> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
//        {
//            if (request == null)
//            {
//                throw new ArgumentNullException(nameof(request), "Request cannot be null.");
//            }
//            if (request.Id <= 0)
//            {
//                throw new ArgumentException("Author ID must be a positive integer",nameof(request.Id));
//            }
//            var author = _fakeDatabase.GetAuthorById(request.Id);
//            if (author == null)
//            {
//                throw new KeyNotFoundException($"Author with ID {request.Id} was not found.");
//            }
//            return Task.FromResult(author);
//        }
//    }
//}
