using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exam_02
{
 
    public class Subject
    {
        public int SubId { get; set; }
        public string SubName { get; set; }
        public Exam? Exam { get; set; }
        public Subject(int stId, string subName)
        {
            SubId = stId;
            SubName = subName;

        }
        public void CreateExam()
        {
            bool flag;
            int type;
            string pattern = @"^[a-zA-Z]*$|.*[a-zA-Z].*\d.*|\d.*[a-zA-Z].*";
            do
            {
                Console.WriteLine("Please choose Exam you want to create 1 for practical 2 for final");
                flag = int.TryParse(Console.ReadLine(), out type);
            } while (!flag || (type != 1 && type != 2));

            int time;
            int NoOfQuestions;
            do {
                Console.WriteLine("Enter time of Exam in Minutes ");
                flag = int.TryParse(Console.ReadLine(), out time);
            } while (!flag || time <= 0 || time>60);
            do
            {
                Console.WriteLine("Enter Number Of Questions");
                flag = int.TryParse(Console.ReadLine(), out NoOfQuestions);
            } while (!flag || NoOfQuestions <= 0);
            Console.Clear();

            if (type == 1)
            {
                PracticalExam PE = new PracticalExam(time, NoOfQuestions, new Subject(SubId, SubName));
                Exam = PE;
                MCQ mcq = new MCQ();
                ListOfQuestions.McqQuestionList = new List<MCQ>();
                Answer[] answers = new Answer[3];
                int mark;
                int answer;
                string? body;
                for (int i = 0; i < NoOfQuestions; i++)
                {
                    string header = "Choose One Answer Question ";
                    Console.WriteLine(header);
                    Console.WriteLine("*******************************");
                    do
                    {
                        Console.WriteLine("Enter Body Of Question");
                        body = Console.ReadLine();
                    } while (string.IsNullOrWhiteSpace(body) || !Regex.IsMatch(body, pattern));
                    Console.WriteLine("----------------------------");
                    do
                    {
                        Console.WriteLine("Enter Mark Of Question");
                        flag = int.TryParse(Console.ReadLine(), out mark);
                    } while (!flag || mark <= 0);
                    Console.WriteLine("----------------------------");

                    Console.WriteLine("The choices of questions :");
                    for (int j = 0; j < 3; j++)
                    {
                        string? choice;
                        do
                        {
                            Console.Write($"Please Enter Choice no {j + 1}- ");
                            choice = Console.ReadLine();
                        } while (choice ==""||choice is null);

                        answers[j] = new Answer()
                        {
                            AnsId = j + 1,
                            AnsText = choice

                        };
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    do
                    {
                        Console.WriteLine("Enter Right Answer ");
                        flag = int.TryParse(Console.ReadLine(), out answer);
                    } while (!flag || (answer != 1 && answer != 2 && answer != 3));

                    mcq = new MCQ(header, body, mark, answer, answers);
                    ListOfQuestions.McqQuestionList.Add(mcq);
                    Console.Clear();

                }
            }

            else if (type == 2)
            {
                FinalExam final = new FinalExam(time, NoOfQuestions);
                Exam = final;
                MCQ mcq = new MCQ();
                TFQuestion TF;
                ListOfQuestions.TFQuestionList = new List<TFQuestion>();
                ListOfQuestions.McqQuestionList = new List<MCQ>();
                Answer[] TFanswers = new Answer[2];
                Answer[] McqAnswers = new Answer[3];

                int result;
                string? body;
                int mark;
                int answer;
               

                for (int i = 0; i < NoOfQuestions; i++)
                {
                    do
                    {
                        Console.WriteLine($"Choose type of question({i + 1}) 1 for T|F 2 for MCQ");
                        flag = int.TryParse(Console.ReadLine(), out result);

                    } while (!flag || (result != 1 && result != 2));
                    Console.Clear();
                    if (result == 1)
                    {
                        string header = "True | False Question";
                        Console.WriteLine(header);
                        Console.WriteLine("**********************************");
                        do
                        {
                            Console.WriteLine("Enter Body Of Question");
                            body = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(body) || !Regex.IsMatch(body, pattern));
                        Console.WriteLine();
                        do
                        {
                            Console.WriteLine("Enter Mark Of Question");
                            flag = int.TryParse(Console.ReadLine(), out mark);
                        } while (!flag || mark <= 0);
                        Console.WriteLine();
                        do
                        {
                            Console.WriteLine("Enter Right Answer Of the question( 1 for true 2 for false)");
                            flag = int.TryParse(Console.ReadLine(), out answer);

                        } while (!flag || (answer != 1 && answer != 2));

                        TFanswers[0] = new Answer { AnsId = 1, AnsText = "True" };
                        TFanswers[1] = new Answer { AnsId = 2, AnsText = "False" };

                        TF = new TFQuestion(header, body, mark, answer ,TFanswers);
                        ListOfQuestions.TFQuestionList.Add(TF);
                        Console.Clear();

                    }
                    else if (result == 2)
                    {
                        int mark2;
                        int answer2;
                        string? body2;

                        string header2 = "Choose One Answer Question ";
                        Console.WriteLine(header2);
                        Console.WriteLine("**********************");
                        do
                        {
                            Console.WriteLine("Enter Body Of Question");
                            body2 = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(body2) || !Regex.IsMatch(body2, pattern));
                        do
                        {
                            Console.WriteLine("Enter Mark Of Question");
                            flag = int.TryParse(Console.ReadLine(), out mark2);
                        } while (!flag || mark2 <= 0);

                        Console.WriteLine("The choices of questions :");
                        for (int j = 0; j < 3; j++)
                        {
                            string? choice;
                            do
                            {
                                Console.Write($"Please Enter Choice no {j + 1}- ");
                                choice = Console.ReadLine();
                            } while (choice == ""||choice is null);

                            McqAnswers[j] = new Answer()
                            {
                                AnsId = j + 1,
                                AnsText = choice

                            };

                        }
                        Console.WriteLine();
                        do
                        {
                            Console.WriteLine("Enter Right Answer ");
                            flag = int.TryParse(Console.ReadLine(), out answer2);
                        } while (!flag || (answer2 != 1 && answer2 != 2 && answer2 != 3));

                        mcq = new MCQ(header2, body2, mark2, answer2, McqAnswers);
                        ListOfQuestions.McqQuestionList.Add(mcq);
                        Console.Clear();




                    }
                }

            }

            }


        }

    } 
    

