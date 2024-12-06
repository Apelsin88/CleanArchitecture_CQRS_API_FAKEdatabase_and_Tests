using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<Book>
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Id { get; set; }

        public UpdateBookCommand(string title, string genre, int id)
        {
            Title = title;
            Genre = genre;
            Id = id;
        }
    }
}
