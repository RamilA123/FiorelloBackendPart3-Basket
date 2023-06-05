using ASP.NET___fiorello_backend.Data;
using ASP.NET___fiorello_backend.Models;
using ASP.NET___fiorello_backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET___fiorello_backend.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id is null) return BadRequest();

            Product product = await _context.Products.Include(m => m.Discount).Include(m => m.Images).Include(m => m.Category).FirstOrDefaultAsync(m => m.Id == id);

            if (product == null) return NotFound();

            ProductDetailVM model = new()
            {
                Id = product.Id,
                Name = product.Name,
                CategoryName = product.Category.Name,
                ActualPrice = product.Price,
                DiscountPrice = product.Price - (product.Price * product.Discount.Percent)/100,
                Description = product.Description,
                Percent = product.Discount.Percent,
                Images = product.Images.ToList(),

            };
            
            return View(model);

        }
    }
}
