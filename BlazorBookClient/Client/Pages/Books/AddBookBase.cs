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
    public class AddBookBase : ComponentBase
    {
        [Inject]
        public IAuthorService AuthorService { get; set; }

        [Inject]
        public IBookService BookService { get; set; }

        [Inject]
        public ICategoryService CategoryService { get; set; }

        [Inject]
        public IPublisherService PublisherService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public BookView Book { get; set; } = new BookView();

        public Book BookDB { get; set; } = new Book();

        public List<Category> CategoriesDB { get; set; } = new();

        public List<CategoryView> Categories { get; set; } = new();

        public List<Publisherr> PublishersDB { get; set; } = new();

        public List<PublisherView> Publishers { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {            
            CategoriesDB = (await CategoryService.GetAll()).ToList();
            PublishersDB = (await PublisherService.GetAll()).ToList();
            
            Mapper.Map(CategoriesDB, Categories);
            Mapper.Map(PublishersDB, Publishers);
        }

        protected async Task CreateBook()
        {
            Mapper.Map(Book, BookDB);

            var book = await BookService.AddEntity(BookDB);

            if (book != null)
            {
                NavigationManager.NavigateTo("bookList");
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("bookList");
        }
    }
}
