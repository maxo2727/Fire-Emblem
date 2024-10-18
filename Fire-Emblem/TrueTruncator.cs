namespace Fire_Emblem;

public class TrueTruncator
{
    public static int Truncate(double value)
    {
        double roundedValue = Math.Round(value, 9);
        int truncatedValue = (int)Math.Floor(roundedValue);
        return truncatedValue;
    }
}