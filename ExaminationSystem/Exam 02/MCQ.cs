using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_02
{
    public  class MCQ:BaseQuestion
    {
        public override string? HeaderOfQuestion { get; set; }
        public override string? BodyOfQuestion { get; set; }
        public override int Mark { get; set; }
        public override Answer[] AnswerList { get; set; }
        public override int RightAnswer { get; set; }
        public MCQ() {
            
        }

        public MCQ(string? headerOfQuestion ,string? bodyOfQuestion, int mark, int rightAnswer, Answer[] answers)
        {
            HeaderOfQuestion = headerOfQuestion;
            BodyOfQuestion = bodyOfQuestion;
            Mark = mark;
          
            RightAnswer = rightAnswer;
            AnswerList=answers;
         
        }
    }
}
