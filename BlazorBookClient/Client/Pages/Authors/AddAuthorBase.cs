using AutoMapper;
using BlazorBookClient.Client.Contracts;
using BlazorBookClient.Client.ViewModels;
using BlazorBookClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBookClient.Client.Pages.Authors
{
    public class AddAuthorBase : ComponentBase
    {
        [Inject]
        public IAuthorService AuthorService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public AuthorView Author { get; set; } = new AuthorView();

        public Author AuthorDB { get; set; } = new Author();
        

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        protected async Task CreateAuthor()
        {
            Mapper.Map(Author, AuthorDB);

            var author = await AuthorService.AddEntity(AuthorDB);

            if (author != null)
            {
                NavigationManager.NavigateTo("authorList");
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("authorList");
        }
    }
}
