using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBookClient.Client.ViewModels
{
    public class BookAuthorView
    {
        public int AuthorID { get; set; }
        public int BookID { get; set; }
        public AuthorView Author { get; set; }
        public BookView Book { get; set; }
    }
}
