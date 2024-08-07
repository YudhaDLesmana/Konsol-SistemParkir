using System;
using System.Collections.Generic;
using System.Linq;
public static class method
{
    public static Vehicle CekIn(string[] arg){
        Vehicle parked = new Vehicle();
        parked.No = arg[0];
        parked.Colour = arg[1];
        
        VehicleType vehicleType = (VehicleType)Enum.Parse(typeof(VehicleType), arg[2]);
        parked.Tipe = vehicleType;

        return parked;
    }

    public static int CreateParkingLot(){
        Console.Write("$ create_parking_lot: ");
        string input = Console.ReadLine();
        int lot;
        if (input.All(char.IsDigit)){
            Console.WriteLine($"Created a parking lot with {input} slots");
            lot = int.Parse(input);
        }else{
            throw new FormatException();
        }
        return lot;
    }

    public static string[] Input(){
        Console.Write("$ ");
        string input = Console.ReadLine();
        return input.Split(" ");
    }
}