using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Newtonsoft.Json;
using PustokBackTask.DAL;
using PustokBackTask.Models;
using PustokBackTask.ViewModels;
using System.Collections.Generic;

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
            Book book =_context.Books
                .Include(x=>x.Author)
                .Include(x=>x.BookImages)
                .Include(x=>x.BookTags).ThenInclude(x=>x.Tag)
                .FirstOrDefault(x=>x.Id==id);

            return PartialView("_BookModalPartial",book);
        }

        public IActionResult AddToBasket(int id) 
        {
            List<BasketViewModel> BasketItems= new List<BasketViewModel>();
            BasketViewModel CookieItem;
            var basketString = Request.Cookies["basket"];
            if (basketString != null)
            {
                BasketItems = JsonConvert.DeserializeObject<List<BasketViewModel>>(basketString);

                CookieItem = BasketItems.FirstOrDefault(x=>x.BookId==id);

                if (CookieItem!=null)
                {
                    CookieItem.BookCount++;
                }
                else
                {
                    CookieItem = new BasketViewModel { BookId=id,BookCount=1};
                    BasketItems.Add(CookieItem);
                }
            }
            else
            {
                CookieItem = new BasketViewModel{BookId = id, BookCount = 1 };
                BasketItems.Add(CookieItem);
            }


            Response.Cookies.Append("Basket", JsonConvert.SerializeObject(BasketItems));
            return Json(new {basket=BasketItems });
        }

       public IActionResult RemoveItemFromBasket(int id)
        {
           var basket= new List<BasketViewModel>();

            var cookiebasket = Request.Cookies["basket"];
            if (cookiebasket != null)
            {
                basket= JsonConvert.DeserializeObject<List<BasketViewModel>>(cookiebasket);
                var updatedbasket=basket?.Where(x=>x.BookId!=id).ToList();
                basket = updatedbasket;
                Response.Cookies.Append("basket",JsonConvert.SerializeObject(basket));
            }
           return Json(new {basket=basket});

            
        }
    }
}
