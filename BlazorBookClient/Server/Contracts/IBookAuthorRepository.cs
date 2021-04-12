using BlazorBookClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBookClient.Server.Contracts
{
    public interface IBookAuthorRepository : IBaseRepository<BookAuthor>
    {
        Task<BookAuthor> GetById(int idOfAuthor, int idOfBook);
        Task<BookAuthor> DeleteEntity(int idOfAuthor, int idOfBook);
    }
}
