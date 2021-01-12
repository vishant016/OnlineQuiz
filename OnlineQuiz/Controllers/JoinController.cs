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
    public class JoinController : Controller
    {
        private readonly IPaperRepository _paperRepository;

        public JoinController(IPaperRepository paperRepository)
        {
            _paperRepository = paperRepository;
        }
        [HttpGet]
        public IActionResult Join()
        {
            Paper paper = new Paper();
            paper.Owner = User.Identity.Name;
            return View(paper);
        }
        [HttpPost]
        public IActionResult Join(Paper paper)
        {
            var exist = _paperRepository.GetAllPapers().FirstOrDefault(m => m.PaperCode == paper.PaperCode);
            if (exist == null)
            {
                ViewData["NoQuiz"] = "NoQuiz";
                return View();
            }
            if (_paperRepository.isSubmitted(paper.Owner, paper.PaperCode))
            {
                ViewData["Submitted"] = "Submitted";
                return View();
            }    
            
            
            foreach(var question in exist.Questions)
            {
                foreach(var option in question.Options)
                {
                    option.Correct = false;
                }
            }
            if (exist.StartDate < DateTime.Now && exist.EndDate > DateTime.Now)
            {
                ViewData["exist"] = exist;
                //return Json(exist);
               return View(exist);
            }
            else
            {
                // return Json(exist.EndDate);
                ViewData["Finished"] = "Finished";
                return View();
            }
        }



        [HttpPost]
        public IActionResult JoinQuiz(Paper paper)
        {
            //return Json(paper);
            TempData["Submit"] = "submit";
            AnswerSheet answerSheet = _paperRepository.AddAnswerSheet(paper,User.Identity.Name);
            ViewModel mymodel = new ViewModel();
            mymodel.Papers = _paperRepository.GetAllPapers().First(m => m.PaperId == answerSheet.Paper.PaperId);
            mymodel.AnswerSheets =answerSheet;
            mymodel.AnswerSheet_Questions = _paperRepository.GetAllAnswerSheet_Questions().Where(m=>m.AnswerSheetId==answerSheet.AnswerSheetId).ToList();
            _paperRepository.SendMailForAttendee(mymodel.Papers.PaperCode, answerSheet.ObtainedMarks, mymodel.Papers.PaperName, answerSheet.SubmitTime, answerSheet.User);
            return View(mymodel);
            //return View(answerSheet);
        }

        public IActionResult ShowAttendedPaper()
        {
            TempData["Submit"] = "";
            
            var answerSheet = _paperRepository.GetAllAnswerSheets().Where(m => m.User == User.Identity.Name);
            
          


            //return Json(paper.GetType());
            //return Json(paper);
            return View(answerSheet);
        }

        public IActionResult ShowAnswerSheetDetail(int? id)
        {
            var answerSheet = _paperRepository.GetAllAnswerSheets().FirstOrDefault(m => m.AnswerSheetId == id);
            if (answerSheet == null)
            {
               
                return View();
            }
            return View(answerSheet);
        }
        public IActionResult DeleteAnswerSheet(int id)
        {
            if (ModelState.IsValid)
            {
                TempData["Submit"] ="";
                TempData["DeleteAnswerSheet"] = "deleteanswersheet";
                var paper = _paperRepository.DeleteAnswerSheet(id);
                return RedirectToAction(nameof(ShowAttendedPaper));
            }
            return View();
        }
        public IActionResult NoPaper()
        {
            return View();
        }

    }
}
