using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_OOP_1
{
    public class Answer : ICloneable
    {

        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public override string ToString()
        {
            return $"{AnswerId},{AnswerText}";
        }
    }
}
