using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Ticket> Ticket { get; set; }
    public DbSet<ParkingSpace> ParkingSpace { get; set; }
    public DbSet<Vehicle> Vehicle { get; set; }
}