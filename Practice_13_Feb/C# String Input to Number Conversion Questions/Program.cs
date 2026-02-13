using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // 1. "42" → int
        string s1 = "42";
        int intValue = int.Parse(s1);
        Console.WriteLine("1. Int: " + intValue);

        // 2. "12.34" → double
        string s2 = "12.34";
        double doubleValue = double.Parse(s2);
        Console.WriteLine("2. Double: " + doubleValue);

        // 3. "1 2 3 4" → List<int>
        string s3 = "1 2 3 4";
        string[] parts1 = s3.Split(' ');
        List<int> intList = new List<int>();

        foreach (string p in parts1)
        {
            intList.Add(int.Parse(p));
        }

        Console.WriteLine("3. Integers:");
        foreach (int i in intList)
            Console.Write(i + " ");
        Console.WriteLine();

        // 4. "9.5 8.3 7.1" → List<double>
        string s4 = "9.5 8.3 7.1";
        string[] parts2 = s4.Split(' ');
        List<double> doubleList = new List<double>();

        foreach (string p in parts2)
        {
            doubleList.Add(double.Parse(p));
        }

        Console.WriteLine("4. Doubles:");
        foreach (double d in doubleList)
            Console.Write(d + " ");
        Console.WriteLine();

        // 5. "Fifty" → Not a number validation
        string s5 = "Fifty";

        if (!double.TryParse(s5, out _))
        {
            Console.WriteLine("5. 'Fifty' is NOT a number");
        }

        // 6. "15.7abc" → Extract numeric part
        string s6 = "15.7abc";

        string numberOnly = Regex.Match(s6, @"\d+(\.\d+)?").Value;
        double extracted = double.Parse(numberOnly);

        Console.WriteLine("6. Extracted Number: " + extracted);

        // 7. "999999999" → long
        string s7 = "999999999";
        long longValue = long.Parse(s7);

        Console.WriteLine("7. Long: " + longValue);

        // 8. "0xFF" → Hex to int
        string s8 = "0xFF";

        int hexValue = Convert.ToInt32(s8, 16);

        Console.WriteLine("8. Hex to Int: " + hexValue);

        // 9. "3E+3" → Scientific notation to double
        string s9 = "3E+3";

        double scientific = double.Parse(
            s9,
            NumberStyles.Float,
            CultureInfo.InvariantCulture
        );

        Console.WriteLine("9. Scientific Double: " + scientific);

        // 10. "42.5 36.1 -12" → Mixed positive & negative numbers
        string s10 = "42.5 36.1 -12";

        string[] parts3 = s10.Split(' ');
        List<double> mixedList = new List<double>();

        foreach (string p in parts3)
        {
            mixedList.Add(double.Parse(p));
        }

        Console.WriteLine("10. Mixed Numbers:");
        foreach (double d in mixedList)
            Console.Write(d + " ");
        Console.WriteLine();
    }
}
