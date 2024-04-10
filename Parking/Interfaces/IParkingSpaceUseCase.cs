public interface IParkingSpaceUseCase
{
    public ParkingSpace Register(ParkingSpaceEntryDTO data);
    public List<ParkingSpace> GetAvailableParkingSpaces(string vehicleType);
    public void AddVehicle(List<ParkingSpace> parkingSpaces, Vehicle vehicle);
    public void RemoveVehicle(int id);
    public int SumAvailableParkingSpaces();
    public int SumParkingSpaces();
    public int SumVanParkingSpaces();
    public bool CheckParkingIsAbsolutelyFull();
    public bool CheckParkingIsEmpty();
}