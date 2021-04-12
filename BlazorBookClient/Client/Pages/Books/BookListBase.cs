using AutoMapper;
using BlazorBookClient.Client.Contracts;
using BlazorBookClient.Client.ViewModels;
using BlazorBookClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBookClient.Client.Pages.Books
{
    public class BookListBase : ComponentBase
    {
        [Inject]
        public IBookService BookService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public List<BookView> Books { get; set; } = new List<BookView>();

        public List<Book> BooksDB { get; set; } = new List<Book>();

        protected async override Task OnInitializedAsync()
        {
            BooksDB = (await BookService.GetAll()).ToList();

            Mapper.Map(BooksDB, Books);
        }


    }
}
