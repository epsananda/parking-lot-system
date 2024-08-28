using System;
using System.Collections.Generic;
using System.Linq;

public class ParkingSystem
{
    private List<ParkingLot> parkingLots = new List<ParkingLot>();

    public void CreateParkingLot(int slots)
    {
        for (int i = 1; i <= slots; i++)
        {
            parkingLots.Add(new ParkingLot(i));
        }
        Console.WriteLine($"Created a parking lot with {slots} slots");
    }

    public void ParkVehicle(string registrationNumber, string color, string type)
    {
        var availableLot = parkingLots.FirstOrDefault(lot => lot.Vehicle == null);
        if (availableLot == null)
        {
            Console.WriteLine("Sorry, parking lot is full");
            return;
        }

        if (type != "Mobil" && type != "Motor")
        {
            Console.WriteLine("Invalid vehicle type!");
            return;
        }

        availableLot.Vehicle = new Vehicle(registrationNumber, color, type);
        Console.WriteLine($"Allocated slot number: {availableLot.SlotNumber}");
    }

    public void LeaveVehicle(int slotNumber)
    {
        var lot = parkingLots.FirstOrDefault(l => l.SlotNumber == slotNumber);
        if (lot == null || lot.Vehicle == null)
        {
            Console.WriteLine("Slot not found or empty");
            return;
        }

        lot.Vehicle = null;
        Console.WriteLine($"Slot number {slotNumber} is free");
    }

    public void Status()
    {
        Console.WriteLine("Slot    No.     Type    Registration No Colour");
        foreach (var lot in parkingLots)
        {
            if (lot.Vehicle != null)
            {
                Console.WriteLine($"{lot.SlotNumber}    {lot.Vehicle.RegistrationNumber}    {lot.Vehicle.Type}    {lot.Vehicle.Color}");
            }
        }
    }
}
