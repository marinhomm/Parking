public interface ITicketUseCase
{
    public Ticket CheckIn(CheckInEntryDTO data);
    public Ticket CheckOut(int id);
}