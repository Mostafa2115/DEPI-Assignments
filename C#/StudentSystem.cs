using System;

namespace StudentSystem
{
    public enum Status
    {
        Pass,
        Fail
    }

    public class Student
    {
        public string Name { get; set; }
        public int[] Grades { get; set; }
        public double Average { get; set; }
        public Status Status { get; set; }

        
        public void CalculateAvg()
        {
            int sum = 0;
            for (int i = 0; i < Grades.Length; i++)
            {
                sum += Grades[i];
            }
            Average = (double)sum / Grades.Length;
            if (Average >= 50)
                Status = Status.Pass;
            else
                Status = Status.Fail;
        }
      
        public void PrintData()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Average: {Average}");
            Console.WriteLine($"Status: {Status}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[3];
            students[0] = new Student
            {
                Name = "Ali",
                Grades = new int[] { 60, 70, 80 }
            };
            students[1] = new Student
            {
                Name = "Mona",
                Grades = new int[] { 40, 50, 30 }
            };
            students[2] = new Student
            {
                Name = "Omar",
                Grades = new int[] { 90, 85, 95 }
            };
            foreach (Student student in students)
            {
                student.CalculateAvg();
                student.PrintData();
            }
        }
    }
}
