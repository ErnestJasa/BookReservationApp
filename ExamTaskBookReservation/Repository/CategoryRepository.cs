using ExamTaskBookReservation.Areas.Identity.Data;
using ExamTaskBookReservation.Interfaces;
using ExamTaskBookReservation.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamTaskBookReservation.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool AddCategory(Category category)
        {
            _context.Categories.Add(category);
            return Save();
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            return Save();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<bool> UpdateCategory(int id,Category category)
        {
            var dbCategory = await _context.Categories.FindAsync(id);
            dbCategory.CategoryName = category.CategoryName;
            _context.Categories.Update(dbCategory);
            return Save();
        }
        private bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
