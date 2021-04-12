using AutoMapper;
using BlazorBookClient.Client.Contracts;
using BlazorBookClient.Client.ViewModels;
using BlazorBookClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBookClient.Client.Pages.Publishers
{
    public class AddPublisherBase : ComponentBase
    {
        [Inject]
        public IPublisherService PublisherService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public PublisherView Publisher { get; set; } = new PublisherView();

        public Publisherr PublisherDB { get; set; } = new Publisherr();

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        protected async Task CreatePublisher()
        {
            Mapper.Map(Publisher, PublisherDB);

            var publisher = await PublisherService.AddEntity(PublisherDB);

            if (publisher != null)
            {
                NavigationManager.NavigateTo("publisherList");
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("publisherList");
        }
    }
}
