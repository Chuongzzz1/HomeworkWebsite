using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoWebsite.Data;
using DemoWebsite.Models;

namespace DemoWebsite.Controllers
{
    public class UsersController : Controller
    {
        private readonly DemoWebsiteContext _context;
        private static int _previousUserId = 0;
        private static Random _random = new Random();

        public UsersController(DemoWebsiteContext context)
        {
            _context = context;
        }

        // GET: Users/Index
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            if (users == null || users.Count == 0)
            {
                return NotFound("No users found.");
            }

            var user = GetRandomUser(users);
            if (user != null)
            {
                _previousUserId = user.Id;
            }

            return View(user);
        }

        // GET: Users/Next
        public async Task<IActionResult> Next()
        {
            var users = await _context.Users.ToListAsync();
            if (users == null || users.Count == 0)
            {
                return NotFound("No users found.");
            }

            var user = GetRandomUser(users);
            if (user != null)
            {
                _previousUserId = user.Id;
            }

            return RedirectToAction(nameof(Index));
        }

        private User GetRandomUser(List<User> users)
        {
            if (users.Count == 1)
            {
                return users.First();
            }

            User user;
            do
            {
                user = users[_random.Next(users.Count)];
            } while (user.Id == _previousUserId);

            return user;
        }
    }
}
