using AutoMapper;
using BlazorBookClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBookClient.Server.Mappings
{
    public class Mapp : Profile
    {
        public Mapp()
        {
            CreateMap<Author, Author>();
            CreateMap<Book, Book>();
            CreateMap<Category, Category>();
            CreateMap<Publisherr, Publisherr>();
        }
    }
}
