using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_OOP_1
{
    public abstract class Question : IComparable<Question>
    {

        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public Answer RightAnswer { get; set; }
        public Answer AnswerUser { get; set; }
        public Question(string header, string body, int mark, Answer[] answerList, Answer rightAnswers, Answer answerUser)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            RightAnswer = rightAnswers;
            AnswerUser = answerUser;
        }
        public override string ToString()
        {
            return $"{Header}\n{Body} (Mark: {Mark})";
        }

        public int CompareTo(Question? other)
        {
            if (other == null) return 1;
            return Mark.CompareTo(other.Mark);
        }

    }
}
