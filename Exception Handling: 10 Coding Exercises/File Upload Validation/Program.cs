using System;

class FileUpload
{
    static void Main()
    {
        string fileName = "report.exe";
        int fileSize = 8; // MB

        try
        {
            // Validate file
            ValidateFile(fileName, fileSize);

            // If valid
            Console.WriteLine("File uploaded successfully!");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("Permission Error: " + ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Validation Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("System Error: " + ex.Message);
        }

        Console.ReadLine();
    }

    static void ValidateFile(string name, int size)
    {
        // Allowed extensions
        string[] allowedExtensions = { ".pdf", ".docx", ".txt" };

        // Check file extension
        bool validExtension = false;

        foreach (string ext in allowedExtensions)
        {
            if (name.EndsWith(ext, StringComparison.OrdinalIgnoreCase))
            {
                validExtension = true;
                break;
            }
        }

        if (!validExtension)
        {
            throw new UnauthorizedAccessException("File type not allowed!");
        }

        // Check file size (Max 5 MB)
        if (size > 5)
        {
            throw new ArgumentException("File size exceeds 5 MB limit!");
        }
    }
}
