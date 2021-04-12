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
    public class BookAuthorService : IBookAuthorService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/bookAuthors";

        public BookAuthorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<BookAuthor> AddEntity(BookAuthor newEntity)
        {
            return await _httpClient.PostJsonAsync<BookAuthor>(_baseUrl, newEntity);
        }

        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task DeleteEntity(int idOfAuthor, int idOfBook)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{idOfAuthor}/{idOfBook}");
        }

        public async Task<IEnumerable<BookAuthor>> GetAll()
        {
            return await _httpClient.GetJsonAsync<BookAuthor[]>(_baseUrl);
        }

        public async Task<BookAuthor> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<BookAuthor>($"{_baseUrl}/{id}");
        }

        public async Task<BookAuthor> GetById(int idOfAuthor, int idOfBook)
        {
            return await _httpClient.GetJsonAsync<BookAuthor>($"{_baseUrl}/{idOfAuthor}/{idOfBook}");
        }

        public async Task<IEnumerable<BookAuthor>> Search(string searchKey)
        {
            return await _httpClient.GetJsonAsync<BookAuthor[]>($"{_baseUrl}/search/{searchKey}");
        }

        public async Task<BookAuthor> UpdateEntity(BookAuthor updatedEntity)
        {
            return await _httpClient.PutJsonAsync<BookAuthor>($"{_baseUrl}/{updatedEntity.AuthorID}/{updatedEntity.BookID}", updatedEntity);
        }
    }
}
