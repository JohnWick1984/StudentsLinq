using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int GroupNumber { get; set; }
    public double AverageGrade { get; set; }
    public double Scholarship { get; set; }

    public Student(string firstName, string lastName, int groupNumber, double averageGrade, double scholarship)
    {
        FirstName = firstName;
        LastName = lastName;
        GroupNumber = groupNumber;
        AverageGrade = averageGrade;
        Scholarship = scholarship;
    }
}

public class Program
{
    static Random random = new Random();

    static string[] firstNames = { "John", "Alice", "Bob", "Emma", "Michael", "Sophia" };
    static string[] lastNames = { "Smith", "Johnson", "Brown", "Lee", "Garcia", "Martinez" };
    static List<int> groupNumbers = Enumerable.Range(1, 10).ToList();

    static double GenerateRandomGrade()
    {
        return random.Next(1, 6); 
    }

    static double GenerateRandomScholarship()
    {
        return random.Next(1500, 20001); 
    }

    static Student GenerateRandomStudent()
    {
        string firstName = firstNames[random.Next(0, firstNames.Length)];
        string lastName = lastNames[random.Next(0, lastNames.Length)];
        int groupNumber = groupNumbers[random.Next(0, groupNumbers.Count)];
        double averageGrade = GenerateRandomGrade();
        double scholarship = GenerateRandomScholarship();
        return new Student(firstName, lastName, groupNumber, averageGrade, scholarship);
    }

    static List<Student> GenerateRandomStudents(int count)
    {
        List<Student> students = new List<Student>();
        for (int i = 0; i < count; i++)
        {
            students.Add(GenerateRandomStudent());
        }
        return students;
    }

    static List<Student> StudentsInGroup(List<Student> students, int groupNumber)
    {
        return students.Where(student => student.GroupNumber == groupNumber).ToList();
    }

    static List<Student> StudentsWithMaxScholarship(List<Student> students)
    {
        double maxScholarship = students.Max(student => student.Scholarship);
        return students.Where(student => student.Scholarship == maxScholarship).ToList();
    }

    static double AverageScholarship(List<Student> students)
    {
        return students.Select(student => student.Scholarship).Average();
    }

    static List<Student> StudentsWithLowAverageGrade(List<Student> students)
    {
        return students.Where(student => student.AverageGrade <= 3).ToList();
    }

    public static void Main(string[] args)
    {
        List<Student> students = GenerateRandomStudents(20);

      
        Console.WriteLine("All Students:");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}, Group: {student.GroupNumber}, Average Grade: {student.AverageGrade}, Scholarship: {student.Scholarship}");
        }

        
        int groupToFind = 3;
        List<Student> studentsInGroup = StudentsInGroup(students, groupToFind);
        Console.WriteLine($"\nStudents in Group {groupToFind}:");
        foreach (var student in studentsInGroup)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}, Group: {student.GroupNumber}, Average Grade: {student.AverageGrade}, Scholarship: {student.Scholarship}");
        }

      
        List<Student> studentsWithMaxScholarship = StudentsWithMaxScholarship(students);
        Console.WriteLine("\nStudents with Max Scholarship:");
        foreach (var student in studentsWithMaxScholarship)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}, Group: {student.GroupNumber}, Average Grade: {student.AverageGrade}, Scholarship: {student.Scholarship}");
        }

        
        double averageScholarship = AverageScholarship(students);
        Console.WriteLine($"\nAverage Scholarship: {averageScholarship}");

       
        List<Student> studentsWithLowAverageGrade = StudentsWithLowAverageGrade(students);
        Console.WriteLine("\nStudents with Average Grade <= 3:");
        foreach (var student in studentsWithLowAverageGrade)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}, Group: {student.GroupNumber}, Average Grade: {student.AverageGrade}, Scholarship: {student.Scholarship}");
        }
    }
}
