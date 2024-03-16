using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Exam_02
{
    public class PracticalExam : Exam
    {
      
        public  override int Time { get; set; }
        public override int NumberOfQuestions { get; set; }
        public override Subject? Subject { get; set; }

        
       public PracticalExam() { }
     
        public PracticalExam(int _time ,int noofquestion ,Subject subject) {
          Time= _time;
          NumberOfQuestions= noofquestion;
           Subject= subject;
        
        }
        TFQuestion tf = new TFQuestion();
        List<int> ExaminerAnswer = new List<int> ();
        int ExamMark = 0;
        int ExaminerMark = 0;
        bool flag;

        public override void ShowExam()
        {

            //show Question And accept answer


            for (int i = 0; i < ListOfQuestions.McqQuestionList?.Count; i++)
            {
                Console.WriteLine($"{ListOfQuestions.McqQuestionList[i]?.HeaderOfQuestion}" +
                    $" Mark({ListOfQuestions.McqQuestionList[i]?.Mark})");
                Console.WriteLine(ListOfQuestions.McqQuestionList[i]?.BodyOfQuestion);
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{ListOfQuestions.McqQuestionList[i]?.AnswerList[j]?.ToString()}");
                }
                Console.WriteLine();
                Console.WriteLine("----------------------------------");
                int result;
                do
                {
                    Console.Write("Enter Your Answer : ");
                    flag = int.TryParse(Console.ReadLine(), out result);
                } while (!(flag) || (result != 1 && result != 2 && result != 3));
                ExaminerAnswer.Add(result);

                Console.WriteLine();
                Console.WriteLine("======================================");



            }

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"\t\t\t\t********** Practical Exam Answers **********");
            Console.WriteLine();
            Console.WriteLine($"*************************************************************************************************");
            Console.WriteLine();
            Console.WriteLine("Your Answers : ");
            Console.WriteLine();
            Console.WriteLine("************************************");
            Console.WriteLine();
            // show Examiner Answer And Right Answer

            for (int i = 0; i < ListOfQuestions.McqQuestionList?.Count; i++)
            {

                Console.Write($"  Q{i + 1} ) {ListOfQuestions.McqQuestionList[i].BodyOfQuestion}: ");
                string? answer = ListOfQuestions.McqQuestionList[i]?.AnswerList[ExaminerAnswer[i] - 1].AnsText;
                string? rightanswer = ListOfQuestions.McqQuestionList[i]?.AnswerList[(int)ListOfQuestions.McqQuestionList[i]?.RightAnswer - 1]?.AnsText;
                Console.Write($"\tYour Answer is ({answer}) ----------- Right Answer is ({rightanswer})");
                Console.WriteLine();
            }

            // Calculate Exam Mark and Grade

            for (int i = 0; i < ListOfQuestions.McqQuestionList?.Count; i++)
                {
                    ExamMark += ListOfQuestions.McqQuestionList[i].Mark;
                    if (ListOfQuestions.McqQuestionList[i].RightAnswer == ExaminerAnswer[i])
                        ExaminerMark += ListOfQuestions.McqQuestionList[i].Mark;
                }

            Console.WriteLine();
            Console.WriteLine("================Grade================");
            Console.WriteLine();
            Console.WriteLine($"Your Exam Grade is {ExaminerMark} from {ExamMark}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==============Elapsed Time===============");
            Console.WriteLine();
            







        }
    }
}
