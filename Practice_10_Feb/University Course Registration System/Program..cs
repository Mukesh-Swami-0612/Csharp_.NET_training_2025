
using System;
using System.Collections.Generic;
using System.Linq;

// Base constraints
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

// 1. Generic enrollment system
public class EnrollmentSystem<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private Dictionary<TCourse, List<TStudent>> _enrollments = new();

    // TODO: Enroll student with constraints
    public bool EnrollStudent(TStudent student, TCourse course)
    {
        // Rules:
        // - Course not at capacity
        // - Student not already enrolled
        // - Student semester >= course prerequisite (if any)
        // - Return success/failure with reason

        if (!_enrollments.ContainsKey(course))
            _enrollments[course] = new List<TStudent>();

        var list = _enrollments[course];

        if (list.Count >= course.MaxCapacity)
        {
            Console.WriteLine("Course Full");
            return false;
        }

        if (list.Any(s => s.StudentId == student.StudentId))
        {
            Console.WriteLine("Already Enrolled");
            return false;
        }

        if (course is LabCourse lab)
        {
            if (student.Semester < lab.RequiredSemester)
            {
                Console.WriteLine("Prerequisite Not Met");
                return false;
            }
        }

        list.Add(student);
        return true;
    }

    // TODO: Get students for course
    public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
    {
        // Return immutable list

        if (!_enrollments.ContainsKey(course))
            return new List<TStudent>();

        return _enrollments[course].AsReadOnly();
    }

    // TODO: Get courses for student
    public IEnumerable<TCourse> GetStudentCourses(TStudent student)
    {
        // Return courses student is enrolled in

        return _enrollments
            .Where(e => e.Value.Any(s => s.StudentId == student.StudentId))
            .Select(e => e.Key);
    }

    // TODO: Calculate student workload
    public int CalculateStudentWorkload(TStudent student)
    {
        // Sum credits of all enrolled courses

        return GetStudentCourses(student).Sum(c => c.Credits);
    }

    public bool IsEnrolled(TStudent s, TCourse c)
    {
        return _enrollments.ContainsKey(c) &&
               _enrollments[c].Any(x => x.StudentId == s.StudentId);
    }
}

// 2. Specialized implementations
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
    public int RequiredSemester { get; set; } // Prerequisite
}

// 3. Generic gradebook
public class GradeBook<TStudent, TCourse>
{
    private Dictionary<(TStudent, TCourse), double> _grades = new();

    private EnrollmentSystem<TStudent, TCourse> _system;

    public GradeBook(EnrollmentSystem<TStudent, TCourse> system)
    {
        _system = system;
    }

    // TODO: Add grade with validation
    public void AddGrade(TStudent student, TCourse course, double grade)
    {
        // Grade must be between 0 and 100
        // Student must be enrolled in course

        if (grade < 0 || grade > 100)
            throw new Exception("Invalid Grade");

        if (!_system.IsEnrolled(student, course))
            throw new Exception("Not Enrolled");

        _grades[(student, course)] = grade;
    }

    // TODO: Calculate GPA for student
    public double? CalculateGPA(TStudent student)
    {
        // Weighted by course credits
        // Return null if no grades

        var records = _grades
            .Where(g => g.Key.Item1.Equals(student))
            .ToList();

        if (records.Count == 0)
            return null;

        double total = 0;
        int credits = 0;

        foreach (var r in records)
        {
            var course = r.Key.Item2;
            total += r.Value * course.Credits;
            credits += course.Credits;
        }

        return total / credits;
    }

    // TODO: Find top student in course
    public (TStudent student, double grade)? GetTopStudent(TCourse course)
    {
        // Return student with highest grade

        var list = _grades
            .Where(g => g.Key.Item2.Equals(course))
            .OrderByDescending(g => g.Value)
            .FirstOrDefault();

        if (list.Key.Item1 == null)
            return null;

        return (list.Key.Item1, list.Value);
    }
}

// ================= TEST =================

class UniversityTest
{
    static void Main2()
    {
        var system = new EnrollmentSystem<EngineeringStudent, LabCourse>();

        // a) Create 3 EngineeringStudent instances

        var s1 = new EngineeringStudent { StudentId = 1, Name = "Aman", Semester = 3 };
        var s2 = new EngineeringStudent { StudentId = 2, Name = "Ravi", Semester = 1 };
        var s3 = new EngineeringStudent { StudentId = 3, Name = "Neha", Semester = 4 };

        // b) Create 2 LabCourse instances

        var c1 = new LabCourse
        {
            CourseCode = "CS101",
            Title = "Programming Lab",
            MaxCapacity = 2,
            Credits = 4,
            RequiredSemester = 2
        };

        var c2 = new LabCourse
        {
            CourseCode = "CS201",
            Title = "Network Lab",
            MaxCapacity = 1,
            Credits = 3,
            RequiredSemester = 3
        };

        // Enrollment

        system.EnrollStudent(s1, c1); // OK
        system.EnrollStudent(s2, c1); // Fail
        system.EnrollStudent(s3, c1); // OK
        system.EnrollStudent(s3, c2); // OK
        system.EnrollStudent(s1, c2); // Fail (full)

        var gradeBook = new GradeBook<EngineeringStudent, LabCourse>(system);

        // Grades

        gradeBook.AddGrade(s1, c1, 85);
        gradeBook.AddGrade(s3, c1, 92);
        gradeBook.AddGrade(s3, c2, 88);

        // GPA

        Console.WriteLine("GPA S1: " + gradeBook.CalculateGPA(s1));
        Console.WriteLine("GPA S3: " + gradeBook.CalculateGPA(s3));

        // Top Student

        var top = gradeBook.GetTopStudent(c1);

        if (top != null)
        {
            Console.WriteLine("Top in CS101: " +
                top.Value.student.Name +
                " - " + top.Value.grade);
        }
    }
}
