using ASP.NET___fiorello_backend.Data;
using Microsoft.AspNetCore.Mvc;
using ASP.NET___fiorello_backend.ViewModels;
using Newtonsoft.Json;
using NuGet.ContentModel;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET___fiorello_backend.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public CartController(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;

        }
        public async Task<IActionResult> Index()
        {
            List<BasketDetailVM> basketList = new();
            if (_contextAccessor.HttpContext.Request.Cookies["basket"] != null)
            {
                List<BasketVM> basketDatas = JsonConvert.DeserializeObject<List<BasketVM>>(_contextAccessor.HttpContext.Request.Cookies["basket"]);
                foreach (var data in basketDatas)
                {
                    var dbProduct = await _context.Products.Include(m => m.Images).FirstOrDefaultAsync(m => m.Id == data.Id);
                    if (dbProduct != null)
                    {
                        BasketDetailVM basketDetail = new()
                        {
                            Id = dbProduct.Id,
                            Name = dbProduct.Name,
                            Image = dbProduct.Images.Where(m => m.IsMain).FirstOrDefault().Image,
                            Count = data.Count,
                            Price = dbProduct.Price,
                            TotalPrice = data.Count * dbProduct.Price
                        };
                        basketList.Add(basketDetail);
                    }
                   
                }
            }

            return View(basketList);
        }
    }
}
