using BlazorBookClient.Server.Contracts;
using BlazorBookClient.Server.Data;
using BlazorBookClient.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBookClient.Server.SQL
{
    public class SQLBookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public SQLBookRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Book> AddEntity(Book newEntity)
        {
            var book = await _context.Books.AddAsync(newEntity);
            await _context.SaveChangesAsync();

            return book.Entity;
        }

        public async Task<Book> DeleteEntity(int id)
        {
            var bookToDelete = await _context.Books.FindAsync(id);

            if (bookToDelete != null)
            {
                _context.Books.Remove(bookToDelete);
                await _context.SaveChangesAsync();

            }
            return bookToDelete;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.Include(x => x.Category).Include(x => x.BookAuthors)
                                 .ThenInclude(x => x.Author).Include(x => x.Publisher).ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            return await _context.Books.Include(x => x.Category).Include(x => x.BookAuthors)
                                 .ThenInclude(x => x.Author).Include(x => x.Publisher)
                                 .FirstOrDefaultAsync(x => x.BookID == id);
        }

        public async Task<IEnumerable<Book>> Search(string searchKey)
        {
            IQueryable<Book> books = _context.Books;

            if (string.IsNullOrWhiteSpace(searchKey))
            {
                return await books.Include(x => x.BookAuthors)
                            .Include(x => x.Category)
                            .Include(x => x.Publisher)
                            .ToListAsync();
            }

            return await books.Include(x => x.Category)
                              .Include(x => x.Publisher).Include(x => x.BookAuthors)
                              .Where(x => x.Title.Contains(searchKey) ||
                              x.ISBN.Contains(searchKey)).ToListAsync();
        }

        public async Task<Book> UpdateEntity(Book updatedEntity)
        {
            var book = _context.Books.Attach(updatedEntity);
            book.State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return book.Entity;
        }
    }
}
