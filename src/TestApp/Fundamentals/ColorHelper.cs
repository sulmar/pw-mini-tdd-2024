namespace TestApp.Fundamentals;

// Boundary Test
public class ColorHelper
{
    static string DetermineColor(int percentage)
    {
        // Thresholds
        if (percentage >= 0 && percentage < 50)
        {
            return "Green";
        }
        else if (percentage > 50 && percentage <= 80)
        {
            return "Yellow";
        }
        else
        {
            return "Red";
        }
    }
}
