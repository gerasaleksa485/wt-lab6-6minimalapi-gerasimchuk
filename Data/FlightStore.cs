using wt_lab6_6minimalapi_gerasimchuk.Models;

namespace wt_lab6_6minimalapi_gerasimchuk.Data;

public static class FlightStore
{
    public static List<Flight> Flights { get; } = new()
    {
        new Flight { Id = 1, FlightNumber = "SU-100", DepartureCity = "Минск",   ArrivalCity = "Москва",     DepartureTime = new DateTime(2026, 12, 01, 08, 30, 0), Price = 150m, IsAvailable = true  },
        new Flight { Id = 2, FlightNumber = "SU-205", DepartureCity = "Минск",   ArrivalCity = "Стамбул",    DepartureTime = new DateTime(2026, 12, 02, 12, 15, 0), Price = 320m, IsAvailable = true  },
        new Flight { Id = 3, FlightNumber = "B2-777", DepartureCity = "Минск",   ArrivalCity = "Дубай",      DepartureTime = new DateTime(2026, 12, 03, 23, 55, 0), Price = 540m, IsAvailable = false },
        new Flight { Id = 4, FlightNumber = "LH-312", DepartureCity = "Москва",  ArrivalCity = "Франкфурт",  DepartureTime = new DateTime(2026, 12, 04, 06, 40, 0), Price = 610m, IsAvailable = true  },
        new Flight { Id = 5, FlightNumber = "AF-102", DepartureCity = "Париж",   ArrivalCity = "Нью-Йорк",   DepartureTime = new DateTime(2026, 12, 05, 10, 20, 0), Price = 890m, IsAvailable = true  },
        new Flight { Id = 6, FlightNumber = "TK-55",  DepartureCity = "Стамбул", ArrivalCity = "Минск",      DepartureTime = new DateTime(2026, 12, 06, 15, 00, 0), Price = 340m, IsAvailable = false }
    };
}