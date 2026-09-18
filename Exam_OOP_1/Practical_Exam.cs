using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_OOP_1
{
    public class Practical_Exam : Exam
    {
        public Practical_Exam(int time, int numberOfQuestions, Question[] questions) : base(time, numberOfQuestions, questions)
        {
        }

        public override void ShowExam()
        {
            foreach (var question in Questions)
            {
                Console.WriteLine(question.ToString());

                for (int i = 0; i < question.AnswerList.Length; i++)
                {
                    Console.WriteLine(question.AnswerList[i].ToString());
                }

                int choice;
                bool isValid;
                do
                {
                    Console.WriteLine("Please enter your answer:");
                    isValid = int.TryParse(Console.ReadLine(), out choice)
                              && choice > 0
                              && choice <= question.AnswerList.Length;

                    if (!isValid)
                    {
                        Console.WriteLine($"Invalid choice! Enter a number between 1 and {question.AnswerList.Length}:");
                    }

                } while (!isValid);

                question.AnswerUser = question.AnswerList[choice - 1];
                Console.WriteLine("--------------------------------------------------");
            }

            Console.Clear();
            Console.WriteLine("================ Exam Results ================");

            foreach (var question in Questions)
            {
                Console.WriteLine($"Question: {question.Body}");
                Console.WriteLine($"Your Answer: {question.AnswerUser?.AnswerText}");
                Console.WriteLine($"Correct Answer: {question.RightAnswer?.AnswerText}");
                Console.WriteLine("--------------------------------------------------");
            }
        }
    }
}
