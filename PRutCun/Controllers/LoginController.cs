using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PRutCun.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace PRutCun.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
