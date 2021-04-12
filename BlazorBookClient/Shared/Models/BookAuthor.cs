using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBookClient.Shared.Models
{
    public class BookAuthor
    {
        public int AuthorID { get; set; }
        public int BookID { get; set; }
        public Author Author { get; set; }
        public Book   Book { get; set; }

    }
}
