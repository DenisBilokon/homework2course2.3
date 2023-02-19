using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        List<Employee> employees = ReadEmployeesFromFile("employees.txt");

        List<Employee> sortedEmployees = employees.OrderBy(e => e.YearsOfExperience).ToList();

        Console.WriteLine("Список співробітників, відсортований за роками досвіду:");
        foreach (var employee in sortedEmployees)
        {
            Console.WriteLine(employee.Name + " - " + employee.YearsOfExperience);
        }
    }

    static List<Employee> ReadEmployeesFromFile(string filename)
    {
        List<Employee> employees = new List<Employee>();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                string name = parts[0];
                double salary = Double.Parse(parts[1]);
                int yearsOfExperience = Int32.Parse(parts[2]);
                employees.Add(new Employee(name, salary, yearsOfExperience));
            }
        }

        return employees;
    }
}

class Employee
{
    public string Name { get; set; }
    public double Salary { get; set; }
    public int YearsOfExperience { get; set; }

    public Employee(string name, double salary, int yearsOfExperience)
    {
        Name = name;
        Salary = salary;
        YearsOfExperience = yearsOfExperience;
    }
}
