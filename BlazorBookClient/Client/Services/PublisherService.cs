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
    public class PublisherService : IPublisherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/publishers";

        public PublisherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Publisherr> AddEntity(Publisherr newEntity)
        {
            return await _httpClient.PostJsonAsync<Publisherr>(_baseUrl, newEntity);
        }

        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Publisherr>> GetAll()
        {
            return await _httpClient.GetJsonAsync<Publisherr[]>(_baseUrl);
        }

        public async Task<Publisherr> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<Publisherr>($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Publisherr>> Search(string searchKey)
        {
            return await _httpClient.GetJsonAsync<Publisherr[]>($"{_baseUrl}/search/{searchKey}");
        }

        public async Task<Publisherr> UpdateEntity(Publisherr updatedEntity)
        {
            return await _httpClient.PutJsonAsync<Publisherr>($"{_baseUrl}/{updatedEntity.PublisherID}", updatedEntity);
        }
    }
}
