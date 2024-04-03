using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public class FinalExam : Exam
    {
        public FinalExam(int timeOfExam, int numberOfQuestions, Subject associatedSubject) : 
            base(timeOfExam, numberOfQuestions, associatedSubject){}

       

        public override void GetQuestions()
        {
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.Clear();

                Console.Write($"Please Choose The Type Of Question Number({i + 1})  ( 1 for True or False || 2 for MCQ) : ");

                string questionType = Console.ReadLine();

                if (questionType == "1")
                {
                    Questions.Add(Exam.TrueOrFalseQuestion());
                    
                }
                else if (questionType == "2")
                {
                    Questions.Add(Exam.MCQQuestion());
                }
                else
                {
                    i--;
                    Console.WriteLine("Please Enter Valid Choice");
                }
            }

        }

        public override void ShowExam()
        {

            Console.Clear();
            Task examTask = Task.Run(() => Exambody());

            Task.WaitAny(examTask, Task.Delay(TimeSpan.FromMinutes(TimeOfExam)));

            ShowResult(2);
        }
        private void Exambody() 
        {
            foreach (var question in Questions)
            {


                Console.WriteLine(question.Header + $"        Mark({question.Mark})");
                Console.WriteLine(question.Body);

                for (int i = 0; i < question.AnswerList.Length; i++)
                    Console.Write($"{i + 1}. {question.AnswerList[i].AnswerText}          ");


                Console.WriteLine("\n--------------------------------------------");




                if (question.AnswerList.Length == 2) GetTrueOrFalseAnswers();

                else GetMCQAnswers();


                Console.WriteLine("=====================================================\n");




            }
        }
    }
}
