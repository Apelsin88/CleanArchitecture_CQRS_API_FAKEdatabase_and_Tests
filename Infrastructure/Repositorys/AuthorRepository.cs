using Application.Interfaces.RepositoryInterfaces;
using Domain;
using Infrastructure.Database;

namespace Infrastructure.Repositorys
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly RealDatabase _realDatabase;

        public AuthorRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<Author> AddAuthor(Author author)
        {
            _realDatabase.Authors.Add(author);
            await _realDatabase.SaveChangesAsync();
            return author;
        }

        public Task<string> DeleteAuthorById(int id)
        {
            var authorToDelete = _realDatabase.Authors.Where(author => author.Id == id).First();
            if(authorToDelete is not null)
            {
                _realDatabase.Authors.Remove(authorToDelete);
                _realDatabase.SaveChanges();
                return Task.FromResult("Success");
            }
            else
            {
                return Task.FromResult("Fail");
            }
        }

        public Task<List<Author>> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetAuthorById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Author> UpdateAuthorById(int id, Author author)
        {
            throw new NotImplementedException();
        }
    }
}
