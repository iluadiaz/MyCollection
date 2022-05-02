using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW4Project.Models;
using System.Drawing;
using Microsoft.AspNetCore.Html;

namespace HW4Project.Controllers
{
    public class RGBColorController : Controller
    {

[HttpGet]
   public IActionResult RGB_Color(RGBModel rgbModel)
        {
            if(!ModelState.IsValid)
            {
                return View("RGB_Color", rgbModel);
            }
             else
            {
            
                return View("RGB_Color", rgbModel);

            }
        }

}
}
 
