using System.Diagnostics;

namespace Exam_02
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Subject sub1 = new Subject(10, " C#");
            sub1.CreateExam();
            Console.Clear();
            Console.WriteLine("Dou you want to start the exam y| n ");
            if(char.Parse(Console.ReadLine()??"") == 'y' ) {
                Console.Clear();
                Stopwatch sw = Stopwatch.StartNew();
                sw.Start();
                sub1?.Exam?.ShowExam();
                Console.WriteLine($"Elapsed time {sw.Elapsed}");
            } 
           














        }
    }
}