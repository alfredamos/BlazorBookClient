using BlazorBookClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBookClient.Server.Contracts
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
    }
}
