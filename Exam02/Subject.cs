using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public class Subject
    {
        public int SubjectId { get;  set; }
        public string SubjectName { get;  set; }
        public int TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public Exam Exam { get; set; }

        private int counter = 0;

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }


        public void CreateExam()
        {

            Console.Clear();
            if (counter != 0)
                Console.WriteLine("Please Enter Valid Choise");

            Console.Write("Please Enter The Type Of Exam you want To create( 1 for practical and 2 for Final) : ");

            string examType = Console.ReadLine().TrimStart();

            if (examType == "1" || examType == "2")
            {
                GetExamDetails(int.Parse(examType));

               
            }
            else
            {
                counter++;
                CreateExam();
            }

        }
        private void GetExamDetails(int examType)
        {
            Console.Write("Please Enter the Time Of Exam in Minutes: ");
            TimeOfExam = GetValidInput();

            Console.Write("Please Enter the Number Of Questions You Wanted To Create:");
            NumberOfQuestions = GetValidInput();

            if (examType == 1)
            {
                Exam = new PracticalExam(TimeOfExam, NumberOfQuestions, this);
                
            }
            else if (examType == 2)
            {
                Exam = new FinalExam(TimeOfExam, NumberOfQuestions, this);
               
            }
            Exam.GetQuestions();

        }

        private static int GetValidInput()
        {
            int result;
            while (!int.TryParse(Console.ReadLine().TrimStart(), out result))
            {
                Console.WriteLine("Invalid input. Please enter a valid value.");
            }
            return result;
        }

       
        
    }
}
