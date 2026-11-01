namespace wt_lab6_6minimalapi_gerasimchuk.Models;

public class Flight
{
    public int Id { get; set; }
    public string FlightNumber { get; set; } = "";   // Номер рейса
    public string DepartureCity { get; set; } = "";  // Откуда
    public string ArrivalCity { get; set; } = "";    // Куда
    public DateTime DepartureTime { get; set; }      // Время вылета
    public decimal Price { get; set; }               // Цена
    public bool IsAvailable { get; set; }            // Есть ли места
}