public class TicketUseCase : ITicketUseCase
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IParkingSpaceUseCase _parkingSpaceUseCase;
    private readonly IVehicleUseCase _vehicleUseCase;
    private readonly IObjectValidator _objectValidator;
    
    public TicketUseCase(
        ITicketRepository ticketRepository,
        IParkingSpaceUseCase parkingSpaceUseCase,
        IVehicleUseCase vehicleUseCase,
        IObjectValidator objectValidator
    )
    {
        _ticketRepository = ticketRepository;
        _parkingSpaceUseCase = parkingSpaceUseCase;
        _vehicleUseCase = vehicleUseCase;
        _objectValidator = objectValidator;
    }

    public Ticket CheckIn(CheckInEntryDTO data)
    {
        _objectValidator.Validate(data);
        
        List<Ticket> openedCheckIns = _ticketRepository.GetOpenedTicket();
        if(openedCheckIns != null)
        {
            foreach (Ticket item in openedCheckIns)
            {
                if(item.Vehicle.Plate == data.Plate)
                {
                    throw new Exception("This vehicle already has a opened ticket!");
                }
            }
        }

        List<ParkingSpace> parkingSpaces = _parkingSpaceUseCase.GetAvailableParkingSpaces(data.Type);
        
        Vehicle? vehicle = _vehicleUseCase.GetByCharacteristics(data.Plate);
        if(vehicle == null)
        {
            vehicle = new Vehicle(
                data.Plate,
                data.Type,
                data.Brand,
                data.Model,
                data.Color
            );
        }
        
        Ticket ticket = new Ticket(
            DateTime.Now,
            vehicle,
            Math.Round(data.HourPrice, 2)
        );

        Ticket response = _ticketRepository.Save(ticket);
        _parkingSpaceUseCase.AddVehicle(parkingSpaces, vehicle);
        return response;
    }

    public Ticket CheckOut(int id)
    {
        Ticket? ticket = _ticketRepository.GetById(id);

        if(ticket == null)
        {
            throw new Exception("Ticket does not exist!");
        }

        if(ticket.DepartureTime != null)
        {
            throw new Exception("Check out has already taken place!");
        }

        ticket.DepartureTime = DateTime.Now;
        TimeSpan duration = (TimeSpan)(ticket.DepartureTime - ticket.EntryTime);
        ticket.FinalPrice = Math.Round(duration.TotalHours * ticket.HourPrice, 2);

        Ticket response = _ticketRepository.Update(ticket);
        _parkingSpaceUseCase.RemoveVehicle(response.Vehicle.Id);
        return response;
    }
}