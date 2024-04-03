using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public abstract class Exam
    {
        public int TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public Subject AssociatedSubject { get; set; }
        protected List<Question> Questions;
        protected List<int> AnswerUserList;
        protected Exam(int timeOfExam, int numberOfQuestions, Subject associatedSubject)
        {
            TimeOfExam = timeOfExam;
            NumberOfQuestions = numberOfQuestions;
            AssociatedSubject = associatedSubject;
            Questions = new List<Question>();
            AnswerUserList = new List<int>();
        }
        public abstract void ShowExam();
        public abstract void GetQuestions();
        public void GetMCQAnswers() =>AnswerUserList.Add(GetValidMCQAnswer());
        public void GetTrueOrFalseAnswers()=> AnswerUserList.Add(GetValidTrueOrFalseAnswer());   
        public static TrueOrFalseQuestion TrueOrFalseQuestion()
        {
            Console.Clear();

            Console.WriteLine("True | False Question");
            Console.WriteLine("Please Enter The Body of Question:");
            string questionBody = GetNotNullInput();
            Console.WriteLine("Please Enter The Marks of Question:");
            int mark = GetValidInput();
            Console.WriteLine("Please Enter The Right Answer of Question (1 for true and 2 for false):");
            int answer = GetValidTrueOrFalseAnswer();

            Answers[] answerList = new Answers[]
            {
                new Answers(1, "True"),
                new Answers(2, "False")
            };

            return new TrueOrFalseQuestion(questionBody, mark,answer, answerList);
        }
        public static MCQQuestion MCQQuestion()
        {
            Console.Clear();
            Console.WriteLine("Choose One Answer Question");
            Console.WriteLine("Please Enter The Body of Question:");
            string questionBody = GetNotNullInput();
            Console.WriteLine("Please Enter The Marks of Question:");
            int mark = GetValidInput();
            Console.WriteLine("The Choices Of Questions:");
            string[] choices = new string[3];
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Please Enter The Choice Number {i + 1}:");

                string choice;
                do
                {
                    choice = GetNotNullInput();

                    if (Array.IndexOf(choices, choice) != -1)
                    {
                        Console.WriteLine("Choice already entered. Please enter a different value.");
                    }

                } while (Array.IndexOf(choices, choice) != -1);

                choices[i] = choice;
            }


            Console.WriteLine("Please Specify The Right Choice Of Question:");
            int correctChoiceIndex = GetValidMCQAnswer();
            Answers[] answerList = new Answers[]
            {
                new Answers(1, choices[0]),
                new Answers(2, choices[1]),
                new Answers(3, choices[2])
            };

            return new MCQQuestion(questionBody, mark, answerList, correctChoiceIndex);

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
        public static int GetValidMCQAnswer()
        {
            int result;
            while (!int.TryParse(Console.ReadLine().TrimStart(), out result) || !(result > 0 && result <= 3))
            {
                Console.WriteLine("Invalid input. Please enter a valid value (1, 2, or 3).");
            }

            return result;
        }
        public static int GetValidTrueOrFalseAnswer()
        {
            int result;
            while (!int.TryParse(Console.ReadLine().TrimStart(), out result) || (result != 1 && result != 2))
            {
                Console.WriteLine("Invalid input. Please enter a valid value.");
            }

            return result;
        }
        private static string GetNotNullInput()
        {
            string input;
            do
            {
                input = Console.ReadLine().TrimStart();
                if (input == "")
                {
                    Console.WriteLine("Invalid input. Please enter a non-null value.");
                }
            } while (input == "");

            return input;
        }
        public  void ShowResult(int ExamType)
        {
            Console.Clear();
            Console.WriteLine("Your Answers:");
            int counter = 0;
            int totalMark=0;
            string userAnswer;
            string correctAnswer;
            foreach (var question in Questions)
            {

                userAnswer = AnswerUserList.Count >= counter + 1 ? question.AnswerList[AnswerUserList[counter] - 1].AnswerText : "No Answer";
                correctAnswer = question.AnswerList[question.CorrectAnswerIndex - 1].AnswerText;
                Console.WriteLine($"Q{counter+1})       {question.Body}: {userAnswer}");
               Console.WriteLine($"the correct answer is {correctAnswer}");
                counter++;
                totalMark += question.Mark;
            }
            if (ExamType == 2)
            {
                int result = GetResult();
                Console.WriteLine($"Your Exam Grade is {result} from {totalMark}");
            }
        }
        private int GetResult()
        {
            int result = 0;

            for (int counter = 0; counter < AnswerUserList.Count && counter < Questions.Count; counter++)
            {
                if (Questions[counter].CorrectAnswerIndex == AnswerUserList[counter])
                {
                    result += Questions[counter].Mark;
                }
            }

            return result;
        }


    }
}
