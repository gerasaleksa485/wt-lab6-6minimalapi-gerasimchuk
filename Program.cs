using wt_lab6_6minimalapi_gerasimchuk.Data;
using wt_lab6_6minimalapi_gerasimchuk.Models;

var builder = WebApplication.CreateBuilder(args);

// Настройка Swagger (OpenAPI) для .NET 8
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Включаем Swagger в режиме разработки
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// --- БАЗОВЫЕ ЭНДПОИНТЫ ---
app.MapGet("/", () => "Minimal API работает!");

app.MapGet("/api/info", () => new
{
    Application = "Web Technologies",
    Technology = "ASP.NET Core Minimal API",
    Version = "1.0",
    Domain = "Авиакомпания"
});

// --- GET ЗАПРОСЫ ---
app.MapGet("/api/products", (string? search) =>
{
    var items = FlightStore.Flights.AsEnumerable();

    if (!string.IsNullOrWhiteSpace(search))
    {
        items = items.Where(x =>
            x.FlightNumber.Contains(search, StringComparison.OrdinalIgnoreCase) ||
            x.DepartureCity.Contains(search, StringComparison.OrdinalIgnoreCase) ||
            x.ArrivalCity.Contains(search, StringComparison.OrdinalIgnoreCase));
    }

    return Results.Ok(items);
});

app.MapGet("/api/products/{id}", (int id) =>
{
    var flight = FlightStore.Flights.FirstOrDefault(x => x.Id == id);
    return flight == null ? Results.NotFound() : Results.Ok(flight);
});

// --- POST ЗАПРОС ---
app.MapPost("/api/products", (Flight flight) =>
{
    var newId = FlightStore.Flights.Count == 0
        ? 1
        : FlightStore.Flights.Max(x => x.Id) + 1;

    flight.Id = newId;
    FlightStore.Flights.Add(flight);

    return Results.Created($"/api/products/{flight.Id}", flight);
});

// --- PUT ЗАПРОС ---
app.MapPut("/api/products/{id}", (int id, Flight updated) =>
{
    var flight = FlightStore.Flights.FirstOrDefault(x => x.Id == id);
    if (flight == null) return Results.NotFound();

    flight.FlightNumber  = updated.FlightNumber;
    flight.DepartureCity = updated.DepartureCity;
    flight.ArrivalCity   = updated.ArrivalCity;
    flight.DepartureTime = updated.DepartureTime;
    flight.Price         = updated.Price;
    flight.IsAvailable   = updated.IsAvailable;

    return Results.Ok(flight);
});

// --- DELETE ЗАПРОС ---
app.MapDelete("/api/products/{id}", (int id) =>
{
    var flight = FlightStore.Flights.FirstOrDefault(x => x.Id == id);
    if (flight == null) return Results.NotFound();

    FlightStore.Flights.Remove(flight);
    return Results.NoContent();
});

// --- НАСТРОЙКА ПОРТА И ЗАПУСК ---
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Run($"http://0.0.0.0:{port}");