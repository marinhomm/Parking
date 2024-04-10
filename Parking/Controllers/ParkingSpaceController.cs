using Microsoft.AspNetCore.Mvc;

public class ParkingSpaceController : Controller
{
    private readonly IParkingSpaceUseCase _parkingSpaceUseCase;

    public ParkingSpaceController(IParkingSpaceUseCase parkingSpaceUseCase)
    {
        _parkingSpaceUseCase = parkingSpaceUseCase;
    }

    [HttpPost]
    [Route("v1/ParkingSpace/Register")]
    public IActionResult Register([FromBody] ParkingSpaceEntryDTO data)
    {
        try
        {
            ParkingSpace response = _parkingSpaceUseCase.Register(data);
            return CreatedAtAction("Registration", response);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpGet]
    [Route("v1/ParkingSpace/SumAvailableParkingSpaces")]
    public IActionResult SumAvailableParkingSpaces()
    {
        try
        {
            int response = _parkingSpaceUseCase.SumAvailableParkingSpaces();
            return Ok(response);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpGet]
    [Route("v1/ParkingSpace/SumParkingSpaces")]
    public IActionResult SumParkingSpaces()
    {
        try
        {
            int response = _parkingSpaceUseCase.SumParkingSpaces();
            return Ok(response);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpGet]
    [Route("v1/ParkingSpace/SumVanParkingSpaces")]
    public IActionResult SumVanParkingSpaces()
    {
        try
        {
            int response = _parkingSpaceUseCase.SumVanParkingSpaces();
            return Ok(response);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpGet]
    [Route("v1/ParkingSpace/CheckParkingIsAbsolutelyFull")]
    public IActionResult CheckParkingIsAbsolutelyFull()
    {
        try
        {
            bool response = _parkingSpaceUseCase.CheckParkingIsAbsolutelyFull();
            return Ok(response);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpGet]
    [Route("v1/ParkingSpace/CheckParkingIsEmpty")]
    public IActionResult CheckParkingIsEmpty()
    {
        try
        {
            bool response = _parkingSpaceUseCase.CheckParkingIsEmpty();
            return Ok(response);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}