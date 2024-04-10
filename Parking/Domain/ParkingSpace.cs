using System.ComponentModel.DataAnnotations;

public class ParkingSpace
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int Size { get; set; }

    public Vehicle? Vehicle { get; set; }

    public ParkingSpace(int size)
    {
        Size = size;
    }
}