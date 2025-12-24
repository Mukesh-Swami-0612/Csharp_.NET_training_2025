using System;
using System.Collections.Generic;

namespace ExaminationDepartment
{
    // -------------------- COURSE CLASS --------------------
    // Stores course information
    class Course
    {
        public int CourseId;
        public string CourseName;
    }

    // -------------------- DEPARTMENT CLASS --------------------
    // Stores department details
    class Department
    {
        public int DeptId;
        public string DeptName;
    }

    // -------------------- EMPLOYEE CLASS --------------------
    // Used for Examiner / HOD etc.
    class Emp
    {
        public int EmpId;
        public string EmpName;
        public string Role;       // Examiner
        public int DeptId;
    }

    // -------------------- STUDENT CLASS --------------------
    // Stores student details
    class Student
    {
        public int StuId;
        public string StuName;
        public int Semester;
        public int CourseId;
    }

    // -------------------- EXAM CLASS --------------------
    // Represents an exam
    class Exam
    {
        public int ExamId;
        public string ExamName;
        public int CourseId;
    }

    // -------------------- EXAM SCHEDULE CLASS --------------------
    // Represents exam date, shift, room, examiner
    class ExamSchedule
    {
        public int ScheduleId;
        public DateTime ExamDate;
        public string Shift;
        public int ExamId;
        public int RoomNo;
        public int Block;
        public int ExaminerId;
    }

    // -------------------- ATTENDANCE CLASS --------------------
    // Stores attendance of students
    class MarkAttendance
    {
        public int AttendanceId;
        public int StuId;
        public int ScheduleId;
        public string Status;     // Present / Absent
    }

    // -------------------- MAIN PROGRAM --------------------
    class Program
    {
        static void Main(string[] args)
        {
            // -------------------- COURSE --------------------
            Course course = new Course();
            course.CourseId = 1;
            course.CourseName = "Computer Science";

            // -------------------- STUDENTS (2nd SEMESTER) --------------------
            List<Student> students = new List<Student>();

            // Creating 10 students (2 rooms × 5 students)
            for (int i = 1; i <= 10; i++)
            {
                Student s = new Student();
                s.StuId = i;
                s.StuName = "Student" + i;
                s.Semester = 2;
                s.CourseId = 1;

                students.Add(s);
            }

            // -------------------- EXAMINERS --------------------
            Emp examiner1 = new Emp();
            examiner1.EmpId = 1;
            examiner1.EmpName = "Examiner A";
            examiner1.Role = "Examiner";

            Emp examiner2 = new Emp();
            examiner2.EmpId = 2;
            examiner2.EmpName = "Examiner B";
            examiner2.Role = "Examiner";

            // -------------------- EXAMS --------------------
            List<Exam> exams = new List<Exam>();

            // Total exams = 2 days × 3 exams per day = 6 exams
            for (int i = 1; i <= 6; i++)
            {
                Exam ex = new Exam();
                ex.ExamId = i;
                ex.ExamName = "Exam " + i;
                ex.CourseId = 1;

                exams.Add(ex);
            }

            // -------------------- EXAM SCHEDULE --------------------
            List<ExamSchedule> schedules = new List<ExamSchedule>();

            DateTime startDate = DateTime.Today;
            int scheduleId = 1;

            // Loop for 2 days
            for (int day = 0; day < 2; day++)
            {
                // Loop for 3 exams per day
                for (int e = 1; e <= 3; e++)
                {
                    ExamSchedule sch = new ExamSchedule();
                    sch.ScheduleId = scheduleId;
                    sch.ExamDate = startDate.AddDays(day);
                    sch.Shift = "Shift " + e;
                    sch.ExamId = scheduleId;

                    // Alternate rooms 1 and 2
                    sch.RoomNo = (scheduleId % 2 == 0) ? 2 : 1;
                    sch.Block = 30;

                    // Alternate examiners
                    sch.ExaminerId = (scheduleId % 2 == 0) ? examiner2.EmpId : examiner1.EmpId;

                    schedules.Add(sch);
                    scheduleId++;
                }
            }

            // -------------------- ATTENDANCE --------------------
            List<MarkAttendance> attendanceList = new List<MarkAttendance>();
            int attendanceId = 1;

            // Each exam has 5 students
            foreach (ExamSchedule sch in schedules)
            {
                for (int i = 0; i < 5; i++)
                {
                    MarkAttendance at = new MarkAttendance();
                    at.AttendanceId = attendanceId++;
                    at.StuId = students[i].StuId;
                    at.ScheduleId = sch.ScheduleId;
                    at.Status = "Present";

                    attendanceList.Add(at);
                }
            }

            // -------------------- OUTPUT --------------------
            Console.WriteLine("===== EXAMINATION SCHEDULE =====\n");

            foreach (ExamSchedule sch in schedules)
            {
                Console.WriteLine("Schedule ID : " + sch.ScheduleId);
                Console.WriteLine("Date        : " + sch.ExamDate.ToShortDateString());
                Console.WriteLine("Shift       : " + sch.Shift);
                Console.WriteLine("Room        : " + sch.RoomNo);
                Console.WriteLine("Block       : " + sch.Block);
                Console.WriteLine("Examiner ID : " + sch.ExaminerId);
                Console.WriteLine("--------------------------------");
            }

            Console.ReadLine();
        }
    }
}
