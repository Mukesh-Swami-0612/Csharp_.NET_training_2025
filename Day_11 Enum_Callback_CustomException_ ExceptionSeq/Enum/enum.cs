using System;  // We use this to get Console.WriteLine() and other basic features

namespace EnumSchedule   // Namespace is like a container for our program
{
    // Enum = Collection of fixed values (constant values)
    // Here we are making an enum for Semester
    public enum Semester
    {
        FirstSemester,   // 0
        SecondSemester   // 1
    }

    // Enum for Subjects
    public enum Subject
    {
        Math,      // 0
        Python,    // 1
        Physics    // 2
    }

    // Enum for Week Days
    public enum WeekDay
    {
        Monday,     // 0
        Tuesday,    // 1
        Wednesday,  // 2
        Thursday,   // 3
        Friday      // 4
    }

    public class Schedule   // Main class of the program
    {
        public static void Main(string[] args)
        {
            // Here we are selecting the semester
            Semester semester = Semester.FirstSemester;

            // Here we are selecting the day
            WeekDay day = WeekDay.Monday;

            // Calling ScheduleDay() method to find the subject for the given semester and day
            Subject subject = ScheduleDay(semester, day);

            // Printing the output on screen
            Console.WriteLine($"Semester : {semester}");
            Console.WriteLine($"Day      : {day}");
            Console.WriteLine($"Subject  : {subject}");
        }

        // This method will return the Subject based on semester and day
        public static Subject ScheduleDay(Semester semester, WeekDay day)
        {
            // Checking if the semester is FirstSemester
            if (semester == Semester.FirstSemester)
            {
                // switch case is used to match different days
                switch (day)
                {
                    case WeekDay.Monday:
                        return Subject.Math;   // Monday subject is Math

                    case WeekDay.Tuesday:
                        return Subject.Python; // Tuesday subject is Python

                    case WeekDay.Wednesday:
                        return Subject.Physics; // Wednesday subject is Physics

                    case WeekDay.Thursday:
                        return Subject.Math;    // Thursday subject is Math

                    case WeekDay.Friday:
                        return Subject.Python;  // Friday subject is Python
                }
            }

            // If no condition matches, then by default returning Math
            return Subject.Math;
        }
    }
}
