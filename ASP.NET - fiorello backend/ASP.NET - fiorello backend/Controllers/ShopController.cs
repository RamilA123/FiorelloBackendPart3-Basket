using ASP.NET___fiorello_backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.NET___fiorello_backend.Models;
using ASP.NET___fiorello_backend.ViewModels;
using Newtonsoft.Json;
using NuGet.ContentModel;

namespace ASP.NET___fiorello_backend.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public ShopController(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;

        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _context.Products.Include(m => m.Images).Take(4).ToListAsync();
            int count = await _context.Products.Where(m => !m.SoftDelete).CountAsync();
            ViewBag.count = count;
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> ShowMoreOrLess(int skip)
        {
            IEnumerable<Product> products = await _context.Products.Include(m =>m.Images).Skip(skip).Take(4).ToListAsync();
            return PartialView("_ProductsPartial", products);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int? id)
        {
            if (id == null) return BadRequest();
            Product product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            List<BasketVM> basket = GetBasketDatas();
            AddProductToBasket(basket,product);
            return RedirectToAction(nameof(Index));
        }

        private List<BasketVM> GetBasketDatas()
        {
            List<BasketVM> basket;

            if (_contextAccessor.HttpContext.Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(_contextAccessor.HttpContext.Request.Cookies["basket"]);
            }
            else
            {
                basket = new List<BasketVM>();
            }

            return basket;
        }

        private void AddProductToBasket(List<BasketVM> basket, Product product )
        {

            var existedProduct = basket.FirstOrDefault(m => m.Id == product.Id);
            if (existedProduct == null)
            {
                basket.Add(new BasketVM
                {
                    Id = product.Id,
                    Count = 1
                } );
            }
            else
            {
                existedProduct.Count++;
            }

            _contextAccessor.HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));
        }


    }
}
