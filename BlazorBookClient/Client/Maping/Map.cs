using AutoMapper;
using BlazorBookClient.Client.ViewModels;
using BlazorBookClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBookClient.Client.Maping
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<Author, AuthorView>().ReverseMap();
            CreateMap<Book, BookView>().ReverseMap();
            CreateMap<BookAuthor, BookAuthorView>().ReverseMap();
            CreateMap<Category, CategoryView>().ReverseMap();
            CreateMap<Publisherr, PublisherView>().ReverseMap();
        }
    }
}
