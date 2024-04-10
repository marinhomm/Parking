using System.ComponentModel.DataAnnotations;

public record ParkingSpaceEntryDTO
{
    [Range(1, 3, ErrorMessage = "Field 'size' must be between 1 and 3!")]
    public int Size { get; set; }
}