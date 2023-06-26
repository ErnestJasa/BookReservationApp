using ExamTaskBookReservation.Areas.Identity.Data;
using ExamTaskBookReservation.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamTaskBookReservation.Models.ViewModels.BookViewModels
{
    public class BookVM
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; }
        public string ISBN { get; set; }
        public int PageCount { get; set; }
        public string? BookImage { get; set; }
        public bool IsReserved { get; set; } = false;
        [ForeignKey(nameof(ApplicationUser.Id))]
        public string? ReserveeId { get; set; }
        public ApplicationUser? Reservee { get; set; }
        [ForeignKey(nameof(Domain.Category.CategoryId))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
