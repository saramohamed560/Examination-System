using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_02
{
    public class FinalExam : Exam
    {
        
        public override int Time { get; set; }
        public override int NumberOfQuestions { get; set; }
        public override Subject? Subject { get;  set; }
        public TFQuestion? TF { get; set; }
        public MCQ ?MCQ { get; set; }

        public FinalExam(int time, int numberOfQuestions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
        }
        public FinalExam() { }


        TFQuestion tf = new TFQuestion();
        MCQ mcq = new MCQ();
        List<int> ExaminerAnswer = new List<int>();
        int ExamMark = 0;
        int ExaminerMark = 0;
       

        public override void ShowExam()
        {
            bool flag;
            
            //Show Questions and accept answer
            if (ListOfQuestions.TFQuestionList is not null)
            {
                for (int i = 0; i < ListOfQuestions.TFQuestionList?.Count; i++)
                {
                    if (ListOfQuestions.TFQuestionList[i] is not null)
                    {
                        Console.WriteLine($"{ListOfQuestions.TFQuestionList[i]?.HeaderOfQuestion}" +
                      $"   Mark({ListOfQuestions.TFQuestionList[i]?.Mark})");
                        Console.WriteLine(ListOfQuestions.TFQuestionList[i]?.BodyOfQuestion);
                        for (int j = 0; j < 2; j++)
                        {
                            
                            Console.Write($"{ListOfQuestions.TFQuestionList[i]?.AnswerList[j].ToString()}");
                            
                        }
                    }
                    
                    Console.WriteLine();
                    Console.WriteLine("----------------------------");
                    int result;
                    do {
                        Console.Write("Enter Your Answer : ");
                        flag = int.TryParse(Console.ReadLine(), out  result);
                    } while (!(flag) || (result != 1 && result != 2));
                    ExaminerAnswer.Add(result);
                    Console.WriteLine();
                    Console.WriteLine("====================================");

                }
            }
            if(ListOfQuestions.McqQuestionList is not null)
            {
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
                    } while (!(flag) || (result != 1 && result != 2 && result!=3));
                    ExaminerAnswer.Add(result);

                    Console.WriteLine();
                    Console.WriteLine("======================================");



                }

            }

            Console.Clear();
            Console.WriteLine($"\t\t\t\t**********Final Exam Answers **********");
            Console.WriteLine();
            Console.WriteLine($"*************************************************************************************************");
            Console.WriteLine();
            Console.WriteLine("Your Answers : ");
            Console.WriteLine();
            Console.WriteLine("************************************");
            Console.WriteLine();
            // show examiner answer and true answer
            if(ListOfQuestions.TFQuestionList is not null)
            {
                for (int i = 0; i < ListOfQuestions.TFQuestionList?.Count; i++)
                {
                    Console.Write($" Q{i + 1} ){ListOfQuestions.TFQuestionList[i].BodyOfQuestion}: ");
                    string? answer = ListOfQuestions.TFQuestionList[i]?.AnswerList[ExaminerAnswer[i] - 1].AnsText;
                    string? rightanswer = ListOfQuestions.TFQuestionList[i]?.AnswerList[(int)ListOfQuestions.TFQuestionList[i]?.RightAnswer - 1]?.AnsText;
                    Console.Write($"\tYour Answer ({answer}) ------------ Right Answer ({rightanswer})");
                    Console.WriteLine();

                }

            }
            if(ListOfQuestions.McqQuestionList is not null)
            {

                for (int i = 0; i < ListOfQuestions.McqQuestionList?.Count; i++)
                {

                    Console.Write($" Q{i + 1} ) {ListOfQuestions.McqQuestionList[i].BodyOfQuestion}: ");
                    string? answer = ListOfQuestions.McqQuestionList[i]?.AnswerList[ExaminerAnswer[i] - 1].AnsText;
                    string? rightanswer = ListOfQuestions.McqQuestionList[i]?.AnswerList[(int)ListOfQuestions.McqQuestionList[i]?.RightAnswer - 1]?.AnsText;
                    Console.Write($"\tYour Answer is ({answer}) ------------ Right Answer is  ({rightanswer})");
                    Console.WriteLine();
                }
            }
            
            // Calculate Grade
            
            if(ListOfQuestions.TFQuestionList is not null) {
                for (int i = 0; i < ListOfQuestions.TFQuestionList?.Count; i++)
                {
                    ExamMark += ListOfQuestions.TFQuestionList[i].Mark;
                    if (ListOfQuestions.TFQuestionList[i].RightAnswer == ExaminerAnswer[i])
                        ExaminerMark += ListOfQuestions.TFQuestionList[i].Mark;

                }
            }
            if(ListOfQuestions.McqQuestionList is not null)
            {
                int count = ListOfQuestions.TFQuestionList.Count;
                for (int i = 0; i < ListOfQuestions.McqQuestionList?.Count; i++)
                {
                    ExamMark += ListOfQuestions.McqQuestionList[i].Mark;
                    if (ListOfQuestions.McqQuestionList[i].RightAnswer == ExaminerAnswer[count])
                        ExaminerMark += ListOfQuestions.McqQuestionList[i].Mark;
                    count++;

                }
            }

            Console.WriteLine();
            Console.WriteLine("================ Grade ================");
            Console.WriteLine();
            Console.Write($"Your Exam Grade is {ExaminerMark} from {ExamMark}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("================ Elapsed Time ================");
            Console.WriteLine();





        }




    }
            
                
            }
           
        
    

