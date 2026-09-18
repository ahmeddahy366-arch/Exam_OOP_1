using System.Diagnostics;

namespace Exam_OOP_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(1, "Math");
            subject.SubjectExam = subject.CreateExam();
            Console.Clear();
            Console.WriteLine("Do you want start exam(Y/N)");
            bool Isvalid;
            char choice;
            do
            {

                Isvalid = char.TryParse(Console.ReadLine(), out choice) && (char.ToUpper(choice) == 'Y' || char.ToUpper(choice) == 'N');

            } while (!Isvalid);

            switch (char.ToUpper( choice))
            {
                case 'Y':
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    subject.SubjectExam.ShowExam();
                    sw.Stop();
                    Console.WriteLine($"\n The  Time = {sw.Elapsed}");
                    break;
                case 'N':
                    Console.WriteLine("Exam cancelled");

                    break;

            }

        }
    }
}
         
 