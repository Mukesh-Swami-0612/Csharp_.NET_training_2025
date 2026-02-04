
using System;
using System.IO;

class FileReader
{
    static void Main()
    {
        string filePath = "data.txt";

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine("File Content:");
                Console.WriteLine(content);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("File operation completed.");
        }
    }
}
