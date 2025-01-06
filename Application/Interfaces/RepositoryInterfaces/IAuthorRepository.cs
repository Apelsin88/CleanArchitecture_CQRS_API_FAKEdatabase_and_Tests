using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.RepositoryInterfaces
{
    public interface IAuthorRepository
    {
        Task<Author> AddAuthor(Author author);

        Task<List<Author>> GetAllAuthors();

        Task<Author> GetAuthorById(int id);

        Task<string> DeleteAuthorById(int id);

        Task<Author> UpdateAuthorById(int id, Author author);
    }
}
