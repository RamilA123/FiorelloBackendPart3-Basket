using ASP.NET___fiorello_backend.Data;
using ASP.NET___fiorello_backend.Models;
using ASP.NET___fiorello_backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET___fiorello_backend.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Expert> experts = await _context.Experts.Include(m => m.Position).Skip(2).Take(2).ToListAsync();

            ContactVM model = new()
            {
                Experts = experts
            };
            
            return View(model);
        }
    }
}


