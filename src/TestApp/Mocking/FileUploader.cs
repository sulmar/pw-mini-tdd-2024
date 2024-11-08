using System;

namespace TestApp.Mocking;

// Testing Console
public class FileUploader
{
    public void Upload(string[] files)
    {
        foreach (var file in files)
        {                
            Console.WriteLine($"Uploading {file}...");

            // Upload the file to a storage
            // ...
        }

    }
}
