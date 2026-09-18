using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_OOP_1
{
    public class TFQuestion : Question, ICloneable
    {
        public TFQuestion(string header, string body, int mark, Answer[] answerList, Answer rightAnswers, Answer answerUser) : base(header, body, mark, answerList, rightAnswers, answerUser)
        {
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public override string ToString()
        {
            return $"{Header} \n{Body} =>(Mark): {Mark}";
        }
    }
}
