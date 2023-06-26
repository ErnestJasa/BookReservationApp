using ExamTaskBookReservation.Areas.Identity.Data;
using ExamTaskBookReservation.Models.Domain;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamTaskBookReservation.Models.ViewModels.BookViewModels
{
    public class CreateBookVM
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public int PageCount { get; set; }
        public IFormFile BookImage { get; set; }
        public int CategoryId { get; set; }
    }
}
