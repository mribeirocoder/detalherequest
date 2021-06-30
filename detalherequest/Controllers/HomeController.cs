using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using detalherequest.Models;
using Microsoft.AspNetCore.Http.Features;

namespace detalherequest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var request = HttpContext.Request;
            var httpRequestFeature = HttpContext.Features.Get<IHttpRequestFeature>();
            var rawTarget = httpRequestFeature.RawTarget; // RawTarget returns original path and querystring

            ViewBag.OriginalUrl = rawTarget;
            ViewBag.Protocol = HttpContext.Request.Protocol;
            ViewBag.RemoteIpAddress = HttpContext.Connection.RemoteIpAddress;
            ViewBag.LocalIpAddress = HttpContext.Connection.LocalIpAddress;
            ViewBag.Headers = Request.Headers;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
