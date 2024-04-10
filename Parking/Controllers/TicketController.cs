using Microsoft.AspNetCore.Mvc;

public class TicketController : Controller
{
    private readonly ITicketUseCase _ticketUseCase;

    public TicketController(ITicketUseCase ticketUseCase)
    {
        _ticketUseCase = ticketUseCase;
    }

    [HttpPost]
    [Route("v1/Ticket/CheckIn")]
    public IActionResult CheckIn([FromBody] CheckInEntryDTO data)
    {
        try
        { 
            Ticket response = _ticketUseCase.CheckIn(data);
            return CreatedAtAction("CheckIn", response);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpPut]
    [Route("v1/Ticket/CheckOut/{id}")]
    public IActionResult CheckOut(int id)
    {
        try
        {
            Ticket response = _ticketUseCase.CheckOut(id);
            return Ok(response);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

}