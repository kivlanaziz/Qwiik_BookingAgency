using Qwiik_BookingAgency.Context;
using Qwiik_BookingAgency.DataServices;
using Qwiik_BookingAgency.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IBookingDataService, BookingDataService>();
builder.Services.AddScoped<ICustomerDataService, CustomerDataService>();

builder.Services.AddDbContext<BookingDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
