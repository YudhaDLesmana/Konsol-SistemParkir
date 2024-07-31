using System;
using System.Collections.Generic;
public static class method
{
    public static Vehicle CekIn(string[] arg){
        VehicleType vehicleType = (VehicleType)Enum.Parse(typeof(VehicleType), arg[2]);

        Vehicle parked = new Vehicle();
        parked.No = arg[0];
        parked.Colour = arg[1];
        parked.Tipe = vehicleType;

        return parked;
    }
    
}
