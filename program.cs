using System;
using System.Collections.Generic;
using System.Linq;
using static method;

class Program
{
static private Dictionary<int, Vehicle> Parking = new Dictionary<int, Vehicle>();
static private List<int> DeletedKey = new List<int>();
static private int key = 1;
public static void Main(string[] args)
{   
while(true){
try
{
    int Lot = CreateParkingLot(); 

    while(true){
    string[] commands = Input();
    string command = commands[0];

    switch(command){
        
        case "park":
        string[] arg = {commands[1],commands[2],commands[3]}; 
        Vehicle vehicle = CekIn(arg); 
        vehicle.Park = DateTime.Now;
        if(Parking.Count < Lot){ 
            if(DeletedKey.Count>0){ 
                int useDeletedKey = DeletedKey.First(); 
                Parking[useDeletedKey] = vehicle;
                Console.WriteLine($"Allocated slot number: {useDeletedKey}");
                DeletedKey.Remove(useDeletedKey);
            }else{
                Parking[key] = vehicle;
                Console.WriteLine($"Allocated slot number: {key}");
                key++;
            }
        } else{
            Console.WriteLine("Sorry, parking lot is full");
        }
        break;

        case "leave": // remove vehicle from parkinglot
        int indx = int.Parse(commands[1]);
        DateTime Leaving = DateTime.Now;
        Vehicle Leave = Parking[indx];
        if (!DeletedKey.Contains(indx) && indx <= Lot){
            DeletedKey.Add(indx);
            TimeSpan diff = Leaving.Subtract(Leave.Park);

            Console.WriteLine($"{Leave.No} for {diff}");
            Console.WriteLine($"Slot number {indx} is free ");
            Parking.Remove(indx);    
        }else{
            Console.WriteLine($"{indx} is empty");
        }
        break;

        case "status": 
        Console.WriteLine("Slot \t No. \t \t Type \t Colour  Parking");
        List<int> sortKey = Parking.Keys.ToList();
        sortKey.Sort();
        foreach(var k in sortKey)
        {
             Console.WriteLine(
                $"{k} \t {Parking[k].No} \t {Parking[k].Tipe} \t {Parking[k].Colour} \t {Parking[k].Park}" );
        }
        break;
    }
    if (command == "exit"){
    break;
    }
    
    }
}
catch (System.FormatException)
{
    Console.WriteLine("Wrong input, use numbers!!!");
    continue;
}   
    break; 
}
}
}