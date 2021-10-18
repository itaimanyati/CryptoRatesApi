using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoRates.Controllers
{
    public class CMC_RatesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
