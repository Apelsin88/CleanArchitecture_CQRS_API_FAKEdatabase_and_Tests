using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest<Author>
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public UpdateAuthorCommand(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}
