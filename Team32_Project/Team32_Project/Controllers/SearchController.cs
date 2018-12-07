using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Team32_Project.DAL;
using Team32_Project.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Team32_Project.Controllers
{
    [AllowAnonymous]
    public class SearchController : Controller
    {
        private AppDbContext _db;

        public SearchController(AppDbContext context)
        {
            _db = context;
        }

        public ActionResult Index()
        {
            List<Book> SelectedBooks = new List<Book>();
            ViewBag.TotalBooks = _db.Books.Count();
            ViewBag.SelectedBooks = ViewBag.TotalBooks;

            return View("Index", _db.Books.Include(b => b.Genre).ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null) //Book id not specified
            {
                return View("Error", new String[] { "Book ID not specified - which book do you want to view?" });
            }

            Book book = _db.Books.Include(b => b.Genre).FirstOrDefault(b => b.BookID == id);

            if (book == null) //Book does not exist in database
            {
                return View("Error", new String[] { "Book not found in database" });
            }

            //if code gets this far, all is well
            return View(book);
        }

        public ActionResult DetailedSearch()
        {
            ViewBag.AllGenres = GetAllGenres();
            return View("DetailedSearch");
        }

        public enum SortOrder { Title, Author, MostPopular, NewestBook, OldestBook, HighestRated, InStock }

        public ActionResult DisplaySearchResults(String SearchTitle, String SearchAuthor, String DesiredNumber,
                                                    int SelectedGenre, SortOrder SelectedSortOrder)
        {
            List<Book> SelectedBooks = new List<Book>();

            var query = from b in _db.Books
                        select b;

            if (SearchTitle != null && SearchTitle != "")
            {
                query = query.Where(b => b.Title.Contains(SearchTitle));
            }

            if (SearchAuthor != null && SearchAuthor != "")
            {
                query = query.Where(b => b.Author.Contains(SearchAuthor));
            }

            //Convert string into decimal
            Decimal SearchNumber = Convert.ToDecimal(DesiredNumber);
            if (DesiredNumber != null)
            {
                query = query.Where(b => b.UniqueID == SearchNumber);
            }

            if (SelectedGenre != 0)
            {
                query = query.Where(b => b.Genre.GenreID == SelectedGenre);
            }

            SelectedBooks = query.Include(b => b.Genre).ToList();

            ViewBag.TotalBooks = _db.Books.Count();
            ViewBag.SelectedBooks = SelectedBooks.Count();

            //Figure out the sort order
            if (SelectedSortOrder == SortOrder.Title)
            {
                return View("Index", SelectedBooks.OrderBy(b => b.Title));
            }
            else if (SelectedSortOrder == SortOrder.Author)
            {
                return View("Index", SelectedBooks.OrderBy(b => b.Author));
            }
            else if (SelectedSortOrder == SortOrder.MostPopular)
            {
                //figure out how to do this
                
            }
            else if (SelectedSortOrder == SortOrder.NewestBook)
            {
                return View("Index", SelectedBooks.OrderByDescending(b => b.PublicationDate));
            }
            else if (SelectedSortOrder == SortOrder.OldestBook)
            {
                return View("Index", SelectedBooks.OrderBy(b => b.PublicationDate));
            }
            else if (SelectedSortOrder == SortOrder.HighestRated)
            {
                return View("Index", SelectedBooks.OrderByDescending(b => b.AverageRating));
            }
            else if (SelectedSortOrder == SortOrder.InStock)
            {
                return View("Index", query = query.Where(b => b.CopiesOnHand > 0));
            }

            //send all this stuff to the view
            return View("Index", SelectedBooks);
        }

        public SelectList GetAllGenres()
        {
            List<Genre> Genres = _db.Genres.ToList();

            //add a record for all languages
            Genre SelectNone = new Genre() { GenreID = 0, GenreName = "All Genres" };
            Genres.Add(SelectNone);

            //convert list to select list
            SelectList AllGenres = new SelectList(Genres.OrderBy(m => m.GenreID), "GenreID", "GenreName");

            //return the select list
            return AllGenres;
        }
    }
}
