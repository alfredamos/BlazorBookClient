using BlazorBookClient.Client.Contracts;
using BlazorBookClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorBookClient.Client.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/authors";

        public AuthorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Author> AddEntity(Author newEntity)
        {
            return await _httpClient.PostJsonAsync<Author>(_baseUrl, newEntity);
        }

        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _httpClient.GetJsonAsync<Author[]>(_baseUrl);
        }

        public async Task<Author> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<Author>($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Author>> Search(string searchKey)
        {
            return await _httpClient.GetJsonAsync<Author[]>($"{_baseUrl}/search/{searchKey}");
        }

        public async Task<Author> UpdateEntity(Author updatedEntity)
        {
            return await _httpClient.PutJsonAsync<Author>($"{_baseUrl}/{updatedEntity.AuthorID}", updatedEntity);
        }
    }
}
