using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Queries.GetAuthor
{
    public class GetAuthorQuery : IRequest<Author>
    {
        public int Id { get; set; }

        public GetAuthorQuery(int id)
        {
            Id = id;
        }
    }
}
