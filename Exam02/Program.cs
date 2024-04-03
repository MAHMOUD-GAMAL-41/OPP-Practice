using System.Diagnostics;

namespace Exam02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject Sub1 = new Subject(10,"C#");
            Sub1.CreateExam();  
            Console.Clear();
            Console.WriteLine("Do You Want To Start The Exam (y | n): ");

            if (char.Parse(Console.ReadLine()) == 'y')
            { 
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Sub1.Exam.ShowExam();
                Console.WriteLine($"The Elapsed Time = {sw.Elapsed}");
            }
        }
    }
}
