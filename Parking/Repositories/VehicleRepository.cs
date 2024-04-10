public class VehicleRepository : IVehicleRepository
{
    private readonly ApplicationDbContext _context;

    public VehicleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Vehicle? GetByCharacteristics(string plate)
    {
        var response = _context.Vehicle.Where(item => item.Plate == plate).ToList().FirstOrDefault();
        return response;
    }

    public List<Vehicle> GetByType(string type)
    {
        var response = _context.Vehicle.Where(item => item.Type == type).ToList();
        return response;
    }
}