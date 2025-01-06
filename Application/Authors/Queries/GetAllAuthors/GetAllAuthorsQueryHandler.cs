//using Domain;
//using Infrastructure.Database;
//using MediatR;
//using Microsoft.Extensions.Caching.Memory;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace Application.Authors.Queries.GetAllAuthors
//{
//    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<Author>>
//    {
//        private readonly FakeDatabase _fakeDatabase;
//        private readonly IMemoryCache _memoryCache;
//        private const string cacheKey = "allAuthors";

//        public GetAllAuthorsQueryHandler(FakeDatabase fakeDatabase, IMemoryCache memoryCache)
//        {
//            _fakeDatabase = fakeDatabase;
//            _memoryCache = memoryCache;
//        }

//        public Task<List<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
//        {
//            if(!_memoryCache.TryGetValue(cacheKey, out List<Author> authors))
//            {
//                authors = _fakeDatabase.GetAllAuthors();
//                _memoryCache.Set(cacheKey, authors, TimeSpan.FromMinutes(5));
//            }

//            if (authors == null)
//            {
//                throw new InvalidOperationException("The author database returned null.");
//            }

//            return Task.FromResult(authors);
//        }
//    }
//}
