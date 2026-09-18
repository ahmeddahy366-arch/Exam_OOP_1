using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_OOP_1
{
    public class Subject : ICloneable
    {

        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public Exam SubjectExam { get; set; }

        public Subject(int id, string name)
        {
            SubjectID = id;
            SubjectName = name;
        }


        public Exam CreateExam()
        {

            bool isvalid;
            int choice;

            do
            {
                Console.WriteLine("which type of exam do you want to create?");
                Console.WriteLine("1. Final Exam");
                Console.WriteLine("2. Practical Exam");
                isvalid = int.TryParse(Console.ReadLine(), out choice) && (choice == 1 || choice == 2);
                if (!isvalid)
                { Console.WriteLine("You must choose between 1 and 2."); }
            } while (!isvalid);
            Console.Clear();
            int time;
            do
            {
                Console.WriteLine("Enter time for Exam in minutes:");
                isvalid = int.TryParse(Console.ReadLine(), out time) && time > 0 && time <= 120;
                if (!isvalid)
                {
                    Console.WriteLine("Please enter time greater than (0) and less than or equal to (120).");
                }

            } while (!isvalid);
            int numberOfQuestions;
            do
            {
                Console.WriteLine("Enter number of questions:");
                isvalid = int.TryParse(Console.ReadLine(), out numberOfQuestions) && numberOfQuestions > 0;
                if (!isvalid)
                {
                    Console.WriteLine("Please enter number of questions greater than 0.");
                }
            } while (!isvalid);
            Question[] question = new Question[numberOfQuestions];
            for (int i = 0; i < numberOfQuestions; i++)
            {

                Console.WriteLine($"\n--- Question {i + 1} ---");

                Console.WriteLine("which type of question  do you want?");
                Console.WriteLine("1 True / False");
                Console.WriteLine("2 MCQ");

                int questionType = 2;
                if (choice == 1)
                    do
                    {
                        isvalid = int.TryParse(Console.ReadLine(), out questionType) && (questionType == 1 || questionType == 2);
                        if (!isvalid)
                        { Console.WriteLine("You must choose between 1 and 2."); }
                    } while (!isvalid);
                {
                    Console.Clear();
                    string header;
                    do
                    {
                        Console.WriteLine($"Enter header for question {i + 1}:");
                        header = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(header) || int.TryParse(header, out _) || header.Length <= 5)
                        { Console.WriteLine($" plase Enter header for question {i + 1}or You must enter more than 5 characters"); }

                    } while (string.IsNullOrWhiteSpace(header) || int.TryParse(header, out _) || header.Length <= 5);
                    string body;

                    do
                    {

                        Console.WriteLine($"Enter body for question {i + 1}:");
                        body = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(body) || int.TryParse(body, out _) || body.Length <= 5)
                        { Console.WriteLine($"plase Enter body for question {i + 1} or You must enter more than 5 characters"); }
                    } while (string.IsNullOrWhiteSpace(body) || int.TryParse(body, out _) || body.Length <= 5);
                    int marks;
                    do
                    {
                        Console.WriteLine($"Enter marks for question {i + 1}:");
                        isvalid = int.TryParse(Console.ReadLine(), out marks) && marks > 0;
                        if (!isvalid)
                        { Console.WriteLine("plase Enter marks greater (0) "); }

                    } while (!isvalid);

                    string trueOrFalse;


                    if (questionType == 1)
                    {
                        do
                        {


                            Console.WriteLine("please tell me your answer correct each question");
                            Console.WriteLine($"Question number {1 + i} what answer (false) or (true)");
                            trueOrFalse = Console.ReadLine()?.Trim().ToLower();
                            if (trueOrFalse != "true" && trueOrFalse != "false")
                            {
                                Console.WriteLine("Invalid input. Please enter 'true' or 'false'.");
                            }
                        } while (trueOrFalse != "true" && trueOrFalse != "false");
                        Answer[] answerList = new Answer[2]
                            {
                                            new Answer(1, "True"),
                                            new Answer(2, "False")
                              };

                        Answer rightAnswer = (trueOrFalse == "true") ? answerList[0] : answerList[1];

                        question[i] = new TFQuestion(header, body, marks, answerList, rightAnswer, null);


                    }

                    else if (questionType == 2) //MCQ
                    {

                        int numberOfAnswers = 4;

                        Answer[] answerList = new Answer[numberOfAnswers];
                        for (int j = 0; j < numberOfAnswers; j++)
                        {
                            string answerText;
                            do
                            {
                                Console.WriteLine($"Enter answer {j + 1} for question {i + 1}:");
                                answerText = Console.ReadLine();

                            } while (string.IsNullOrWhiteSpace(answerText));
                            answerList[j] = new Answer(j + 1, answerText);
                        }
                        int correctAnswerIndex = 0;
                        do
                        {
                            Console.WriteLine($"Enter the correct answer number for question {i + 1}:");
                            isvalid = int.TryParse(Console.ReadLine(), out correctAnswerIndex) && correctAnswerIndex >= 1 && correctAnswerIndex <= numberOfAnswers;

                        } while (!isvalid);
                        Answer rightAnswer = answerList[correctAnswerIndex - 1];
                        question[i] = new MCQ_Question(header, body, marks, answerList, rightAnswer, null);
                    }

                }


            }
            SubjectExam = choice == 1
                      ? new Final_Exam(time, numberOfQuestions, question)
                      : new Practical_Exam(time, numberOfQuestions, question);

            return SubjectExam;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}



