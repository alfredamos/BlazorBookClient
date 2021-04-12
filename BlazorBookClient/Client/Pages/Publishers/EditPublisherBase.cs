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
    public class EditPublisherBase : ComponentBase
    {
        [Inject]
        public IPublisherService PublisherService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        public PublisherView Publisher { get; set; } = new PublisherView();

        public Publisherr PublisherDB { get; set; } = new Publisherr();

        protected async override Task OnInitializedAsync()
        {
            PublisherDB = await PublisherService.GetById(Id);

            Mapper.Map(PublisherDB, Publisher);
        }

        protected async Task UpdatePublisher()
        {
            Mapper.Map(Publisher, PublisherDB);

            var publisher = await PublisherService.UpdateEntity(PublisherDB);

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
