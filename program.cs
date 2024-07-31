using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using static method;

class Program
{
    public static void Main(string[] args)
    {   
        Dictionary<int, Vehicle> area = new Dictionary<int, Vehicle>();
        List<int> deletedKeys = new List<int>();
        int key = 0;
        
        
        Console.Write("$ create_parking_lot: ");
        string arg = Console.ReadLine();
        Console.WriteLine($"Created a parking lot with {arg} slots");
    
        int jumlah = int.Parse(arg);
        
        while(true){
            
            Console.Write("$");
            string fullCommand = Console.ReadLine();
            string[] commands = fullCommand.Split(' ');
            string command = commands[0];
            if (command =="exit"){
                break;
            }
            
            switch(command){
                case "park":
                if (key < jumlah){
                    string[] v = {commands[1], commands[2], commands[3]};
                    if (deletedKeys.Count > 0){
                        key = deletedKeys.First();
                    } else{
                        key++;
                    }
                    area[key] = CekIn(v);
                    Console.WriteLine($"Allocated slot number: {key}");
                } else{
                    Console.WriteLine("Sorry, parking lot is full");
                }
        
                break;
                case "leave":
                    int indx = int.Parse(commands[1]);
                    deletedKeys.Add(indx);
                    area.Remove(indx);
                    Console.WriteLine($"Slot number {indx} is free");
                break;
                case "status":
                    Console.WriteLine("Slot \t No. \t Type \t Colour");
                    foreach (var vehicle in area)
                    {
                        Console.WriteLine(
                            $"{vehicle.Key} \t {vehicle.Value.No} \t {vehicle.Value.Tipe} \t {vehicle.Value.Colour}");
                    }
                break;
                case "type_of_vehicles":
                    string type = commands[1];
                    VehicleType vehicleT = 
                        (VehicleType)Enum.Parse(typeof(VehicleType), type);
                    int hasil = 0;
                    foreach (var item in area){
                        if(item.Value.Tipe == vehicleT){
                            hasil++;
                        }
                    }
                    Console.WriteLine(hasil);
                    break;
                case "registration_numbers_for_vehicles_with_ood_plate":
                    List<string> listOdd = new List<string>{};
                    foreach (var item in area){
                        string No = item.Value.No;
                        string[] part = No.Split("-");
                        int nomorOdd = int.Parse(part[1]);    
                        if (nomorOdd%2 != 0){
                            listOdd.Add(item.Value.No);
                        }
                    }
                    string resultOdd = string.Join(", ", listOdd);
                    Console.WriteLine(resultOdd);

                    break;
                case "registration_numbers_for_vehicles_with_event_plate":
                    List<string>listEvent = new List<string>{};
                    foreach (var item in area){
                        string No = item.Value.No;
                        string[] part = No.Split("-");
                        int nomorEvent = int.Parse(part[1]);
                        if (nomorEvent%2 == 0){
                            listEvent.Add(item.Value.No);
                        }
                    }
                    string resultEvent = string.Join(", ", listEvent);
                    Console.WriteLine(resultEvent);
                    break;
                case "registration_numbers_for_vehicles_with_colour":
                    string warnaR = commands[1];
                    List<string> listColour = new List<string>{};
                    foreach (var item in area)
                    {
                        if(warnaR == item.Value.Colour){
                            listColour.Add(item.Value.No);
                        }
                    }
                    string resultColour = string.Join(",", listColour);
                    Console.WriteLine(resultColour);
                    break;
                case "slot_numbers_for_vehicles_with_colour":
                    string warnaS = commands[1];
                    List<int> listSlot = new List<int>{};
                    foreach (var item in area)
                    {
                        if (warnaS == item.Value.Colour){
                            listSlot.Add(item.Key);
                        }
                    }
                    string resultSlot = string.Join(", ", listSlot);
                    Console.WriteLine(resultSlot);
                    Console.WriteLine(listSlot.Count);
                    break;
                case "slot_number_for_registration_number":
                    string nomorReg = commands[1];
                    foreach(var item in area)
                    {
                        if(nomorReg == item.Value.No){
                            Console.WriteLine(item.Key);
                        }else{
                            Console.WriteLine("Not Found");
                        }
                    }
                    break;
            }
        }
    }
}