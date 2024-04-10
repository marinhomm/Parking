using Microsoft.EntityFrameworkCore;

public class TicketRepository : ITicketRepository
{
    private readonly ApplicationDbContext _context;

    public TicketRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Ticket Save(Ticket ticket)
    {
        var response = _context.Ticket.Add(ticket);
        _context.SaveChanges();
        return response.Entity;
    }

    public Ticket? GetById(int id)
    {
        var response = _context.Ticket.Where(item => item.Id == id).Include(item => item.Vehicle);
        return response.FirstOrDefault();
    }

    public Ticket Update(Ticket ticket)
    {
        var response = _context.Ticket.Update(ticket);
        _context.SaveChanges();
        return response.Entity;
    }

    public List<Ticket> GetOpenedTicket()
    {
        var response = _context.Ticket.Where(item => item.DepartureTime == null).Include(item => item.Vehicle).ToList();
        return response;
    }
}