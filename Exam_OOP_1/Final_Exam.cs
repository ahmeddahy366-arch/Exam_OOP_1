using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_OOP_1
{
    public class Final_Exam : Exam, ICloneable
    {

        public Final_Exam(int time, int numberOfQuestions, Question[] questions) : base(time, numberOfQuestions, questions)
        {
        }



        public override void ShowExam()
        {
            int choice;
            bool isvalid;

            foreach (var question in Questions)
            {
                Console.WriteLine($"{question.ToString()}");
                for (int i = 0; i < question.AnswerList.Length; i++)
                {
                    Console.WriteLine(question.AnswerList[i].ToString());
                }
                Console.WriteLine("plase enter your answer");
                do
                {
                    isvalid = int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= question.AnswerList.Length;

                } while (!isvalid);
                question.AnswerUser = question.AnswerList[choice - 1];
                Console.WriteLine("----------------------------------------------------------");
            }
            Console.Clear();
            int totelMark = 0;
            int totelGrad = 0;
            foreach (var question in Questions)
            {
                totelMark += question.Mark;
                if (question.AnswerUser?.AnswerId == question.RightAnswer?.AnswerId)
                {
                    totelGrad += question.Mark;


                }
                Console.WriteLine($"Question: {question.Body}");
                Console.WriteLine($"Your answer   : {question.AnswerUser?.AnswerText}");
                Console.WriteLine($"Correct answer: {question.RightAnswer?.AnswerText}");
                Console.WriteLine("--------------------------------------------------");


                {
                }



            }
            Console.WriteLine($"your grade{totelGrad}/ {totelMark}");
        }










        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}