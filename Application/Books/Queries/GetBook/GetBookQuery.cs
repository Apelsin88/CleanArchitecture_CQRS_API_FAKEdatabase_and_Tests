using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Queries.GetBook
{
    public class GetBookQuery : IRequest<Book>
    {
        public int Id { get; set; }

        public GetBookQuery(int id)
        {
            Id = id;
        }
    }
}
