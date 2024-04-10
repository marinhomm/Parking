using System.ComponentModel.DataAnnotations;

public class Vehicle
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Plate { get; set; }

    [Required]
    [MaxLength(1)]
    public string Type { get; set; }

    [Required]
    public string Brand { get; set; }

    [Required]
    public string Model { get; set; }

    [Required]
    public string Color { get; set; }

    public Vehicle(string plate, string type, string brand, string model, string color)
    {
        Plate = plate;
        Type = type;
        Brand = brand;
        Model = model;
        Color = color;
    }
}