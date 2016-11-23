using Library.Filters;
using Library.Services;
using Library.Services.Interfaces;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private IGenreService genreService;
        private IBookService bookService;

        public BooksController()
        {
            this.genreService = new GenreService();
            this.bookService = new BookService();
        }

        public BooksController(IGenreService genreService, IBookService bookService)
        {
            this.genreService = genreService;
            this.bookService = bookService;
        }

        [IsAuthenticated]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [IsAuthenticated]
        [HttpGet]
        public ActionResult Search(int pageNumber = 0, string name = "", int? fromPages = null, int? toPages = null, string genre = "")
        {
            var books = this.bookService.Search(name, fromPages, toPages, genre, pageNumber)
                .Select(x => new BookViewModel
                {
                    CreationYear = x.CreationDate.Year,
                    Genre = x.Genre.Name,
                    ImageUrl = x.ImageUrl,
                    Name = x.Name,
                    PageCount = x.PageCount
                });
            return Json(books, JsonRequestBehavior.AllowGet);
        }

        [IsAuthenticated]
        [HttpGet]
        public ActionResult Genres()
        {
            return Json(this.genreService.GetAll().Select(x => x.Name), JsonRequestBehavior.AllowGet);
        }

        [IsAuthenticated]
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new BookCreateViewModel
            {
                Genres = this.genreService.GetAll()
                    .Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }).ToList()
            };
            return View(viewModel);
        }

        [IsAuthenticated]
        [HttpPost]
        public ActionResult Create(BookCreateViewModel viewModel)
        {
            viewModel.Genres = this.genreService.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var fileName = Path.GetFileName(viewModel.Image.FileName);
            var ext = Path.GetExtension(viewModel.Image.FileName);
            string name = Path.GetFileNameWithoutExtension(fileName);

            string myfile = name + "_" + DateTime.Now.ToFileTimeUtc() + ext;
            var path = Path.Combine(HttpContext.Server.MapPath("~/Img"), myfile);

            this.bookService.Add(new Models.Book
            {
                CreationDate = new DateTime(viewModel.CreationYear, 1, 1),
                GenreId = viewModel.GenreId,
                ImageUrl = "Img/" + myfile,
                Name = viewModel.Name,
                PageCount = viewModel.PageCount
            });

            viewModel.Image.SaveAs(path);

            return RedirectToAction("Index");
        }
    }
}