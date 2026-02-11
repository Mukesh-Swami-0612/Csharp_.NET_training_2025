
using System;
using System.Collections.Generic;
using System.Linq;

// ================= INTERFACE =================
public interface IPatient
{
    int PatientId { get; }
    string Name { get; }
    DateTime DateOfBirth { get; }
    BloodType BloodType { get; }
}

public enum BloodType { A, B, AB, O }
public enum Condition { Stable, Critical, Recovering }


// ================= PRIORITY QUEUE =================
public class PriorityQueue<T> where T : IPatient
{
    private SortedDictionary<int, Queue<T>> _queues = new();

    // TODO: Enqueue patient with priority (1=highest, 5=lowest)
    public void Enqueue(T patient, int priority)
    {
        // Validate priority range
        if (priority < 1 || priority > 5)
            throw new ArgumentException("Priority must be between 1 and 5");

        // Create queue if doesn't exist for priority
        if (!_queues.ContainsKey(priority))
            _queues[priority] = new Queue<T>();

        _queues[priority].Enqueue(patient);
    }

    // TODO: Dequeue highest priority patient
    public T Dequeue()
    {
        // Return patient from highest non-empty priority
        foreach (var item in _queues)
        {
            if (item.Value.Count > 0)
                return item.Value.Dequeue();
        }

        // Throw if empty
        throw new InvalidOperationException("Queue is empty");
    }

    // TODO: Peek without removing
    public T Peek()
    {
        // Look at next patient
        foreach (var item in _queues)
        {
            if (item.Value.Count > 0)
                return item.Value.Peek();
        }

        throw new InvalidOperationException("Queue is empty");
    }

    // TODO: Get count by priority
    public int GetCountByPriority(int priority)
    {
        // Return count for specific priority
        if (_queues.ContainsKey(priority))
            return _queues[priority].Count;

        return 0;
    }
}


// ================= MEDICAL RECORD =================
public class MedicalRecord<T> where T : IPatient
{
    private T _patient;
    private List<string> _diagnoses = new();
    private Dictionary<DateTime, string> _treatments = new();

    public MedicalRecord(T patient)
    {
        _patient = patient;
    }

    // TODO: Add diagnosis with date
    public void AddDiagnosis(string diagnosis, DateTime date)
    {
        // Add to diagnoses list
        _diagnoses.Add($"{date.ToShortDateString()} : {diagnosis}");
    }

    // TODO: Add treatment
    public void AddTreatment(string treatment, DateTime date)
    {
        // Add to treatments dictionary
        _treatments[date] = treatment;
    }

    // TODO: Get treatment history
    public IEnumerable<KeyValuePair<DateTime, string>> GetTreatmentHistory()
    {
        // Return sorted by date
        return _treatments.OrderBy(x => x.Key);
    }
}


// ================= PATIENT TYPES =================
public class PediatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public string GuardianName { get; set; }
    public double Weight { get; set; } // in kg
}

public class GeriatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public List<string> ChronicConditions { get; } = new();
    public int MobilityScore { get; set; } // 1-10
}


// ================= MEDICATION SYSTEM =================
public class MedicationSystem<T> where T : IPatient
{
    private Dictionary<T, List<(string medication, DateTime time)>> _medications = new();

    // TODO: Prescribe medication with dosage validation
    public void PrescribeMedication(T patient, string medication,
        Func<T, bool> dosageValidator)
    {
        // Check if dosage is valid for patient type
        if (!dosageValidator(patient))
        {
            Console.WriteLine("Dosage not valid!");
            return;
        }

        if (!_medications.ContainsKey(patient))
            _medications[patient] = new List<(string, DateTime)>();

        _medications[patient].Add((medication, DateTime.Now));

        Console.WriteLine($"Medication {medication} given to {patient.Name}");
    }

    // TODO: Check for drug interactions
    public bool CheckInteractions(T patient, string newMedication)
    {
        // Return true if interaction with existing medications
        if (!_medications.ContainsKey(patient))
            return false;

        foreach (var med in _medications[patient])
        {
            if (med.medication == newMedication)
                return true;
        }

        return false;
    }
}


// ================= TEST PROGRAM =================
class Program
{
    static void Main()
    {
        // a) Create patients

        PediatricPatient p1 = new PediatricPatient
        {
            PatientId = 1,
            Name = "Aman",
            Weight = 25,
            BloodType = BloodType.A,
            DateOfBirth = new DateTime(2015, 5, 5)
        };

        PediatricPatient p2 = new PediatricPatient
        {
            PatientId = 2,
            Name = "Riya",
            Weight = 20,
            BloodType = BloodType.B,
            DateOfBirth = new DateTime(2016, 3, 10)
        };

        GeriatricPatient g1 = new GeriatricPatient
        {
            PatientId = 3,
            Name = "Ram",
            MobilityScore = 5,
            BloodType = BloodType.O,
            DateOfBirth = new DateTime(1950, 2, 2)
        };

        GeriatricPatient g2 = new GeriatricPatient
        {
            PatientId = 4,
            Name = "Shyam",
            MobilityScore = 7,
            BloodType = BloodType.AB,
            DateOfBirth = new DateTime(1945, 8, 8)
        };


        // b) Priority Queue
        PriorityQueue<IPatient> queue = new PriorityQueue<IPatient>();

        queue.Enqueue(p1, 2);
        queue.Enqueue(p2, 1);
        queue.Enqueue(g1, 3);
        queue.Enqueue(g2, 1);


        // c) Medical Records
        MedicalRecord<PediatricPatient> record1 = new(p1);

        record1.AddDiagnosis("Fever", DateTime.Now);
        record1.AddTreatment("Paracetamol", DateTime.Now);


        // d) Medication System
        MedicationSystem<IPatient> medSystem = new();

        // Pediatric: weight must be > 15kg
        Func<IPatient, bool> pediatricRule = p =>
        {
            if (p is PediatricPatient child)
                return child.Weight > 15;

            return true;
        };

        medSystem.PrescribeMedication(p1, "Paracetamol", pediatricRule);
        medSystem.PrescribeMedication(g1, "BP Tablet", p => true);


        // e) Demonstration

        Console.WriteLine("\n--- Processing Patients ---");

        while (true)
        {
            try
            {
                var patient = queue.Dequeue();
                Console.WriteLine("Treating: " + patient.Name);
            }
            catch
            {
                break;
            }
        }


        Console.WriteLine("\n--- Treatment History ---");

        foreach (var item in record1.GetTreatmentHistory())
        {
            Console.WriteLine(item.Key + " : " + item.Value);
        }


        Console.WriteLine("\n--- Interaction Check ---");

        bool hasInteraction = medSystem.CheckInteractions(p1, "Paracetamol");

        Console.WriteLine("Interaction Exists: " + hasInteraction);
    }
}
