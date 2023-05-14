using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokBackTask.DAL;
using PustokBackTask.Models;
using PustokBackTask.ViewModels;

namespace PustokBackTask.Areas.Manage.Controllers
{
    [Area("manage")]
    public class GenreController : Controller
    {
        private readonly DataContext _context;
        public GenreController(DataContext context)
        {
            _context=context;
        }
        public IActionResult Index(int page=1,string search=null)
        {
            var query = _context.Genres.AsQueryable();
            if (search != null)
            {
                query=query.Where(x=>x.Name.Contains(search));
            }

            ViewBag.Search = search;
            return View(PaginatedList<Genre>.Create(query,page,3));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}
