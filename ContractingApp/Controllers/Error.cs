using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractingApp.Controllers
{
    public class Error : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
