using Microsoft.AspNetCore.Mvc;
using PustokBackTask.DAL;
using PustokBackTask.Models;
using PustokBackTask.ViewModels;

namespace PustokBackTask.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SliderController : Controller
    {
        private readonly DataContext _context;
        public SliderController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            var query = _context.Sliders;
            return View(PaginatedList<Slider>.Create(query,page,3));
        }
    }
}
