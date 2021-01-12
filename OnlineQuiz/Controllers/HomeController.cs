using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Online_Quiz.Models;

namespace Online_Quiz.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        
        private readonly IPaperRepository _paperRepository;

        public HomeController(IPaperRepository paperRepository)
        {
            _paperRepository = paperRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //Paper paper = new Paper();
            //paper.PaperName = "Maths";
            //_paperRepository.Add(paper);
            TempData["Success"] = "";
            TempData["Delete"] = "";
            TempData["Submit"] = "";
            TempData["DeleteAnswerSheet"] = "";
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
