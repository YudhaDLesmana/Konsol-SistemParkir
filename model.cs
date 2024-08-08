using System;

public class Vehicle   
{
    public VehicleType Tipe {get; set;}
    public string No {get; set;}
    public string Colour {get; set;}
    public DateTime Park {get; set;}
    // public DateTime Leave {get; set;}
}
public enum VehicleType
{
    Mobil,
    Motor
}