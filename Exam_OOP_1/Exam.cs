using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_OOP_1
{
    public abstract class Exam
    {
        public int Time;
        public int NumberOfQuestions;
        public Question[] Questions;

        protected Exam(int time, int numberOfQuestions, Question[] questions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = questions;
        }

        public abstract void ShowExam();


    }
}