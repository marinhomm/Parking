using System.ComponentModel.DataAnnotations;

public record CheckInEntryDTO
{
    [Required(ErrorMessage = "Field 'plate' can not be empty or null!")]
    public string? Plate { get; set; }

    [Required(ErrorMessage = "Field 'type' can not be empty or null!")]
    [RegularExpression(@"^(M|C|V)$", ErrorMessage = "Field 'type' must be 'M', 'C' or 'V'!")]
    public string? Type { get; set; }

    [Required(ErrorMessage = "Field 'brand' can not be empty or null!")]
    public string? Brand { get; set; }

    [Required(ErrorMessage = "Field 'model' can not be empty or null!")]
    public string? Model { get; set; }

    [Required(ErrorMessage = "Field 'color' can not be empty or null!")]
    public string? Color { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Value of field 'hourPrice' can not be negative!")]
    public double HourPrice { get; set; }
}