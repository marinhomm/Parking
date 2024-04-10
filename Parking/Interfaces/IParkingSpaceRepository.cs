public interface IParkingSpaceRepository
{
    public ParkingSpace Save(ParkingSpace parkingSpace);
    public IOrderedQueryable<ParkingSpace> GetMotorcycleParkingSpaces();
    public IOrderedQueryable<ParkingSpace> GetCarParkingSpaces();
    public IOrderedQueryable<ParkingSpace> GetVanParkingSpaces();
    public void Update(ParkingSpace parkingSpace);
    public List<ParkingSpace>? GetByVehicleId(int vehicleId);
    public List<ParkingSpace> Get();
    public bool GetNotNullVehicle();
}