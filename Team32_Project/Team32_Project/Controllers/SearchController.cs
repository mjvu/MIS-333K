using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Team32_Project.DAL;
using Team32_Project.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Team32_Project.Controllers
{
    public class SearchController : Controller
    {
        private AppDbContext _db;

        public SearchController(AppDbContext context)
        {
            _db = context;
        }

        //public IActionResult Details(int? id)
        //{
        //    if (id == null) //Repo id not specified
        //    {
        //        return View("Error", new String[] { "Repository ID not specified - which repo do you want to view?" });
        //    }

        //    Repository repo = _db.Repositories.Include(r => r.Language).FirstOrDefault(r => r.RepositoryID == id);

        //    if (repo == null) //Repo does not exist in database
        //    {
        //        return View("Error", new String[] { "Repository not found in database" });
        //    }

        //    //if code gets this far, all is well
        //    return View(repo);
        //}

        public ActionResult DetailedSearch()
        {
            return View("DetailedSearch");
        }

        public ActionResult DisplaySearchResults(String strSearchTitle, String strSearchAuthor, String strSearchNumber,
                                                    String strSearchGenre)
        {
            List<Book> SelectedBooks = new List<Book>();

            var query = from r in _db.Books
                        select r;

            ////TODO: Code for name searching
            //if (SearchString != null && SearchString != "")
            //{
            //    query = query.Where(r => r.UserName.Contains(SearchString) ||
            //                                r.RepositoryName.Contains(SearchString));
            //}

            ////TODO: Code for description searching (textbox contains a string)
            //if (SearchDescription != null && SearchDescription != "")
            //{
            //    query = query.Where(r => r.Description.Contains(SearchDescription));
            //}

            ////TODO: Code for drop-down list
            //if (SelectedLanguage != 0)
            //{
            //    query = query.Where(r => r.Language.LanguageID == SelectedLanguage);
            //}

            ////TODO: Code for star searching (textbox contains a string)
            ////Convert string into decimal
            //Decimal SearchStars = Convert.ToDecimal(DesiredStars);
            //if (DesiredStars != null)
            //{
            //    //TODO: More code for radio buttons (must pick one)
            //    //Figure out sort order
            //    if (SelectedSortOrder == SortOrder.GreaterThan)
            //    {
            //        query = query.Where(r => r.StarCount >= SearchStars);
            //    }
            //    else if (SelectedSortOrder == SortOrder.LessThan)
            //    {
            //        query = query.Where(r => r.StarCount <= SearchStars);
            //    }
            //}

            ////TODO: Code for date picker
            ////Determine suggested date
            //if (datSelectedDate != null)
            //{
            //    //convert date to non-nullable type.  ?? means if the 
            //    //datSelectedDate is null, set it equal to Jan 1, 1900
            //    DateTime datSelected = datSelectedDate ?? new DateTime(1900, 1, 1);

            //    query = query.Where(r => r.LastUpdate >= datSelected);
            //}

            //ViewBag.TotalBooks = _db.Books.Count();
            //ViewBag.SelectedBooks = SelectedBooks.Count();

            ///send all this stuff to the view
            //return View("Index", SelectedBooks);
        }
    }
}
