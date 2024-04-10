public class VehicleUseCase : IVehicleUseCase
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleUseCase(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public Vehicle? GetByCharacteristics(string plate)
    {
        Vehicle? response = _vehicleRepository.GetByCharacteristics(plate);
        return response;
    }

    public List<Vehicle> GetByType(string type)
    {
        List<Vehicle> response = _vehicleRepository.GetByType(type);
        return response;
    }
}