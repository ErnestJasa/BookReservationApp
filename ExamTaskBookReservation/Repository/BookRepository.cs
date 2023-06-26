using ExamTaskBookReservation.Areas.Identity.Data;
using ExamTaskBookReservation.Interfaces;
using ExamTaskBookReservation.Models.Domain;
using ExamTaskBookReservation.Models.ViewModels.BookViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTaskBookReservation.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddBook(CreateBookVM book)
        {
            using var memoryStream = new MemoryStream();
            await book.BookImage.CopyToAsync(memoryStream);
            var imageByteData = memoryStream.ToArray();
            //string imageBase64Data = Convert.ToBase64String(imageByteData);
            //string imageDataUrl = string.Format("data:image/png;base64,{0}", imageBase64Data);
            var newBook = new Book
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                ISBN = book.ISBN,
                PageCount = book.PageCount,
                BookImage = imageByteData,
                IsReserved = false,
                CategoryId = book.CategoryId,
            };

            _context.Books.Add(newBook);
            return Save();
        }

        public async Task<bool> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            return Save();
        }

        public async Task<BookVM> GetBookById(int id)
        {
            var book = await _context.Books.Include(x => x.Category).FirstOrDefaultAsync(x => x.BookId == id);
            BookVM bookVM = new BookVM
            {
                BookId = book.BookId,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                ISBN = book.ISBN,
                PageCount = book.PageCount,
                IsReserved = book.IsReserved,
                ReserveeId = book.ReserveeId,
                Reservee = book.Reservee,
                CategoryId = book.CategoryId,
                Category = book.Category,

            };
            if (book.BookImage is not null)
            {
                string imageBase64Data = Convert.ToBase64String(book.BookImage);
                bookVM.BookImage = string.Format("data:image/png;base64,{0}", imageBase64Data);
            }
            return bookVM;
        }

        public async Task<IEnumerable<BookVM>> GetBooks(string searchString)
        {
            IQueryable<Book> books = from b in _context.Books
                                     select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(x => x.Title.Contains(searchString) || x.Description.Contains(searchString) || x.Author.Contains(searchString));
            }
            await books.Include(x => x.Category).ToListAsync();
            List<BookVM> bookVMs = new List<BookVM>();
            foreach (var book in books)
            {
                BookVM bookVM = new BookVM
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    ISBN = book.ISBN,
                    PageCount = book.PageCount,
                    IsReserved = book.IsReserved,
                    ReserveeId = book.ReserveeId,
                    Reservee = book.Reservee,
                    CategoryId = book.CategoryId,
                    Category = book.Category,

                };
                if (book.BookImage is not null)
                {
                    string imageBase64Data = Convert.ToBase64String(book.BookImage);
                    bookVM.BookImage = string.Format("data:image/png;base64,{0}", imageBase64Data);
                }
                bookVMs.Add(bookVM);
            }
            return bookVMs;
        }


        public async Task<bool> UpdateBook(int id,EditBookVM bookVM)
        {
            var book = await GetBookUnconverted(id);
            if (book is not null)
            {
                book.Title = bookVM.Title;
                book.Author = bookVM.Author;
                book.Description = bookVM.Description;
                book.ISBN = bookVM.ISBN;
                book.PageCount = bookVM.PageCount;
                book.CategoryId = bookVM.CategoryId;
                if (bookVM.BookImage is not null)
                {
                    using var memoryStream = new MemoryStream();
                    await bookVM.BookImage.CopyToAsync(memoryStream);
                    var imageByteData = memoryStream.ToArray();                
                    book.BookImage = imageByteData;
                }
            }
           

            _context.Update(book);
            return Save();
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }
        private bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        private async Task<Book> GetBookUnconverted(int id)
        {
            return await _context.Books.FindAsync(id);
        }

    }
}
