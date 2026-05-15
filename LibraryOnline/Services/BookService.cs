using LibraryOnline.Models;
using LibraryOnline.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryOnline.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<List<Book>> SearchBooksAsync(string searchTerm);
        Task AddBookAsync(Book book);
    }

    public class BookService : IBookService
    {
        private readonly LibraryContext _context;

        public BookService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        // ГИБКИЙ ПОИСК (как я объяснял ранее)
        public async Task<List<Book>> SearchBooksAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetAllBooksAsync();
            }

            string term = searchTerm.ToLower();
            
            return await _context.Books
                .Where(b => b.Title.ToLower().Contains(term) ||
                            b.Author.ToLower().Contains(term) ||
                            b.Genre.ToLower().Contains(term))
                .ToListAsync();
        }

        public async Task AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }
    }
}