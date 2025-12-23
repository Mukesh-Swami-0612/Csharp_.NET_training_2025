// Problem: Create Student objects and display details

using System;

public class Student
{
    public string Name;
    public int Age;

    public void Display()
    {
        Console.WriteLine(Name + " " + Age);
    }
}

class Program
{
    public static void Main()
    {
        // Object creation using normal assignment
        Student s1 = new Student();
        s1.Name = "Mukesh";
        s1.Age = 23;

        // Object creation using object initializer
        Student s2 = new Student
        {
            Name = "Kumar",
            Age = 24
        };

        s1.Display();
        s2.Display();
    }
}
