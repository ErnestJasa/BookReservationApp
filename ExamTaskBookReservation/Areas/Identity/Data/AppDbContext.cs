using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamTaskBookReservation.Areas.Identity.Data;
using ExamTaskBookReservation.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamTaskBookReservation.Areas.Identity.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Romance"},
                new Category { CategoryId = 2, CategoryName = "Fantasy"},
                new Category { CategoryId = 3, CategoryName = "Fiction"},
                new Category { CategoryId = 4, CategoryName = "History"},
            });
            builder.Entity<Book>().HasData(new List<Book>
            {
                new Book{ BookId = 1, Title = "Practice Makes Perfect", Author = "Sarah Adams", 
                    Description = "Annie Walker is on a quest to find her perfect match-someone who nicely compliments her happy, quiet life running her flower shop in Rome, Kentucky. Unfortunately, she worries her goal might be too far out of reach when she overhears her date saying she is \"sounbelievably boring.\" Is it too late to become flirtatious and fun like the leading ladies in her favorite romance movies? Maybe she only needs a little practice...and Annie has the perfect person in mind to become her tutor: Will Griffin.",
                    ISBN = "0-9136-5757-3", IsReserved = false, PageCount =  350, BookImage = null, CategoryId =  1},
                new Book{ BookId = 2, Title = "A Game of Thrones", Author = "George R. R. Martin", 
                    Description = "Summers span decades. Winter can last a lifetime. And the struggle for the Iron Throne has begun.\r\n\r\nAs Warden of the north, Lord Eddard Stark counts it a curse when King Robert bestows on him the office of the Hand. His honour weighs him down at court where a true man does what he will, not what he must … and a dead enemy is a thing of beauty.",
                    ISBN = "0-9902-8367-4", IsReserved = false, PageCount = 453, BookImage = null, CategoryId =  2},
                new Book{ BookId = 3, Title = "Yellowface", Author = "R.F. Kuang",
                    Description = "Authors June Hayward and Athena Liu were supposed to be twin rising stars: same year at Yale, same debut year in publishing. But Athena's a cross-genre literary darling, and June didn't even get a paperback release. Nobody wants stories about basic white girls, June thinks.",
                    ISBN = "0-9807-5565-4", IsReserved = false, PageCount =  245, BookImage = null, CategoryId =  3},
                new Book{ BookId = 4, Title = "John Adams", Author = "David McCullough",
                    Description = "The enthralling, often surprising story of John Adams, one of the most important and fascinating Americans who ever lived.\r\n",
                    ISBN = "0-8657-9202-X", IsReserved = false, PageCount =  684, BookImage = null, CategoryId =  4},
            });
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ReservedBook> ReservedBooks { get; set; }
    }
}
