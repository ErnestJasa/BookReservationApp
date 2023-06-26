using ExamTaskBookReservation.Models.Domain;
using ExamTaskBookReservation.Models.ViewModels.BookViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamTaskBookReservation.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookVM>> GetBooks(string searchString);
        Task<BookVM> GetBookById(int id);
        Task<bool> AddBook(CreateBookVM book);
        Task<bool> UpdateBook(int id,EditBookVM bookVM);
        Task<bool> DeleteBook(int id);
        Task<IEnumerable<Category>> GetCategories();
    }
}
