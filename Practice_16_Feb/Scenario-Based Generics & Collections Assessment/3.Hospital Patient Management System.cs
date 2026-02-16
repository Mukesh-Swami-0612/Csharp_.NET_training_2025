using System;
using System.Collections.Generic;
using System.Linq;

public interface IPatient
{
    int PatientId { get; }
    string Name { get; }
    DateTime DateOfBirth { get; }
    BloodType BloodType { get; }
}

public enum BloodType { A, B, AB, O }

public class PriorityQueue<T> where T : IPatient
{
    private SortedDictionary<int, Queue<T>> queues = new();

    public void Enqueue(T patient, int priority)
    {
        if (priority < 1 || priority > 5)
            throw new ArgumentException("Priority must be between 1 and 5");

        if (!queues.ContainsKey(priority))
            queues[priority] = new Queue<T>();

        queues[priority].Enqueue(patient);
    }

    public T Dequeue()
    {
        foreach (var item in queues.OrderBy(q => q.Key))
        {
            if (item.Value.Count > 0)
                return item.Value.Dequeue();
        }

        throw new Exception("Queue is empty");
    }
}

public class MedicalRecord<T> where T : IPatient
{
    private T patient;
    private Dictionary<DateTime, string> treatments = new();

    public MedicalRecord(T patient)
    {
        this.patient = patient;
    }

    public void AddTreatment(string treatment, DateTime date)
    {
        treatments[date] = treatment;
    }

    public void ShowTreatmentHistory()
    {
        foreach (var item in treatments.OrderBy(t => t.Key))
        {
            Console.WriteLine($"{item.Key} - {item.Value}");
        }
    }
}

public class PediatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public string GuardianName { get; set; }
    public double Weight { get; set; }
}

public class GeriatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public int MobilityScore { get; set; }
}

public class MedicationSystem<T> where T : IPatient
{
    private Dictionary<T, List<string>> medications = new();

    public void PrescribeMedication(T patient, string medication, Func<T, bool> validator)
    {
        if (!validator(patient))
        {
            Console.WriteLine("Dosage not valid!");
            return;
        }

        if (!medications.ContainsKey(patient))
            medications[patient] = new List<string>();

        medications[patient].Add(medication);
        Console.WriteLine("Medication prescribed successfully.");
    }

    public void CheckInteraction(T patient, string medicine)
    {
        if (medications.ContainsKey(patient) && medications[patient].Contains(medicine))
            Console.WriteLine("Drug interaction found!");
        else
            Console.WriteLine("No interaction found.");
    }
}

class Program
{
    static void Main()
    {
        PriorityQueue<IPatient> queue = new();

        Console.WriteLine("How many patients do you want to add?");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("\n1. Pediatric\n2. Geriatric");
            int type = int.Parse(Console.ReadLine());

            Console.Write("Patient Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Date of Birth (yyyy-mm-dd): ");
            DateTime dob = DateTime.Parse(Console.ReadLine());

            Console.Write("Blood Type (A, B, AB, O): ");
            BloodType blood = Enum.Parse<BloodType>(Console.ReadLine());

            IPatient patient;

            if (type == 1)
            {
                Console.Write("Guardian Name: ");
                string guardian = Console.ReadLine();

                Console.Write("Weight (kg): ");
                double weight = double.Parse(Console.ReadLine());

                patient = new PediatricPatient
                {
                    PatientId = id,
                    Name = name,
                    DateOfBirth = dob,
                    BloodType = blood,
                    GuardianName = guardian,
                    Weight = weight
                };
            }
            else
            {
                Console.Write("Mobility Score (1-10): ");
                int mobility = int.Parse(Console.ReadLine());

                patient = new GeriatricPatient
                {
                    PatientId = id,
                    Name = name,
                    DateOfBirth = dob,
                    BloodType = blood,
                    MobilityScore = mobility
                };
            }

            Console.Write("Enter Priority (1-5): ");
            int priority = int.Parse(Console.ReadLine());

            queue.Enqueue(patient, priority);
        }

        Console.WriteLine("\nProcessing Patients by Priority:");
        while (true)
        {
            try
            {
                var p = queue.Dequeue();
                Console.WriteLine($"Processing: {p.Name}");
            }
            catch
            {
                break;
            }
        }
    }
}
