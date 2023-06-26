using ExamTaskBookReservation.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamTaskBookReservation.Models.Domain
{
    public class ReservedBook
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Domain.Book.BookId))]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [ForeignKey(nameof(ApplicationUser.Id))]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
