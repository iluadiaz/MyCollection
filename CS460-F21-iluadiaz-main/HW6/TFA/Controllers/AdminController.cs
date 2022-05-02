using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFA.Areas.Identity.Data;
using TFA.Models;
using Microsoft.AspNetCore.Authorization;

namespace TFA.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly TFAIdentityDbContext _context;

        public AdminController(TFAIdentityDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

      
    }
}