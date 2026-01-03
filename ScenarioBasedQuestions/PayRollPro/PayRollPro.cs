using System;
using System.Collections.Generic;
using System.Linq;

#region OOPS Models
// ---------------- OOPS SECTION ----------------

// Abstract base class for all employees
// It defines common properties and behavior
public abstract class EmployeeRecord
{
    // Name of the employee
    public string EmployeeName { get; set; }

    // Array storing weekly working hours (for 4 weeks)
    public double[] WeeklyHours { get; set; }

    // Abstract method
    // Each employee type must define how monthly pay is calculated
    public abstract double GetMonthlyPay();
}

// ---------------- FULL-TIME EMPLOYEE ----------------
public class FullTimeEmployee : EmployeeRecord
{
    // Hourly pay rate
    public double HourlyRate { get; set; }

    // Extra monthly bonus
    public double MonthlyBonus { get; set; }

    // Overriding abstract method
    // Monthly pay = total weekly hours * hourly rate + bonus
    public override double GetMonthlyPay()
    {
        return WeeklyHours.Sum() * HourlyRate + MonthlyBonus;
    }
}

// ---------------- CONTRACT EMPLOYEE ----------------
public class ContractEmployee : EmployeeRecord
{
    // Hourly pay rate
    public double HourlyRate { get; set; }

    // Overriding abstract method
    // Contract employees do not get bonus
    public override double GetMonthlyPay()
    {
        return WeeklyHours.Sum() * HourlyRate;
    }
}

#endregion

public class Program
{
    // Static list to store all registered employees
    // Shared across the entire application
    public static List<EmployeeRecord> PayrollBoard = new List<EmployeeRecord>();

    // Method to register an employee
    // Uses polymorphism (EmployeeRecord reference)
    public void RegisterEmployee(EmployeeRecord record)
    {
        PayrollBoard.Add(record);
    }

    // Method to calculate overtime weeks for each employee
    // Returns employee name with count of weeks exceeding threshold
    public Dictionary<string, int> GetOvertimeWeekCounts(
        List<EmployeeRecord> records, 
        double hoursThreshold)
    {
        // Dictionary to store result
        Dictionary<string, int> result = new Dictionary<string, int>();

        // Loop through all employees
        foreach (var emp in records)
        {
            // Count weeks where hours >= threshold
            int count = emp.WeeklyHours.Count(h => h >= hoursThreshold);

            // Add only if overtime exists
            if (count > 0)
            {
                result.Add(emp.EmployeeName, count);
            }
        }

        return result;
    }

    // Method to calculate average monthly pay of all employees
    public double CalculateAverageMonthlyPay()
    {
        // Avoid division by zero
        if (PayrollBoard.Count == 0)
            return 0;

        // Average monthly salary using LINQ
        return PayrollBoard.Average(e => e.GetMonthlyPay());
    }

    // ---------------- MAIN METHOD ----------------
    public static void Main(string[] args)
    {
        // Creating Program object
        Program app = new Program();

        // Control variable for menu loop
        bool running = true;

        // Menu-driven loop
        while (running)
        {
            Console.WriteLine("\n1. Register Employee");
            Console.WriteLine("2. Show Overtime Summary");
            Console.WriteLine("3. Calculate Average Monthly Pay");
            Console.WriteLine("4. Exit");
            Console.WriteLine("\nEnter your choice:");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                // -------- REGISTER EMPLOYEE --------
                case 1:
                    Console.WriteLine("\nSelect Employee Type (1-Full Time, 2-Contract):");
                    int type = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nEnter Employee Name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("\nEnter Hourly Rate:");
                    double rate = double.Parse(Console.ReadLine());

                    // Store weekly hours
                    double[] hours = new double[4];
                    Console.WriteLine("\nEnter weekly hours (Week 1 to 4):");
                    for (int i = 0; i < 4; i++)
                    {
                        hours[i] = double.Parse(Console.ReadLine());
                    }

                    // Full-time employee creation
                    if (type == 1)
                    {
                        Console.WriteLine("\nEnter Monthly Bonus:");
                        double bonus = double.Parse(Console.ReadLine());

                        FullTimeEmployee ft = new FullTimeEmployee
                        {
                            EmployeeName = name,
                            HourlyRate = rate,
                            MonthlyBonus = bonus,
                            WeeklyHours = hours
                        };

                        app.RegisterEmployee(ft);
                    }
                    // Contract employee creation
                    else
                    {
                        ContractEmployee ct = new ContractEmployee
                        {
                            EmployeeName = name,
                            HourlyRate = rate,
                            WeeklyHours = hours
                        };

                        app.RegisterEmployee(ct);
                    }

                    Console.WriteLine("\nEmployee registered successfully");
                    break;

                // -------- OVERTIME SUMMARY --------
                case 2:
                    Console.WriteLine("\nEnter hours threshold:");
                    double threshold = double.Parse(Console.ReadLine());

                    var overtimeData = app.GetOvertimeWeekCounts(
                        PayrollBoard, threshold);

                    if (overtimeData.Count == 0)
                    {
                        Console.WriteLine("\nNo overtime recorded this month");
                    }
                    else
                    {
                        foreach (var item in overtimeData)
                        {
                            Console.WriteLine($"{item.Key} - {item.Value}");
                        }
                    }
                    break;

                // -------- AVERAGE PAY --------
                case 3:
                    double avgPay = app.CalculateAverageMonthlyPay();
                    Console.WriteLine($"\nOverall average monthly pay: {avgPay}");
                    break;

                // -------- EXIT --------
                case 4:
                    Console.WriteLine("\nLogging off — Payroll processed successfully!");
                    running = false;
                    break;

                // -------- INVALID OPTION --------
                default:
                    Console.WriteLine("\nInvalid choice");
                    break;
            }
        }
    }
}
