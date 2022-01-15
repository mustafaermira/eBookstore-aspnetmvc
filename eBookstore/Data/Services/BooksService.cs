using eBookstore.Data.Base;
using eBookstore.Data.ViewModels;
using eBookstore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Data.Services
{
    public class BooksService : EntityBaseRepository<Book>, IBooksService
    {
        private readonly AppDbContext _context;
        public BooksService(AppDbContext context): base(context)
        {
            _context = context;
        }

        public async Task AddNewBookAsync(NewBookVM data)
        {
            var newBook = new Book()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                ReleaseDate = data.ReleaseDate,
                WriterId = data.WriterId,
                GenresId = data.GenresId
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            //Add Bookstores
            foreach (var bookstoreId in data.BookstoreIds)
            {
                var newBookstoreBook = new Bookstore_Book()
                {
                    BookId = newBook.Id,
                    BookstoreId = bookstoreId
                };
                await _context.Bookstores_Books.AddAsync(newBookstoreBook);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var bookDetails =await _context.Books
                .Include(g => g.Genres)
                .Include(w => w.Writers)
                .Include(bb => bb.Bookstores_Books).ThenInclude(b => b.Bookstore)
                .FirstOrDefaultAsync(n => n.Id == id);
            return bookDetails;
        }

        public async Task<NewBookDropdownVM> GetNewBookDropdownsValues()
        {
            var response = new NewBookDropdownVM() 
            {
                Bookstores = await _context.Bookstores.OrderBy(n => n.Name).ToListAsync(),
                Genres = await _context.Genres.OrderBy(n => n.GenreName).ToListAsync(),
                Writers = await _context.Writers.OrderBy(n => n.Name).ToListAsync()
            };
            

            return response;

        }

        public async Task UpdateBookAsync(NewBookVM data)
        {
            var dbBook = await _context.Books.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbBook !=null)
            {

                dbBook.Name = data.Name;
                dbBook.Description = data.Description;
                dbBook.Price = data.Price;
                dbBook.ImageURL = data.ImageURL;
                dbBook.ReleaseDate = data.ReleaseDate;
                dbBook.WriterId = data.WriterId;
                dbBook.GenresId = data.GenresId;

                await _context.SaveChangesAsync();
            }

            //Remove existing books
            var existingBookstoresDb = _context.Bookstores_Books.Where(n => n.BookId == data.Id).ToList();
            _context.Bookstores_Books.RemoveRange(existingBookstoresDb);
            await _context.SaveChangesAsync();
            
            

            //Add Bookstores
            foreach (var bookstoreId in data.BookstoreIds)
            {
                var newBookstoreBook = new Bookstore_Book()
                {
                    BookId = data.Id,
                    BookstoreId = bookstoreId
                };
                await _context.Bookstores_Books.AddAsync(newBookstoreBook);
            }
            await _context.SaveChangesAsync();
        }
    }
}
