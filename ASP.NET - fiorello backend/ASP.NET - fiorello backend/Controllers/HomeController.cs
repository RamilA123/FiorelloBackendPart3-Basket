using Microsoft.AspNetCore.Mvc;
using ASP.NET___fiorello_backend.Data;
using ASP.NET___fiorello_backend.Models;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ASP.NET___fiorello_backend.ViewModels;

namespace ASP.NET___fiorello_backend.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            SliderInfo sliderInfo = await _context.SliderInfos.FirstOrDefaultAsync();
            IEnumerable<Slider> sliders = await _context.Sliders.ToListAsync();
            IEnumerable<Blog> blogs = await _context.Blogs.OrderByDescending(m => m.Id).Take(3).ToListAsync();
            IEnumerable<Category> categories = await _context.Categories.ToListAsync();
            IEnumerable<Product> products = await _context.Products.Include(m => m.Images).ToListAsync();
            IEnumerable<Expert> experts = await _context.Experts.Include(m => m.Position).ToListAsync();


            HomeVM model = new()
            {
                SliderInfo = sliderInfo,
                Sliders = sliders,
                Blogs = blogs,
                Categories = categories,
                Products = products,
                Experts = experts
                
            };

            return View(model);
        }
    }
}