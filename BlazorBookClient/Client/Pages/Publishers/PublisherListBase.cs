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
    public class PublisherListBase : ComponentBase
    {
        [Inject]
        public IPublisherService PublisherService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public List<PublisherView> Publishers { get; set; } = new List<PublisherView>();

        public List<Publisherr> PublishersDB { get; set; } = new List<Publisherr>();

        protected async override Task OnInitializedAsync()
        {
            PublishersDB = (await PublisherService.GetAll()).ToList();

            Mapper.Map(PublishersDB, Publishers);
        }


    }
}
