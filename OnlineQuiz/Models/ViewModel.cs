using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Quiz.Models
{
    public class ViewModel
    {
        public Paper Papers { get; set; }
        public List<AnswerSheet_Question> AnswerSheet_Questions { get; set; }
        public AnswerSheet AnswerSheets { get; set; }


    }

}
