using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public class MCQQuestion : Question
    {

        public MCQQuestion(string body, int mark, Answers[] answerList, int correctAnswerIndex) 
            : base("Choose One Answer Question", body, mark, answerList, correctAnswerIndex)
        {
        }
    }


}
