using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public class TrueOrFalseQuestion : Question
    {

        public TrueOrFalseQuestion(string body, int mark,int correctAnswerIndex, Answers[] answerList) 
            : base("True | False Question", body, mark, answerList, correctAnswerIndex){}
    }

}
