public interface IVehicleUseCase
{
    public Vehicle? GetByCharacteristics(string plate);
    public List<Vehicle> GetByType(string type);
}