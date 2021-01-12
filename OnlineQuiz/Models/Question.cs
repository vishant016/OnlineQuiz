using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Quiz.Models
{
    public class Question
    {
        public Question()
        {

        }
        public int QuestionId{ get; set; }
        public String QuestionName { get; set; }
        public int Qmarks { get; set; }
        [Required]
        public int PaperId { get; set; }
        public Paper Paper { get; set; }
        public List<Option> Options { get; set; }
        public Question(List<Option> options)
        {
            options = Options;
        }
       public List<AnswerSheet_Question> AnswerSheet_Questions { get; set; }
        //   public ICollection<AttendeeQuestion> AttendeeQuestions { get; set; }

    }

}
