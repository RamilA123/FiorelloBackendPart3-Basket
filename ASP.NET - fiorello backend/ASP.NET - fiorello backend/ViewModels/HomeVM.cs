using ASP.NET___fiorello_backend.Models;

namespace ASP.NET___fiorello_backend.ViewModels
{
    public class HomeVM
    {
        public SliderInfo SliderInfo { get; set; }
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Expert> Experts { get; set; }
    }

}
