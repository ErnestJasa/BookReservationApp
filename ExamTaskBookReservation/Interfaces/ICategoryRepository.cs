using ExamTaskBookReservation.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamTaskBookReservation.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        bool AddCategory(Category category);
        Task<bool> UpdateCategory(int id,Category category);
        Task<bool> DeleteCategory(int id);

    }
}
