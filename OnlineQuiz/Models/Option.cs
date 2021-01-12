using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Quiz.Models
{
    public class Option
    {
        public int OptionId { get; set; }
        public String OptionName { get; set; }
        public Boolean Correct { get; set; }
        [Required]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
       // public ICollection<AttendeeQuestion> AttendeeQuestions { get; set; }
    }
}
