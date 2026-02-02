using System;
using System.Collections.Generic;

// Store creator details
public class CreatorStats
{
    public string CreatorName { get; set; }
    public double[] WeeklyLikes { get; set; }
}

public class Program
{
    // List to store all creators
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

    // Add creator to list
    public void RegisterCreator(CreatorStats record)
    {
        EngagementBoard.Add(record);
    }

    // Get count of posts above threshold
    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (CreatorStats creator in records)
        {
            int count = 0;

            foreach (double like in creator.WeeklyLikes)
            {
                if (like >= likeThreshold)
                {
                    count++;
                }
            }

            if (count > 0)
            {
                result.Add(creator.CreatorName, count);
            }
        }

        return result;
    }

    // Calculate overall average likes
    public double CalculateAverageLikes()
    {
        double total = 0;
        int count = 0;

        foreach (CreatorStats creator in EngagementBoard)
        {
            foreach (double like in creator.WeeklyLikes)
            {
                total += like;
                count++;
            }
        }

        if (count == 0)
            return 0;

        return total / count;
    }

    static void Main(string[] args)
    {
        Program program = new Program();
        bool running = true;

        // Main menu loop
        while (running)
        {
            Console.WriteLine("\n1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice:");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Register new creator
                    CreatorStats creator = new CreatorStats();

                    Console.WriteLine("Enter Creator Name:");
                    creator.CreatorName = Console.ReadLine();

                    creator.WeeklyLikes = new double[4];

                    Console.WriteLine("Enter weekly likes (Week 1 to 4):");

                    for (int i = 0; i < 4; i++)
                    {
                        creator.WeeklyLikes[i] = Convert.ToDouble(Console.ReadLine());
                    }

                    program.RegisterCreator(creator);

                    Console.WriteLine("Creator registered successfully");
                    break;

                case 2:
                    // Show top posts
                    Console.WriteLine("Enter like threshold:");
                    double threshold = Convert.ToDouble(Console.ReadLine());

                    Dictionary<string, int> result =
                        program.GetTopPostCounts(EngagementBoard, threshold);

                    if (result.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach (var item in result)
                        {
                            Console.WriteLine(item.Key + " - " + item.Value);
                        }
                    }
                    break;

                case 3:
                    // Show average likes
                    double avg = program.CalculateAverageLikes();

                    Console.WriteLine("Overall average weekly likes: " + avg);
                    break;

                case 4:
                    // Exit program
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    running = false;
                    break;

                default:
                    // Wrong input
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
