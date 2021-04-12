using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBookClient.Client.ViewModels
{
    public class BookView
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
        public DateTime DateOfPublication { get; set; }

        public int CategoryID { get; set; }
        public CategoryView Category { get; set; }

        public int PublisherID { get; set; }
        public PublisherView Publisher { get; set; }

        public List<BookAuthorView> BookAuthors { get; set; }
    }
}
