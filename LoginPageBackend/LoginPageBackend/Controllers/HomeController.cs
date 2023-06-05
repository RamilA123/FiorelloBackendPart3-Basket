using LoginPageBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Diagnostics;

namespace LoginPageBackend.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            //Book book = new()
            //{
            //    Id = 1,
            //    Name = "Iskendername",
            //    Author = "Nizami"
            //};


            //var serializedObject = JsonSerializer.Serialize(book);
            //HttpContext.Session.SetString("book", serializedObject);

            ////HttpContext.Session.SetInt32("age", 20);
            //HttpContext.Session.SetString("name", "Ramil");
            //HttpContext.Session.SetString("surname", "Allahverdiyev");
            //HttpContext.Session.SetString("address", "Azadliq");

            //HttpContext.Response.Cookies.Append("phoneNumber", "050-878-12-18");
            //HttpContext.Response.Cookies.Append("email", "ramil78@gmail.com");
            //HttpContext.Response.Cookies.Append("status", "married", new CookieOptions { MaxAge = TimeSpan.FromMinutes(20)} );

            if (HttpContext.Session.GetString("user") != null)
            {
                User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
                ViewBag.username = user.Username;
            }

            return View();
        }

        public IActionResult Privacy()
        {
            //var model = JsonSerializer.Deserialize<Book>(HttpContext.Session.GetString("book"));
            ////ViewBag.age = HttpContext.Session.GetInt32("age");
            ////ViewBag.name = HttpContext.Session.GetString("name");
            ////ViewBag.surname = HttpContext.Session.GetString("surname");
            ////ViewBag.address = HttpContext.Session.GetString("address");
            ////ViewBag.status = HttpContext.Request.Cookies["status"];
            //ViewBag.phoneNumber = HttpContext.Request.Cookies["phoneNumber"];
            ////ViewBag.email = HttpContext.Request.Cookies["email"];
            return View();
        }

    }

    //class Book
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Author { get; set; }
    //}

}

