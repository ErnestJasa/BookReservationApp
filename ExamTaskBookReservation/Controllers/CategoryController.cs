using ExamTaskBookReservation.Interfaces;
using ExamTaskBookReservation.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExamTaskBookReservation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index()
        {
           var categories = await _categoryRepository.GetAllCategories();
            return View(categories);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.AddCategory(category);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Failed to add category");
            }
            return View(category);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,Category category)
        {
            if (ModelState.IsValid)
            {                
                await _categoryRepository.UpdateCategory(id,category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryRepository.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
