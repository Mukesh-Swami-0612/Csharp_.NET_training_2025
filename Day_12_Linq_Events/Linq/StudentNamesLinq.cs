using System;
using System.Linq;
using System.Diagnostics;

// Model class to store process info
public class MyProcess
{
    public string Name { get; set; }
    public int Id { get; set; }
}

class ProcessLinq
{
    public static void Main(string[] args)
    {
        // Call the method to print processes
        LinqExample();
    }

    private static void LinqExample()
    {
        // LINQ Query: Get all running processes, order by ProcessName, and select required data
        var procCollection = from p in Process.GetProcesses()
                             orderby p.ProcessName ascending
                             select new MyProcess
                             {
                                 Name = p.ProcessName,
                                 Id = p.Id
                             };

        Console.WriteLine("Running Processes (Sorted by Name):\n");

        // Print each process name and ID
        foreach (var proc in procCollection)
        {
            Console.WriteLine($"{proc.Name}  -->  {proc.Id}");
        }
    }
}
