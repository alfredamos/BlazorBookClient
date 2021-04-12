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
    public class RemoveAuthorFromBookBase : ComponentBase
    {
        [Inject]
        public IBookAuthorService BookAuthorService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int IdOfAuthor { get; set; }

        [Parameter]
        public int IdOfBook { get; set; }

        public BookAuthorView BookAuthor { get; set; } = new();

        public BookAuthor BookAuthorDB { get; set; } = new();

        public string NameOfAuthor { get; set; }

        public string TitleOfBook { get; set; }

        protected ConfirmDelete DeleteConfirmation { get; set; }

        protected async override Task OnInitializedAsync()
        {
            BookAuthorDB = await BookAuthorService.GetById(IdOfAuthor, IdOfBook);

            NameOfAuthor = BookAuthorDB.Author.FullName;
            TitleOfBook = BookAuthorDB.Book.Title;

            Mapper.Map(BookAuthorDB, BookAuthor);
        }

        protected void DeleteClick()
        {
            DeleteConfirmation.Show();
        }

        protected async Task DeleteBookAuthor(bool deleteConfirmed)
        {
            Mapper.Map(BookAuthor, BookAuthorDB);

            if (deleteConfirmed)
            {
                await BookAuthorService.DeleteEntity(IdOfAuthor, IdOfBook);
            }

            NavigationManager.NavigateTo("bookList");
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("bookList");
        }

    }
}
