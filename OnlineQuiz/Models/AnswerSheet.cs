using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Quiz.Models
{
    public class AnswerSheet
    {
        public int AnswerSheetId { get; set; }
         public String User { get; set; }
        public int? ObtainedMarks { get; set; }
        public DateTime? SubmitTime { get; set; }
        public int? PaperId { get; set; }
        public Paper Paper { get; set; }
        public List<AnswerSheet_Question> AnswerSheet_Questions { get; set; }

        public static implicit operator List<object>(AnswerSheet v)
        {
            throw new NotImplementedException();
        }
    }

}
