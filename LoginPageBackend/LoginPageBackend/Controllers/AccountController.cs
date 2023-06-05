using Microsoft.AspNetCore.Mvc;
using LoginPageBackend.Models;
using LoginPageBackend.ViewModels;
using System.Text.Json;

namespace LoginPageBackend.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM model)
        {
            List<User> dbUsers = GetAllUsers();
            User findUsersByEmail = dbUsers.FirstOrDefault(m => m.Email == model.Email);
            if (findUsersByEmail is null)
            {
                ViewBag.error = "Email or password is wrong";
                return View();
            }

            if (findUsersByEmail.Password != model.Password)
            {
                ViewBag.error = "Email or password is wrong";
                return View();
            }

            var serializedObject = JsonSerializer.Serialize(findUsersByEmail);
            HttpContext.Session.SetString("user", serializedObject);
            return RedirectToAction("Index","Home");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
          HttpContext.Session.Clear();
          return RedirectToAction("Index", "Home");
        }

        private List<User> GetAllUsers()
        {
            User user1 = new()
            {
                Id = 1,
                Username = "ramil123",
                Email = "ramil78@gmail.com",
                Password = "123456"
            };

            User user2 = new()
            {
                Id = 2,
                Username = "selim123",
                Email = "selim78@gmail.com",
                Password = "456456"
            };

            User user3 = new()
            {
                Id = 3,
                Username = "yunis123",
                Email = "yunis78@gmail.com",
                Password = "876556"
            };

            User user4 = new()
            {
                Id = 4,
                Username = "elcan123",
                Email = "elcan78@gmail.com",
                Password = "490456"
            };

            User user5 = new()
            {
                Id = 5,
                Username = "ulfet123",
                Email = "ulfet78@gmail.com",
                Password = "345678"
            };


            List<User> users = new List<User>() { user1, user2, user3, user4, user5 };
            return users;
        }

    }
}
