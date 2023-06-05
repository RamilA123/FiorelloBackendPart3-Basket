using Microsoft.AspNetCore.Mvc;
using ASP.NET___fiorello_backend.Models;
using ASP.NET___fiorello_backend.Data;
using Microsoft.EntityFrameworkCore;
using ASP.NET___fiorello_backend.Areas.Admin.ViewModels;

namespace ASP.NET___fiorello_backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;

        public SliderController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SliderVM> sliderList = new List<SliderVM>();
            IEnumerable<Slider> sliders = await _context.Sliders.ToListAsync();
            foreach (Slider slider in sliders)
            {
                SliderVM sliderVM = new()
                {
                    Id = slider.Id,
                    Image = slider.Image,
                    CreateDate = slider.CreatedDate.ToString("MMMM dd, yyyy"),
                    Status = slider.Status,
                };

                sliderList.Add(sliderVM);
            }


            return View(sliderList);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);
            if (slider is null) return NotFound();
            SliderDetailVM sliderDetail = new()
            {
                Image = slider.Image,
                CreateDate = slider.CreatedDate.ToString("MMMM dd, yyyy"),
                Status = slider.Status,
            };

            return View(sliderDetail);
        }
    }
}
