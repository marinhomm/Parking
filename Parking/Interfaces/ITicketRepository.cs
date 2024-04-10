public interface ITicketRepository
{
    public Ticket Save(Ticket ticket);
    public Ticket? GetById(int id);
    public Ticket Update(Ticket ticket);
    public List<Ticket> GetOpenedTicket();
}