using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class StudentCollection<T> where T : struct, IComparable<T>
{
    private List<Student> students;

    public StudentCollection()
    {
        students = new List<Student>();
    }

    public void AddStudent(int id, string name)
    {
        students.Add(new Student { Id = id, Name = name });
    }

    public Student? GetStudent(int index)
    {
        if (index >= 0 && index < students.Count)
        {
            return students[index];
        }
        else
        {
            return null;
        }
    }

    public List<Student> GetSortedDescending()
    {
        List<Student> sortedList = students.OrderByDescending(s => s.Id).ToList();
        return sortedList;
    }
}

class Program
{
    static void Main()
    {
        StudentCollection<int> studentCollection = new StudentCollection<int>();

        studentCollection.AddStudent(101, "Ali Nassar");
        studentCollection.AddStudent(102, "Ji Xing");
        studentCollection.AddStudent(103, "Matt Carter");

        Console.WriteLine("Original Student List:");
        foreach (Student student in studentCollection.GetSortedDescending())
        {
            Console.WriteLine($"Student ID: {student.Id}, Name: {student.Name}");
        }

        int studentIndex = 1;

        Student stud = studentCollection.GetStudent(studentIndex);

        if (stud != null)
        {
            Console.WriteLine($"Student found at index {studentIndex}: ID - {stud.Id}, Name - {stud.Name}");
        }
        else
        {
            Console.WriteLine($"Student not found at index {studentIndex}.");
        }
    }
}
