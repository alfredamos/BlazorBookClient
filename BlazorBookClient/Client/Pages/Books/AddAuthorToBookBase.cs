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
    public class AddAuthorToBookBase : ComponentBase
    {
        [Inject]
        public IAuthorService AuthorService { get; set; }

        [Inject]
        public IBookService BookService { get; set; }

        [Inject]
        public IBookAuthorService BookAuthorService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        public Book BookDB { get; set; } = new Book();

        public List<Author> AuthorsDB { get; set; } = new List<Author>();

        public BookAuthor BookAuthor { get; set; } = new();

        public List<BookAuthor> BookAuthors { get; set; } = new();

        public List<AuthorView> Authors { get; set; } = new List<AuthorView>();

        public AuthorView Author { get; set; } = new AuthorView();

        public Author AuthorDB { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            AuthorsDB = (await AuthorService.GetAll()).ToList();
            BookDB = await BookService.GetById(Id);
            //BookAuthors = BookDB.BookAuthors;

            Mapper.Map(AuthorsDB, Authors);
           
        }

        protected async Task AuthorAddToBook()
        {                                  
            BookAuthor = new BookAuthor
            {
                BookID = BookDB.BookID,
                AuthorID = Author.AuthorID,                     
            };
            
            var bookAuthor = await BookAuthorService.AddEntity(BookAuthor);            

            if (bookAuthor != null)
            {
                NavigationManager.NavigateTo("/bookList");
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/bookList");
        }
    }
}
