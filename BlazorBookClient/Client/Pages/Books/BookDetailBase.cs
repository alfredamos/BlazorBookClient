using AutoMapper;
using BlazorBookClient.Client.Contracts;
using BlazorBookClient.Client.Shared.UI;
using BlazorBookClient.Client.ViewModels;
using BlazorBookClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBookClient.Client.Pages.Books
{
    public class BookDetailBase : ComponentBase
    {
        [Inject]
        public IBookService BookService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        protected ConfirmDelete DeleteConfirmation { get; set; }

        public BookView Book { get; set; } = new BookView();

        public Book BookDB { get; set; } = new Book();

        protected async override Task OnInitializedAsync()
        {
            BookDB = await BookService.GetById(Id);

            Mapper.Map(BookDB, Book);
        }

        protected void DeleteClick()
        {
            DeleteConfirmation.Show();
        }

        protected async Task DeletePublisher(bool deleteConfirmed)
        {
            Mapper.Map(Book, BookDB);

            if (deleteConfirmed)
            {
                await BookService.DeleteEntity(Id);
            }

            NavigationManager.NavigateTo("bookList");
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("bookList");
        }
    }
}
