using Microsoft.AspNetCore.Http;

namespace ExamTaskBookReservation.Models.ViewModels.BookViewModels
{
    public class EditBookVM
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public int PageCount { get; set; }
        public IFormFile? BookImage { get; set; }
        public int CategoryId { get; set; }
    }
}
