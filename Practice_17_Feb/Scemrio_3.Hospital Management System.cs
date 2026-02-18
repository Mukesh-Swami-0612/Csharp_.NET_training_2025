using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }

    protected Person(int id, string name, string phone)
    {
        Id = id;
        Name = name;
        Phone = phone;
    }
}

public interface IBillable
{
    decimal CalculateBill();
}

public class Doctor : Person, IBillable
{
    public string Specialization { get; set; }
    public decimal ConsultationFee { get; set; }

    public Doctor(int id, string name, string phone, string specialization, decimal fee)
        : base(id, name, phone)
    {
        Specialization = specialization;
        ConsultationFee = fee;
    }

    public decimal CalculateBill()
    {
        return ConsultationFee;
    }
}

public class Patient : Person, IBillable
{
    public string Disease { get; set; }

    public Patient(int id, string name, string phone, string disease)
        : base(id, name, phone)
    {
        Disease = disease;
    }

    public decimal CalculateBill()
    {
        return 0;
    }
}

public class MedicalRecord
{
    private int recordId;
    private int patientId;
    private string diagnosis;
    private string treatment;

    public int RecordId => recordId;
    public int PatientId => patientId;
    public string Diagnosis => diagnosis;
    public string Treatment => treatment;

    public MedicalRecord(int recordId, int patientId, string diagnosis, string treatment)
    {
        this.recordId = recordId;
        this.patientId = patientId;
        this.diagnosis = diagnosis;
        this.treatment = treatment;
    }
}

public class Appointment
{
    public int AppointmentId { get; set; }
    public Doctor Doctor { get; set; }
    public Patient Patient { get; set; }
    public DateTime Date { get; set; }
    public decimal BillAmount { get; set; }

    public Appointment(int id, Doctor doctor, Patient patient, DateTime date)
    {
        AppointmentId = id;
        Doctor = doctor;
        Patient = patient;
        Date = date;
        BillAmount = doctor.CalculateBill();
    }
}

public class DoctorNotAvailableException : Exception
{
    public DoctorNotAvailableException(string message) : base(message) { }
}

public class InvalidAppointmentException : Exception
{
    public InvalidAppointmentException(string message) : base(message) { }
}

public class PatientNotFoundException : Exception
{
    public PatientNotFoundException(string message) : base(message) { }
}

public class DuplicateMedicalRecordException : Exception
{
    public DuplicateMedicalRecordException(string message) : base(message) { }
}

public class HospitalManagementSystem
{
    public List<Doctor> Doctors = new List<Doctor>();
    public List<Patient> Patients = new List<Patient>();
    public List<Appointment> Appointments = new List<Appointment>();
    public Dictionary<int, MedicalRecord> MedicalRecords = new Dictionary<int, MedicalRecord>();

    public void ScheduleAppointment(Appointment appointment)
    {
        if (appointment.Date < DateTime.Now)
            throw new InvalidAppointmentException("Cannot schedule past appointment");

        bool overlapping = Appointments.Any(a =>
            a.Doctor.Id == appointment.Doctor.Id &&
            a.Date == appointment.Date);

        if (overlapping)
            throw new DoctorNotAvailableException("Doctor already booked at this time");

        Appointments.Add(appointment);
    }

    public void AddMedicalRecord(MedicalRecord record)
    {
        if (!Patients.Any(p => p.Id == record.PatientId))
            throw new PatientNotFoundException("Patient not found");

        if (MedicalRecords.ContainsKey(record.RecordId))
            throw new DuplicateMedicalRecordException("Duplicate medical record");

        MedicalRecords.Add(record.RecordId, record);
    }

    public void ExportAppointmentReport()
    {
        var report = Appointments.Select(a => new
        {
            a.AppointmentId,
            DoctorName = a.Doctor.Name,
            PatientName = a.Patient.Name,
            a.Date,
            a.BillAmount
        });

        foreach (var item in report)
        {
            Console.WriteLine($"{item.AppointmentId} | {item.DoctorName} | {item.PatientName} | {item.Date} | {item.BillAmount}");
        }
    }
}

public class Program
{
    public static void Main()
    {
        var hospital = new HospitalManagementSystem();

        var d1 = new Doctor(1, "Dr. Sharma", "9999999991", "Cardiology", 1000);
        var d2 = new Doctor(2, "Dr. Mehta", "9999999992", "Neurology", 1500);
        var d3 = new Doctor(3, "Dr. Rao", "9999999993", "Orthopedics", 1200);

        hospital.Doctors.AddRange(new[] { d1, d2, d3 });

        var p1 = new Patient(1, "Mukesh", "8888888881", "Heart");
        var p2 = new Patient(2, "Ravi", "8888888882", "Brain");
        var p3 = new Patient(3, "Anita", "8888888883", "Bone");

        hospital.Patients.AddRange(new[] { p1, p2, p3 });

        for (int i = 1; i <= 12; i++)
            hospital.ScheduleAppointment(new Appointment(i, d1, p1, DateTime.Now.AddDays(i)));

        hospital.ScheduleAppointment(new Appointment(20, d2, p2, DateTime.Now.AddDays(1)));
        hospital.ScheduleAppointment(new Appointment(21, d3, p3, DateTime.Now.AddDays(2)));

        hospital.AddMedicalRecord(new MedicalRecord(1, 1, "Cardiac Issue", "Medication"));
        hospital.AddMedicalRecord(new MedicalRecord(2, 2, "Migraine", "Therapy"));
        hospital.AddMedicalRecord(new MedicalRecord(3, 3, "Fracture", "Surgery"));

        var doctorsWithMoreThan10Appointments =
            hospital.Appointments.GroupBy(a => a.Doctor)
            .Where(g => g.Count() > 10)
            .Select(g => g.Key);

        var patientsLast30Days =
            hospital.Appointments
            .Where(a => a.Date >= DateTime.Now.AddDays(-30))
            .Select(a => a.Patient)
            .Distinct();

        var groupedAppointments =
            hospital.Appointments.GroupBy(a => a.Doctor);

        var top3Doctors =
            hospital.Appointments
            .GroupBy(a => a.Doctor)
            .Select(g => new
            {
                Doctor = g.Key,
                Revenue = g.Sum(a => a.BillAmount)
            })
            .OrderByDescending(x => x.Revenue)
            .Take(3);

        var patientsByDisease =
            hospital.Patients.GroupBy(p => p.Disease);

        var totalRevenue =
            hospital.Appointments.Sum(a => a.BillAmount);

        hospital.ExportAppointmentReport();

        Console.WriteLine("Doctors with >10 appointments:");
        foreach (var doc in doctorsWithMoreThan10Appointments)
            Console.WriteLine(doc.Name);

        Console.WriteLine("Top 3 Highest Earning Doctors:");
        foreach (var doc in top3Doctors)
            Console.WriteLine($"{doc.Doctor.Name} - {doc.Revenue}");

        Console.WriteLine("Total Revenue: " + totalRevenue);
    }
}
