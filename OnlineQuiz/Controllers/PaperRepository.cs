using Microsoft.EntityFrameworkCore;
using Online_Quiz.Data;
using Online_Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Online_Quiz.Controllers
{
    public class PaperRepository : IPaperRepository
    {
        private readonly ApplicationDbContext context;

        public PaperRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Paper AddPaper(Paper paper)
        {
            context.Papers.Add(paper);
            context.SaveChanges();
            return paper;

        }
        public Paper DeletePaper(int id)
        {
            var paper = context.Papers.Find(id);
            var answersheet = context.AnswerSheets.Where(m => m.PaperId == paper.PaperId);
            foreach (var item in answersheet)
            {
                context.AnswerSheets.Remove(item);
            }
            context.Papers.Remove(paper);
            context.SaveChanges();
            return paper;
        }
        public AnswerSheet DeleteAnswerSheet(int id)
        {
            var answerSheet = context.AnswerSheets.Find(id);
            context.AnswerSheets.Remove(answerSheet);
            context.SaveChanges();
            return answerSheet;
        }
        public Question AddQuestion(Question question)
        {
            context.Questions.Add(question);
            context.SaveChanges();
            return question;

        }
        public Option AddOption(Option option)
        {
            context.Options.Add(option);
            context.SaveChanges();
            return option;

        }
        public Boolean isSubmitted(String user,String paperCode)
        {
            var paper = context.Papers.FirstOrDefault(m => m.PaperCode == paperCode);

            int? paperid = paper.PaperId;
            var ansersheet = context.AnswerSheets.Where(m => m.PaperId == paperid).FirstOrDefault(n=>n.User==user);
            if (ansersheet != null) {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void SendMailForPaper(string papercode,int marks, string title, DateTime starttime, DateTime endtime, string user)
        {
            using (MailMessage emailMessage = new MailMessage())
            {
                emailMessage.From = new MailAddress("OnlineQuizInfo@gmail.com", "Online Quiz");
                emailMessage.To.Add(new MailAddress(user, user));
                emailMessage.Subject = "Created Quiz Details";
                emailMessage.Body = $"Title : { title } \t\n Marks : {marks}\t\n Paper-Code : { papercode } \t\n Start Time : { starttime} \t\n Deadline : { endtime} \t\n\n\nThankyou for Creating Quiz..!!!"; ;
                emailMessage.Priority = MailPriority.Normal;
                using (SmtpClient MailClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    MailClient.EnableSsl = true;
                    MailClient.Credentials = new System.Net.NetworkCredential("OnlineQuizInfo@gmail.com", "Aero@8787878787");
                    MailClient.Send(emailMessage);
                }
            }

        }

       public void SendMailForAttendee(string papercode, int? ObtainedMarks, string title, DateTime? Submittedtime, string user)
        {
            using (MailMessage emailMessage = new MailMessage())
            {
                emailMessage.From = new MailAddress("OnlineQuizInfo@gmail.com", "Online Quiz");
                emailMessage.To.Add(new MailAddress(user, user));
                emailMessage.Subject = "Attended Quiz Details";
                emailMessage.Body = $"Title : { title } \t\nObtained Marks : {ObtainedMarks}\t\n Paper-Code : { papercode } \t\n Submitted Time : { Submittedtime}  \t\n\n\nThank you for attending quiz...!!"; ;
                emailMessage.Priority = MailPriority.Normal;
                using (SmtpClient MailClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    MailClient.EnableSsl = true;
                    MailClient.Credentials = new System.Net.NetworkCredential("OnlineQuizInfo@gmail.com", "Aero@8787878787");
                    MailClient.Send(emailMessage);
                }
            }
        }
        public AnswerSheet AddAnswerSheet(Paper paper,String user)
        {
            var totalMarks = 0;
            var answerSheet = new AnswerSheet();
            answerSheet.Paper = GetAllPapers().First(paper1 => paper1.PaperCode == paper.PaperCode);
            answerSheet.User = user;
            System.Diagnostics.Debug.Print(answerSheet.User+"----------------");
            context.AnswerSheets.Add(answerSheet);
            context.SaveChanges();
            for (var i=0;i<paper.Questions.Count();i++)
            {
                var answerSheet_Question = new AnswerSheet_Question();
                answerSheet_Question.Question = answerSheet.Paper.Questions[i];
                for (var j= 0;j < paper.Questions[i].Options.Count();j++)
                {

                    if (paper.Questions[i].Options[j].Correct==true) {
                        for(var k=0;k< paper.Questions[i].Options.Count(); k++)
                        {
                            if( answerSheet.Paper.Questions[i].Options[k].Correct==true && k == j)
                            {
                                totalMarks++;
                            }
                        }
                        answerSheet_Question.selectedoption = answerSheet.Paper.Questions[i].Options[j];
                     }
                }
               
                answerSheet_Question.AnswerSheet = answerSheet;
                context.AnswerSheet_Questions.Add(answerSheet_Question);
                context.SaveChanges();
            }

            answerSheet.ObtainedMarks = totalMarks;
            answerSheet.SubmitTime = DateTime.Now;
            context.SaveChanges();
            return answerSheet;
        }

        public Paper GetPaper(int id)
        {
            return context.Papers.Find(id);
        }
       public List<Paper> GetAllPapers()
        {
            return context.Papers.Include(papers => papers.Questions).ThenInclude(questions => questions.Options).ToList();

        }
        public List<AnswerSheet> GetAllAnswerSheets()
        {
            var anserSheets = context.AnswerSheets.Include(answerSheet => answerSheet.AnswerSheet_Questions).ToList();
            foreach(var anserSheet in anserSheets)
            {
                var paperid = anserSheet.PaperId;
                var paper = GetAllPapers().First(m => m.PaperId == paperid);
                anserSheet.Paper = paper;
            }
            return anserSheets;
        }
        public List<AnswerSheet_Question> GetAllAnswerSheet_Questions()
        {
            return context.AnswerSheet_Questions.ToList();
        }
        IEnumerable<Question> IPaperRepository.GetAllQuestions()
        {
            return context.Questions;
        }
        IEnumerable<Option> IPaperRepository.GetAllOptions()
        {
            return context.Options;

        }
       
    }
}
