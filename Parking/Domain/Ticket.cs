using System.ComponentModel.DataAnnotations;

public class Ticket
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime EntryTime { get; set; }

    public DateTime? DepartureTime { get; set; }

    [Required]
    public double HourPrice { get; set; }

    [Required]
    public Vehicle Vehicle { get; set; }

    public double? FinalPrice { get; set; }

    public Ticket(DateTime entryTime, Vehicle vehicle, double hourPrice)
    {
        EntryTime = entryTime;
        Vehicle = vehicle;
        HourPrice = hourPrice;
    }

    public Ticket()
    {
        
    }
}