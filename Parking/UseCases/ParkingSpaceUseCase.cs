using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ParkingSpaceUseCase : IParkingSpaceUseCase
{
    private readonly IParkingSpaceRepository _parkingSpaceRepository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IObjectValidator _objectValidator;

    public ParkingSpaceUseCase(
        IParkingSpaceRepository parkingSpaceRepository, 
        IVehicleRepository vehicleRepository,
        IObjectValidator objectValidator
    )
    {
        _parkingSpaceRepository = parkingSpaceRepository;
        _vehicleRepository = vehicleRepository;
        _objectValidator = objectValidator;
    }

    public ParkingSpace Register(ParkingSpaceEntryDTO data)
    {
        _objectValidator.Validate(data);

        ParkingSpace parkingSpace = new ParkingSpace(data.Size);
        ParkingSpace response = _parkingSpaceRepository.Save(parkingSpace);
        return response;
    }

    public List<ParkingSpace> GetAvailableParkingSpaces(string vehicleType)
    {
        List<ParkingSpace> response = new List<ParkingSpace>();
        IEnumerable<ParkingSpace> parkingSpaceList = new List<ParkingSpace>();

        switch (vehicleType)
        {
            case "M":
                parkingSpaceList = _parkingSpaceRepository.GetMotorcycleParkingSpaces();
                
                if(parkingSpaceList.Count() == 0)
                {
                    throw new Exception("There is no parking space available for a motorcycle!");
                }

                response.Add(parkingSpaceList.First());
                break;
            case "C":
                parkingSpaceList = _parkingSpaceRepository.GetCarParkingSpaces();

                if(parkingSpaceList.Count() == 0)
                {
                    throw new Exception("There is no parking space available for a car!");
                }

                response.Add(parkingSpaceList.First());
                break;
            case "V":
                parkingSpaceList = _parkingSpaceRepository.GetVanParkingSpaces();

                int mediumParkingSpaces = parkingSpaceList.Where(item => item.Size == 2).Count();
                int largeParkingSpaces = parkingSpaceList.Where(item => item.Size == 3).Count();

                if(largeParkingSpaces > 0)
                {
                    response.Add(parkingSpaceList.First());
                    break;
                }
                else if(mediumParkingSpaces > 2)
                {
                    response = parkingSpaceList.Where(item => item.Size == 2).Take(3).ToList();
                    break;
                }
                else
                {   
                    throw new Exception("There is no parking space available for a van!");
                }
        
        }

        return response;
    }

    public void AddVehicle(List<ParkingSpace> parkingSpaces, Vehicle vehicle)
    {
        foreach (ParkingSpace parkingSpace in parkingSpaces)
        {
            parkingSpace.Vehicle = vehicle;
            _parkingSpaceRepository.Update(parkingSpace);
        }
    }

    public void RemoveVehicle(int id)
    {
        List<ParkingSpace>? parkingSpaces = _parkingSpaceRepository.GetByVehicleId(id);
        
        if(parkingSpaces != null)
        {
            foreach (ParkingSpace parkingSpace in parkingSpaces)
            {
                parkingSpace.Vehicle = null;
                _parkingSpaceRepository.Update(parkingSpace);
            }
        }
        
    }

    public int SumAvailableParkingSpaces()
    {
        IEnumerable<ParkingSpace> availableParkingSpaces = _parkingSpaceRepository.GetMotorcycleParkingSpaces();
        return availableParkingSpaces.Count();
    }

    public int SumParkingSpaces()
    {
        List<ParkingSpace> parkingSpaces = _parkingSpaceRepository.Get();
        return parkingSpaces.Count();
    }

    public int SumVanParkingSpaces()
    {
        List<Vehicle> vans = _vehicleRepository.GetByType("V");
        
        if(vans == null)
        {
            throw new Exception("There are no vans registered!");
        }

        int parkingSpacesOccupiedByVan = 0;
        foreach (Vehicle van in vans)
        {
            int usedParkingSpaces = _parkingSpaceRepository.GetByVehicleId(van.Id).Count();
            parkingSpacesOccupiedByVan += usedParkingSpaces;
        }

        return parkingSpacesOccupiedByVan;
    }

    public bool CheckParkingIsAbsolutelyFull()
    {
        IEnumerable<ParkingSpace> parkingSpaces = _parkingSpaceRepository.GetMotorcycleParkingSpaces();

        if(parkingSpaces.Count() > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
        
    }

    public bool CheckParkingIsEmpty()
    {
        bool isEmpty = _parkingSpaceRepository.GetNotNullVehicle();
        return isEmpty;
    }
}