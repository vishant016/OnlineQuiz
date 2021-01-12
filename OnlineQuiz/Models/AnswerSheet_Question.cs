using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Quiz.Models
{
    public class AnswerSheet_Question
    {
        public int AnswerSheetId { get; set; }
        public AnswerSheet AnswerSheet { get; set; }
        
        public int? QuestionId { get; set; }
        public Question Question { get; set; }

        public int? Optionid { get; set; }
        [foreignkey(nameof(Optionid))]
    
        public Option selectedoption { get; set; }
    }
}
