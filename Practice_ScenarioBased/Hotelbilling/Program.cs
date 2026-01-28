using System;

interface Room
{
    double CalculateTotalBill(int nightsStayed, int joiningYear);
}

public class HotelRoom : Room
{
    private string roomType;
    private double ratePerNight;
    private string guestName;

    public HotelRoom(string roomType, double ratePerNight, string guestName)
    {
        this.roomType = roomType;
        this.ratePerNight = ratePerNight;
        this.guestName = guestName;
    }

    public string RoomType => roomType;
    public double RatePerNight => ratePerNight;
    public string GuestName => guestName;

    // Implemented INSIDE class (fixes error)
    public int CalculateMembershipYears(int joiningYear)
    {
        int currentYear = DateTime.Now.Year;
        return currentYear - joiningYear;
    }

    public double CalculateTotalBill(int nightsStayed, int joiningYear)
    {
        double totalBill = nightsStayed * ratePerNight;
        int membershipYears = CalculateMembershipYears(joiningYear);

        if (membershipYears > 3)
        {
            totalBill = totalBill * 0.9; // 10% discount
        }

        return Math.Round(totalBill);
    }
}

class Program
{
   public  static void Main()
    {
        // Deluxe Room
        Console.WriteLine("Enter Deluxe Room Details:");
        Console.Write("Guest Name: ");
        string deluxeGuest = Console.ReadLine()!;

        Console.Write("Rate per Night: ");
        double deluxeRate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nights Stayed: ");
        int deluxeNights = Convert.ToInt32(Console.ReadLine());

        Console.Write("Joining Year: ");
        int deluxeYear = Convert.ToInt32(Console.ReadLine());

        HotelRoom deluxeRoom = new HotelRoom("Deluxe", deluxeRate, deluxeGuest);

        // Suite Room
        Console.WriteLine("Enter Suite Room Details:");
        Console.Write("Guest Name: ");
        string suiteGuest = Console.ReadLine()!;

        Console.Write("Rate per Night: ");
        double suiteRate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nights Stayed: ");
        int suiteNights = Convert.ToInt32(Console.ReadLine());

        Console.Write("Joining Year: ");
        int suiteYear = Convert.ToInt32(Console.ReadLine());

        HotelRoom suiteRoom = new HotelRoom("Suite", suiteRate, suiteGuest);

        // Output
        Console.WriteLine("Room Summary:");
        Console.WriteLine("Deluxe Room: " + deluxeRoom.GuestName + ", " +
            deluxeRoom.RatePerNight + " per night, Membership: " +
            deluxeRoom.CalculateMembershipYears(deluxeYear) + " years");

        Console.WriteLine("Suite Room: " + suiteRoom.GuestName + ", " +
            suiteRoom.RatePerNight + " per night, Membership: " +
            suiteRoom.CalculateMembershipYears(suiteYear) + " years");

        Console.WriteLine("Total Bill:");
        Console.WriteLine("For " + deluxeRoom.GuestName + " (Deluxe): " +
            deluxeRoom.CalculateTotalBill(deluxeNights, deluxeYear));

        Console.WriteLine("For " + suiteRoom.GuestName + " (Suite): " +
            suiteRoom.CalculateTotalBill(suiteNights, suiteYear));
    }
}
