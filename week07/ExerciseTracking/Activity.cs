using System;
using System.Globalization;

public abstract class Activity
{
    private DateTime _date;
    private int _length;

    public Activity(DateTime date, int length)
    {
        _date = date;
        _length = length;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public int GetLength()
    {
        return _length;
    }

    public abstract string GetActivityName();
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        string date = _date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
        string distance = GetDistance().ToString("0.0", CultureInfo.InvariantCulture);
        string speed = GetSpeed().ToString("0.0", CultureInfo.InvariantCulture);
        string pace = GetPace().ToString("0.00", CultureInfo.InvariantCulture);

        return $"{date} {GetActivityName()} ({_length} min): Distance: {distance} km, Speed: {speed} kph, Pace: {pace} min per km";
    }
}
