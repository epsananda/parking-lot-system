public class ParkingLot
{
    public int SlotNumber { get; set; }
    public Vehicle? Vehicle { get; set; }

    public ParkingLot(int slotNumber)
    {
        SlotNumber = slotNumber;
    }
}
