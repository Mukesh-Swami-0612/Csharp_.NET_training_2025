using System;
using System.Collections.Generic;
using System.Linq;

public interface IStudent
{
    int StudentId { get; }
    string Name { get; }
    int Semester { get; }
}

public interface ICourse
{
    string CourseCode { get; }
    string Title { get; }
    int MaxCapacity { get; }
    int Credits { get; }
}

public class EnrollmentSystem<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private Dictionary<TCourse, List<TStudent>> _enrollments = new();

    public bool EnrollStudent(TStudent student, TCourse course)
    {
        if (!_enrollments.ContainsKey(course))
            _enrollments[course] = new List<TStudent>();

        if (_enrollments[course].Count >= course.MaxCapacity)
        {
            Console.WriteLine("Enrollment failed: Course at capacity");
            return false;
        }

        if (_enrollments[course].Any(s => s.StudentId == student.StudentId))
        {
            Console.WriteLine("Enrollment failed: Student already enrolled");
            return false;
        }

        if (course is LabCourse lab && student.Semester < lab.RequiredSemester)
        {
            Console.WriteLine("Enrollment failed: Prerequisite not satisfied");
            return false;
        }

        _enrollments[course].Add(student);
        Console.WriteLine($"Enrollment successful: {student.Name} -> {course.Title}");
        return true;
    }

    public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
    {
        if (_enrollments.ContainsKey(course))
            return _enrollments[course].AsReadOnly();

        return new List<TStudent>().AsReadOnly();
    }

    public IEnumerable<TCourse> GetStudentCourses(TStudent student)
    {
        return _enrollments
            .Where(x => x.Value.Any(s => s.StudentId == student.StudentId))
            .Select(x => x.Key);
    }

    public int CalculateStudentWorkload(TStudent student)
    {
        return GetStudentCourses(student).Sum(c => c.Credits);
    }
}

public class EngineeringStudent : IStudent
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Semester { get; set; }
    public string Specialization { get; set; }
}

public class LabCourse : ICourse
{
    public string CourseCode { get; set; }
    public string Title { get; set; }
    public int MaxCapacity { get; set; }
    public int Credits { get; set; }
    public string LabEquipment { get; set; }
    public int RequiredSemester { get; set; }
}

public class GradeBook<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private Dictionary<(TStudent, TCourse), double> _grades = new();
    private EnrollmentSystem<TStudent, TCourse> _enrollmentSystem;

    public GradeBook(EnrollmentSystem<TStudent, TCourse> enrollmentSystem)
    {
        _enrollmentSystem = enrollmentSystem;
    }

    public void AddGrade(TStudent student, TCourse course, double grade)
    {
        if (grade < 0 || grade > 100)
            throw new Exception("Grade must be between 0 and 100");

        var students = _enrollmentSystem.GetEnrolledStudents(course);
        if (!students.Any(s => s.StudentId == student.StudentId))
            throw new Exception("Student not enrolled in course");

        _grades[(student, course)] = grade;
        Console.WriteLine($"Grade added: {student.Name} -> {course.Title} = {grade}");
    }

    public double? CalculateGPA(TStudent student)
    {
        var studentGrades = _grades
            .Where(x => x.Key.Item1.StudentId == student.StudentId)
            .ToList();

        if (!studentGrades.Any())
            return null;

        double totalPoints = 0;
        int totalCredits = 0;

        foreach (var entry in studentGrades)
        {
            totalPoints += entry.Value * entry.Key.Item2.Credits;
            totalCredits += entry.Key.Item2.Credits;
        }

        return totalPoints / totalCredits;
    }

    public (TStudent student, double grade)? GetTopStudent(TCourse course)
    {
        var courseGrades = _grades
            .Where(x => x.Key.Item2.CourseCode == course.CourseCode)
            .ToList();

        if (!courseGrades.Any())
            return null;

        var top = courseGrades.OrderByDescending(x => x.Value).First();
        return (top.Key.Item1, top.Value);
    }
}
class Program
{
    static void Main()
    {
        var enrollment = new EnrollmentSystem<EngineeringStudent, LabCourse>();

        Console.Write("How many students? ");
        int studentCount = int.Parse(Console.ReadLine());

        List<EngineeringStudent> students = new();

        for (int i = 0; i < studentCount; i++)
        {
            Console.WriteLine($"\nStudent {i + 1}");

            Console.Write("Student ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Semester: ");
            int semester = int.Parse(Console.ReadLine());

            Console.Write("Specialization: ");
            string spec = Console.ReadLine();

            students.Add(new EngineeringStudent
            {
                StudentId = id,
                Name = name,
                Semester = semester,
                Specialization = spec
            });
        }

        Console.Write("\nHow many courses? ");
        int courseCount = int.Parse(Console.ReadLine());

        List<LabCourse> courses = new();

        for (int i = 0; i < courseCount; i++)
        {
            Console.WriteLine($"\nCourse {i + 1}");

            Console.Write("Course Code: ");
            string code = Console.ReadLine();

            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Max Capacity: ");
            int capacity = int.Parse(Console.ReadLine());

            Console.Write("Credits: ");
            int credits = int.Parse(Console.ReadLine());

            Console.Write("Lab Equipment: ");
            string equipment = Console.ReadLine();

            Console.Write("Required Semester: ");
            int requiredSem = int.Parse(Console.ReadLine());

            courses.Add(new LabCourse
            {
                CourseCode = code,
                Title = title,
                MaxCapacity = capacity,
                Credits = credits,
                LabEquipment = equipment,
                RequiredSemester = requiredSem
            });
        }

        Console.WriteLine("\n--- ENROLLMENT PHASE ---");

        foreach (var student in students)
        {
            foreach (var course in courses)
            {
                Console.WriteLine($"\nEnroll {student.Name} in {course.Title}? (y/n)");
                string choice = Console.ReadLine().ToLower();

                if (choice == "y")
                    enrollment.EnrollStudent(student, course);
            }
        }

        var gradeBook = new GradeBook<EngineeringStudent, LabCourse>(enrollment);

        Console.WriteLine("\n--- GRADE ENTRY PHASE ---");

        foreach (var student in students)
        {
            foreach (var course in courses)
            {
                var enrolled = enrollment.GetEnrolledStudents(course)
                    .Any(s => s.StudentId == student.StudentId);

                if (enrolled)
                {
                    Console.Write($"Enter grade for {student.Name} in {course.Title}: ");
                    double grade = double.Parse(Console.ReadLine());

                    gradeBook.AddGrade(student, course, grade);
                }
            }
        }

        Console.WriteLine("\n--- GPA RESULTS ---");

        foreach (var student in students)
        {
            var gpa = gradeBook.CalculateGPA(student);
            Console.WriteLine($"{student.Name} GPA: {gpa}");
        }

        Console.WriteLine("\n--- TOP STUDENT PER COURSE ---");

        foreach (var course in courses)
        {
            var top = gradeBook.GetTopStudent(course);

            if (top != null)
                Console.WriteLine($"{course.Title} Topper: {top?.student.Name} ({top?.grade})");
            else
                Console.WriteLine($"{course.Title} - No grades available");
        }
    }
}
