using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_02
{
    public  abstract class BaseQuestion
    {
        public abstract   string? HeaderOfQuestion { get; set; }
        public  abstract   string? BodyOfQuestion { get; set; }
        public  abstract  int Mark  { get; set; }

        public abstract Answer[] AnswerList { get; set; }


        public abstract int RightAnswer { get; set; }

        
    }
}
