class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("                    Welcome to the Parking System!");
        Console.WriteLine("          Please enter the command to start using the system.");
        Console.WriteLine("         Enter the 'exit' command to exit the parking system.");
        Console.WriteLine("              ******************************************");
        Console.WriteLine(" ");

        var parkingSystem = new ParkingSystem();
        string? command;

        while (true)
        {
            Console.Write("Enter Command: ");
            command = Console.ReadLine();

            if (command == "exit")
            {
                Console.WriteLine("Thank you for using this system!");
                break;
            }
            if (string.IsNullOrWhiteSpace(command))
            {
                Console.WriteLine("Invalid command format!");
                continue;
            }

            var parts = command.Split(' ', 2);
            if (parts.Length == 0 || string.IsNullOrWhiteSpace(parts[0]))
            {
                Console.WriteLine("Invalid command format!");
                continue;
            }

            switch (parts[0])
            {
                case "create_parking_lot":
                    if (parts.Length == 2 && int.TryParse(parts[1], out int slots))
                        parkingSystem.CreateParkingLot(slots);
                    else
                        Console.WriteLine("Invalid command format!");
                    break;

                case "park":
                    if (parts.Length == 2)
                    {
                        var parkArgs = parts[1].Split(' ');
                        if (parkArgs.Length == 3)
                            parkingSystem.ParkVehicle(parkArgs[0], parkArgs[1], parkArgs[2]);
                        else
                            Console.WriteLine("Invalid command format!");
                    }
                    else
                        Console.WriteLine("Invalid command format!");
                    break;

                case "leave":
                    if (parts.Length == 2 && int.TryParse(parts[1], out int slotNumber))
                        parkingSystem.LeaveVehicle(slotNumber);
                    else
                        Console.WriteLine("Invalid command format!");
                    break;

                case "status":
                    parkingSystem.Status();
                    break;

                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }
    }
}
