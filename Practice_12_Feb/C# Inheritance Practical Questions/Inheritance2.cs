using System;
class Person {
    public virtual void GetDetails() {
        Console.WriteLine("Person.");
    }
}
class Student : Person {
    public override void GetDetails() {
        Console.WriteLine("Student.");
    }
}
class Program {
    static void Main() {
        Person p = new Student();
        p.GetDetails();
    }
}
