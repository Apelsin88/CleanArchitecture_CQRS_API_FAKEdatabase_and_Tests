using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Book>
    {
        public string Title { get; set; }
        public string Genre { get; set; }

        public CreateBookCommand(string title, string genre)
        {
            Title = title;
            Genre = genre;
        }

    }
}
