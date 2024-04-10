using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IParkingSpaceRepository, ParkingSpaceRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<ITicketUseCase, TicketUseCase>();
builder.Services.AddScoped<IParkingSpaceUseCase, ParkingSpaceUseCase>();
builder.Services.AddScoped<IVehicleUseCase, VehicleUseCase>();
builder.Services.AddScoped<IObjectValidator, ObjectValidator>();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "v1/{controller}/{action}"
);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
