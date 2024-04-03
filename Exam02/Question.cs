using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public int CorrectAnswerIndex { get; set; }
        public Answers[] AnswerList { get; set; }


        public Question(string header, string body, int mark, Answers[] answerList, int correctAnswerIndex)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            CorrectAnswerIndex = correctAnswerIndex;
        }

       
    }

}
