using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Quiz.Models;

namespace Online_Quiz.Controllers
{
    [Authorize]
    public class CreateController : Controller
    {

        
        private readonly IPaperRepository _paperRepository;
        
        public CreateController(IPaperRepository paperRepository)
        {
            _paperRepository = paperRepository;
        }

        public String characters = "abcdeCDEfghijkzMABFHIJKLNOlmnopqrPQRSTstuvwxyUVWXYZ";

        public string UniqueNumber()
        {
            Random unique1 = new Random();
            string s = "";
            int unique;
            int n = 0;
            while (n < 10)
            {
                if (n % 2 == 0)
                {
                    s += unique1.Next(10).ToString();

                }
                else
                {
                    unique = unique1.Next(52);
                    if (unique < this.characters.Length)
                        s = String.Concat(s, this.characters[unique]);
                }
              
                n++;
            }
            return s;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            //Paper paper = new Paper();
            //paper.PaperName = "Maths";
            //_paperRepository.Add(paper);
            //ViewModel viewModel = new ViewModel();
            //viewModel.Papers = _paperRepository.GetAllPapers();
            //viewModel.Questions = _paperRepository.GetAllQuestions();
            //viewModel.Options = _paperRepository.GetAllOptions();
            //viewModel.AttendeeQuestions = _paperRepository.GetAllAttendeeQuestions();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Paper paper)
        {
            if (ModelState.IsValid)
            {
                
                paper.Owner = User.Identity.Name;
                paper.PaperCode = UniqueNumber();
                _paperRepository.AddPaper(paper);
                _paperRepository.SendMailForPaper(paper.PaperCode, paper.Pmarks,paper.PaperName, paper.StartDate, paper.EndDate, paper.Owner);
                // return Json(paper);
                TempData["Success"] = "success";
              
                    return RedirectToAction(nameof(ShowPaper));
            }
        // return Json(paper);
            return View(paper);
        }
        //JsonResult
        //IActionResult
        public IActionResult ShowPaper()
        {
            var paper = _paperRepository.GetAllPapers().Where(m=>m.Owner==User.Identity.Name);

         //  System.Diagnostics.Debug.Print("data"+TempData["Success"].ToString());
            if (paper == null)
            {
                return RedirectToAction(nameof(NoPaper));
            } 
           
                                                                                                                                                                                            
            //return Json(paper.GetType());
            //return Json(paper);
             return View(paper);
        }

        public IActionResult ShowPaperDetail(int? id)
        {
            var paper = _paperRepository.GetAllPapers().FirstOrDefault(m => m.PaperId == id);
            if (paper == null)
            {
                return NotFound();
            }
            return View(paper);
        }  
        
        public IActionResult DeletePaper(int id)
        {
            if (ModelState.IsValid)
            {
                TempData["Success"] = "";
                var paper = _paperRepository.DeletePaper(id);
                TempData["Delete"] = "delete";
                return RedirectToAction(nameof(ShowPaper));
            }
            return View();
        }

        public IActionResult NoPaper()
        {
            return View();
        }
    }
}
