public class ParkingSpaceRepository : IParkingSpaceRepository
{
    private readonly ApplicationDbContext _context;

    public ParkingSpaceRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public ParkingSpace Save(ParkingSpace parkingSpace)
    {
        var response = _context.ParkingSpace.Add(parkingSpace);
        _context.SaveChanges();
        return response.Entity;
    }

    public IOrderedQueryable<ParkingSpace> GetMotorcycleParkingSpaces()
    {
        var response = _context.ParkingSpace.Where(item => item.Vehicle == null).OrderBy(item => item.Size);
        return response;
    }

    public IOrderedQueryable<ParkingSpace> GetCarParkingSpaces()
    {
        var response = _context.ParkingSpace.Where(item => (item.Size == 2 || item.Size == 3) && item.Vehicle == null).OrderBy(item => item.Size);
        return response;
    }

    public IOrderedQueryable<ParkingSpace> GetVanParkingSpaces()
    {
        var response = _context.ParkingSpace.Where(item => (item.Size == 2 || item.Size == 3) && item.Vehicle == null).OrderByDescending(item => item.Size);
        return response;
    }

    public void Update(ParkingSpace parkingSpace)
    {
        _context.ParkingSpace.Update(parkingSpace);
        _context.SaveChanges();
    }

    public List<ParkingSpace>? GetByVehicleId(int vehiclyId)
    {   
        var response = _context.ParkingSpace.Where(item => item.Vehicle.Id == vehiclyId);
        return response.ToList();
    }

    public List<ParkingSpace> Get()
    {
        var response = _context.ParkingSpace.ToList();
        return response;
    }

    public bool GetNotNullVehicle()
    {
        var response = _context.ParkingSpace.Any(item => item.Vehicle.Id != null);
        return !response;
    }
}