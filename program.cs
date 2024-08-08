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
    int Lot = CreateParkingLot(); //tentukan jumlah lot

    while(true){ // infinite loop command
    string[] commands = Input();
    string command = commands[0];

    switch(command){
        
        case "park":
        { // command for adding vehicle to parkinglot
        string[] arg = {commands[1],commands[2],commands[3]}; // collect arg for create vehicle
        Vehicle vehicle = CekIn(arg); //create vehicle =
        if(Parking.Count < Lot){ // add vehicle to parking lot is slot in it 
            if(DeletedKey.Count>0){ // if there is 
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
        }

        case "leave": // remove vehicle from parkinglot
        int indx = int.Parse(commands[1]);
        if (!DeletedKey.Contains(indx) && indx <= Lot){
            DeletedKey.Add(indx);
            Parking.Remove(indx);    
            Console.WriteLine($"Slot number {indx} is free");
        }else{
            Console.WriteLine($"{indx} is empty");
        }
        break;

        case "status": // show vehicle in parkinglot, 
        
        Console.WriteLine("Slot \t No. \t \t Type \t Colour");
        List<int> sortKey = Parking.Keys.ToList();
        sortKey.Sort();
        foreach(var k in sortKey)
        {
             Console.WriteLine(
                    $"{k} \t {Parking[k].No} \t {Parking[k].Tipe} \t {Parking[k].Colour}"
                    );
        }
        break;
    }
        if (command == "exit"){ //stop program 
        break;
        }
    
    }
}
// jika input awal bukan bilangan akan memberi message "Wrong input, use numbers!!!" 
// dan meminta input ulang untuk jumlah lot
catch (System.FormatException)
{
    Console.WriteLine("Wrong input, use numbers!!!");
    continue;
}   
    break; 
}
}
}
        //         case "type_of_vehicles":
        //             string type = commands[1];
        //             VehicleType vehicleT = 
        //                 (VehicleType)Enum.Parse(typeof(VehicleType), type);
        //             int hasil = 0;
        //             foreach (var item in area){
        //                 if(item.Value.Tipe == vehicleT){
        //                     hasil++;
        //                 }
        //             }
        //             Console.WriteLine(hasil);
        //             break;
        //         case "registration_numbers_for_vehicles_with_ood_plate":
        //             List<string> listOdd = new List<string>{};
        //             foreach (var item in area){
        //                 string No = item.Value.No;
        //                 string[] part = No.Split("-");
        //                 int nomorOdd = int.Parse(part[1]);    
        //                 if (nomorOdd%2 != 0){
        //                     listOdd.Add(item.Value.No);
        //                 }
        //             }
        //             string resultOdd = string.Join(", ", listOdd);
        //             Console.WriteLine(resultOdd);

        //             break;
        //         case "registration_numbers_for_vehicles_with_event_plate":
        //             List<string>listEvent = new List<string>{};
        //             foreach (var item in area){
        //                 string No = item.Value.No;
        //                 string[] part = No.Split("-");
        //                 int nomorEvent = int.Parse(part[1]);
        //                 if (nomorEvent%2 == 0){
        //                     listEvent.Add(item.Value.No);
        //                 }
        //             }
        //             string resultEvent = string.Join(", ", listEvent);
        //             Console.WriteLine(resultEvent);
        //             break;
        //         case "registration_numbers_for_vehicles_with_colour":
        //             string warnaR = commands[1];
        //             List<string> listColour = new List<string>{};
        //             foreach (var item in area)
        //             {
        //                 if(warnaR == item.Value.Colour){
        //                     listColour.Add(item.Value.No);
        //                 }
        //             }
        //             string resultColour = string.Join(",", listColour);
        //             Console.WriteLine(resultColour);
        //             break;
        //         case "slot_numbers_for_vehicles_with_colour":
        //             string warnaS = commands[1];
        //             List<int> listSlot = new List<int>{};
        //             foreach (var item in area)
        //             {
        //                 if (warnaS == item.Value.Colour){
        //                     listSlot.Add(item.Key);
        //                 }
        //             }
        //             string resultSlot = string.Join(", ", listSlot);
        //             Console.WriteLine(resultSlot);
        //             Console.WriteLine(listSlot.Count);
        //             break;
        //         case "slot_number_for_registration_number":
                    // string nomorReg = commands[1];
                    // foreach(var item in area)
                    // {
                    //     if(nomorReg == item.Value.No){
                    //         Console.WriteLine(item.Key);
                    //     }else{
                    //         Console.WriteLine("Not Found");
                    //     }
                    // }
                    // break;
        //     }
        // }
//     }
// }