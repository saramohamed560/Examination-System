using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_02
{
    public   abstract class Exam
    {

        public abstract int Time{ get; set; }
        public abstract int NumberOfQuestions{ get; set; }
        public abstract Subject Subject { get; set; }

        public abstract void ShowExam();


    }
}
