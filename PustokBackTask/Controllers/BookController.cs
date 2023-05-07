using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokBackTask.DAL;
using PustokBackTask.Models;

namespace PustokBackTask.Controllers
{
    public class BookController : Controller
    {
        private readonly DataContext _context;
        public BookController(DataContext context)
        {
            _context = context;
        }
        public IActionResult BookDetail(int id)
        {
            Book book =_context.Books.Include(x=>x.Author).Include(x=>x.BookImages).FirstOrDefault(x=>x.Id==id);

            return PartialView("_BookModalPartial",book);
        }
    }
}
