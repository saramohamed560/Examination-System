using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_02
{
    public class Answer
    {

        public int AnsId { get; set; }
        public string? AnsText { get; set; }
        public Answer(int id, string text)
        {
            AnsId = id;
            AnsText = text;
        }

        public Answer()
        {
         
        }

        public override string ToString()
        {
            return $"{AnsId}.{AnsText}   ";
        }
    }
}
