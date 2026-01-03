
// ===============================
// IMPORT REQUIRED NAMESPACES
// ===============================
using System;                     // For Console
using System.Collections.Generic; // For List<T>

// ======================================================
// MODEL NAMESPACE → Contains Plain Classes (POCO classes)
// ======================================================
namespace ExamSchedule.Model
{
    // -------------------------------
    // Student class
    // Represents a single student
    // -------------------------------
    public class Student
    {
        // Default constructor
        public Student()
        {
            // Runs when object is created
        }

        // Student ID
        public int Id { get; set; }

        // Student Name
        public string Name { get; set; }
    }

    // -------------------------------
    // Section class
    // Represents a class/section
    // -------------------------------
    public class Section
    {
        // Default constructor
        public Section()
        {
        }

        // Section ID
        public int Id { get; set; }

        // Section Name
        public string Name { get; set; }
    }

    // --------------------------------------------
    // StudentAndSection class
    // (Currently only declared, can be expanded)
    // --------------------------------------------
    public class StudentAndSection
    {
        // List to hold students (static → shared)
        public static List<Student> Students { get; set; }
    }
}

// ======================================================
// DATA NAMESPACE → Holds hard-coded data (like database)
// ======================================================
namespace ExamSchedule.Data
{
    using ExamSchedule.Model;

    // --------------------------------------------
    // DataBank class → Stores student data
    // --------------------------------------------
    public static class DataBank
    {
        // Private list of students
        private static List<Student> Students = new List<Student>();

        // Static constructor
        // Executes automatically when class is first used
        static DataBank()
        {
            // Adding students to list
            Students.Add(new Student { Id = 1, Name = "Annu" });
            Students.Add(new Student { Id = 2, Name = "Harry" });
            Students.Add(new Student { Id = 3, Name = "Harsh" });
            Students.Add(new Student { Id = 4, Name = "Alice" });
        }

        // Method to return student list
        public static List<Student> GetStudents()
        {
            return Students;
        }
    }

    // --------------------------------------------
    // DataSection class → Stores section data
    // --------------------------------------------
    public static class DataSection
    {
        // Private list of sections
        private static List<Section> Sections = new List<Section>();

        // Static constructor
        static DataSection()
        {
            // Adding sections
            Sections.Add(new Section { Id = 1, Name = "K22QR" });
            Sections.Add(new Section { Id = 2, Name = "K22DM" });
            Sections.Add(new Section { Id = 3, Name = "K22PJ" });
            Sections.Add(new Section { Id = 4, Name = "K22SA" });
            Sections.Add(new Section { Id = 5, Name = "K22JM" });
        }

        // Method to return section list
        public static List<Section> GetSections()
        {
            return Sections;
        }
    }
}

// ======================================================
// MAIN PROGRAM NAMESPACE
// ======================================================
namespace ExamSchedule
{
    using ExamSchedule.Data;

    // -------------------------------
    // Program class
    // Entry point of application
    // -------------------------------
    public class Program
    {
        // Main method → Program starts here
        static void Main(string[] args)
        {
            // Fetch student data from DataBank
            var localStudents = DataBank.GetStudents();

            // Print student details
            Console.WriteLine("---- Students ----");
            foreach (var student in localStudents)
            {
                Console.WriteLine($"{student.Id} - {student.Name}");
            }

            Console.WriteLine();

            // Fetch section data from DataSection
            var localSections = DataSection.GetSections();

            // Print section details
            Console.WriteLine("---- Sections ----");
            foreach (var section in localSections)
            {
                Console.WriteLine($"{section.Id} - {section.Name}");
            }
        }
    }
}
