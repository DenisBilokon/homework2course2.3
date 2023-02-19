using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
      
        List<Student> students = ReadStudentsFromFile("students.txt");

     
        double minAverageGrade = 80.0;
        List<Student> filteredStudents = students.Where(s => s.AverageGrade >= minAverageGrade).ToList();

    
        Console.WriteLine("Список студентів з середнім балом не менше " + minAverageGrade + ":");
        foreach (var student in filteredStudents)
        {
            Console.WriteLine(student.Name + " - " + student.AverageGrade);
        }
    }

    static List<Student> ReadStudentsFromFile(string filename)
    {
        List<Student> students = new List<Student>();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                string name = parts[0];
                double[] grades = Array.ConvertAll(parts.Skip(1).ToArray(), Double.Parse);
                double averageGrade = grades.Average();
                students.Add(new Student(name, grades, averageGrade));
            }
        }

        return students;
    }
}

class Student
{
    public string Name { get; set; }
    public double[] Grades { get; set; }
    public double AverageGrade { get; set; }

    public Student(string name, double[] grades, double averageGrade)
    {
        Name = name;
        Grades = grades;
        AverageGrade = averageGrade;
    }
}
