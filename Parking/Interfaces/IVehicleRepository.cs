public interface IVehicleRepository
{
    public Vehicle? GetByCharacteristics(string plate);
    public List<Vehicle> GetByType(string type);
}