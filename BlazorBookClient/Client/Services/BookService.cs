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
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/books";

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Book> AddEntity(Book newEntity)
        {
            return await _httpClient.PostJsonAsync<Book>(_baseUrl, newEntity);
        }

        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _httpClient.GetJsonAsync<Book[]>(_baseUrl);
        }

        public async Task<Book> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<Book>($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Book>> Search(string searchKey)
        {
            return await _httpClient.GetJsonAsync<Book[]>($"{_baseUrl}/search/{searchKey}");
        }

        public async Task<Book> UpdateEntity(Book updatedEntity)
        {
            return await _httpClient.PutJsonAsync<Book>($"{_baseUrl}/{updatedEntity.BookID}", updatedEntity);
        }
    }
}
