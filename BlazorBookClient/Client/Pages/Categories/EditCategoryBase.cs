using AutoMapper;
using BlazorBookClient.Client.Contracts;
using BlazorBookClient.Client.ViewModels;
using BlazorBookClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBookClient.Client.Pages.Categories
{
    public class EditCategoryBase : ComponentBase
    {
        [Inject]
        public ICategoryService CategoryService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        public CategoryView Category { get; set; } = new CategoryView();

        public Category CategoryDB { get; set; } = new Category();

        protected async override Task OnInitializedAsync()
        {
            CategoryDB = await CategoryService.GetById(Id);

            Mapper.Map(CategoryDB, Category);
        }

        protected async Task UpdateCategory()
        {
            Mapper.Map(Category, CategoryDB);

            var category = await CategoryService.UpdateEntity(CategoryDB);

            if (category != null)
            {
                NavigationManager.NavigateTo("categoryList");
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("categoryList");
        }
    }
}
