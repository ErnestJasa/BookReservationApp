using ExamTaskBookReservation.Interfaces;
using ExamTaskBookReservation.Models.ViewModels.BookViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExamTaskBookReservation.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var books = await _bookRepository.GetBooks(searchString);
            return View(books);
        }

        public async Task<IActionResult> Detail(int id)
        {
            BookVM book = await _bookRepository.GetBookById(id);
            return View(book);
        }

        public async Task<IActionResult> Add()
        {
            ViewBag.Categories = await _bookRepository.GetCategories();
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Add(CreateBookVM bookVM)
        {
            ViewBag.Categories = await _bookRepository.GetCategories();
            if (ModelState.IsValid)
            {
                await _bookRepository.AddBook(bookVM);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(bookVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categories = await _bookRepository.GetCategories();
            var book = await _bookRepository.GetBookById(id);
            if (book is null)
            {
                return View("Error");
            }
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditBookVM bookVM)
        {
            ViewBag.Categories = await _bookRepository.GetCategories();
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit book");
                return View("Edit", bookVM);
            }


            if (await _bookRepository.UpdateBook(id, bookVM))
            {

                return RedirectToAction("Index");
            }
            else
            {
                return View(await _bookRepository.GetBookById(id));
            }
        }
    }
}
