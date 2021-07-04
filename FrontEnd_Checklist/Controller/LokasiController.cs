using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd_Checklist.Controller
{

    public class LokasiController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
