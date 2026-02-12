//Implement an `Employee` base class with a method `CalculateSalary()`. Create a `Manager` class that adds a bonus to salary.
using System;
class Employee {
    public virtual int  CalculateSalary() {
        return 1000;
    }
}
class Manager : Employee {
    public override int CalculateSalary() {
        return base.CalculateSalary() + 100;
    }
}
class Program {
    static void Main() {
        Employee emp = new Manager();
        int finalSalary = emp.CalculateSalary();
        Console.WriteLine("Salary: " + finalSalary);
    }
}
