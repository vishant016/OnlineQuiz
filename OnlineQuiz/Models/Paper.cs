using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Quiz.Models
{
    public class Paper
    {
        public Paper()
        {

        }
        public int PaperId { get; set; }
        public String PaperCode { get; set; }
        public String Owner { get; set; }
        public String PaperName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Pmarks { get; set; }
        public List<Question> Questions{  get; set; }
      //  public ICollection<AttendeeQuestion> AttendeeQuestions { get; set; }

        public Paper(List<Question> questions)
        {
            questions = Questions;
        }
    }
}
