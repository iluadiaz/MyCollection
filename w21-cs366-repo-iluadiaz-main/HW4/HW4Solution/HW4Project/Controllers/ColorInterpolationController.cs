using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW4Project.Models;

namespace HW4Project.Controllers
{
    public class ColorInterpolationController : Controller
    {        
        [HttpGet]
        public IActionResult color_Interpolation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Color_Interpolation(ColorInterpolationModel model)
        {
        if(!ModelState.IsValid)
            {
                return View("Color_Interpolation", model);
            }
            else
            {
                return View("Color_Interpolation", model);
            }
        }
    }
}