using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int timeOfExam, int numberOfQuestions, Subject associatedSubject) 
            : base(timeOfExam, numberOfQuestions, associatedSubject){}

     
        public override void GetQuestions()
        {
            Console.Clear();
            for (int i = 0; i < NumberOfQuestions; i++)
                Questions.Add(Exam.MCQQuestion());
        }
        public override void ShowExam()
        {
            Console.Clear();

            Task examTask = Task.Run(() => Exambody());

            Task.WaitAny(examTask, Task.Delay(TimeSpan.FromMinutes(TimeOfExam)));

            ShowResult(1);
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
                GetMCQAnswers();
                Console.WriteLine("=====================================================\n");

            }
        }

    }
}
