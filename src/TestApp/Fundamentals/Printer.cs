using System;

namespace TestApp.Fundamentals;

// Testing Events

public class Printer
{
    public event EventHandler PrintCompleted;

    public void Print(string content, int copies = 1)
    {
        if (string.IsNullOrEmpty(content))
            throw new ArgumentNullException(nameof(content));

        for (int copy = 1; copy <= copies; copy++)
        {
            Console.WriteLine($"{content} - copy #{copy}");
        }
        

        PrintCompleted?.Invoke(this, EventArgs.Empty);
    }
}
