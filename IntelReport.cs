using System;

public class IntelReport
{

    public string TerroristName;
    public string LastKnownLocation;
    public DateTime Timestamp;




    public IntelReport(string name, string location, DateTime time)
    {
        TerroristName = name;
        LastKnownLocation = location;
        Timestamp = time;
    }
}