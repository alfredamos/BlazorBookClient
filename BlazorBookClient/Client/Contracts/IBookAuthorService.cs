using BlazorBookClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBookClient.Client.Contracts
{
    public interface IBookAuthorService : IBaseService<BookAuthor>
    {
        Task<BookAuthor> GetById(int idOfAuthor, int idOfBook);
        Task DeleteEntity(int idOfAuthor, int idOfBook);
    }
}
