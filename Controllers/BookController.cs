using Microsoft.AspNetCore.Mvc;
using MVCBookMgtSystem.DataContext;
using MVCBookMgtSystem.Models;
using MVCBookMgtSystem.Models.Domain;

namespace MVCBookMgtSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDbContext dbContext;

        public BookController(BookDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var book = dbContext.Books.ToList();

            return View(book);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddViewModels addBook)
        {
            var book = new Book()
            {
                Title = addBook.Title,
                Author = addBook.Author,
                Publisher = addBook.Publisher,
                YearPublished = addBook.YearPublished
            };

            dbContext.Books.Add(book);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(Guid id)
        {
            var book = dbContext.Books.FirstOrDefault(x => x.BookId == id);

            if (book != null)
            {
                var updateModel = new UpdateViewModels()
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    Author = book.Author,
                    Publisher = book.Publisher,
                    YearPublished = book.YearPublished

                };
                return View(updateModel);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(UpdateViewModels models)
        {
            var book = dbContext.Books.Find(models.BookId);

            if (book != null)
            {
                book.BookId = models.BookId;
                book.Title = models.Title;
                book.Author = models.Author;
                book.Publisher = models.Publisher;
                book.YearPublished = book.YearPublished;

                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(UpdateViewModels model)
        {
            var bookToDelete = dbContext.Books.Find(model.BookId);

            if (bookToDelete != null)
            {
                dbContext.Books.Remove(bookToDelete);
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }         
    }

}
