// See https://aka.ms/new-console-template for more information
using csharp_gestore_eventi;

Console.Write("Iserisci il nome del evento: ");
string? title = Console.ReadLine();
Console.Write("Iserisci la data del evento (gg/mm/yyyy): ");
DateTime date = DateTime.Parse(Console.ReadLine());
Console.Write("Iserisci il numero di posti totali: ");
int maxSeats = Convert.ToInt32(Console.ReadLine());
Console.Write("Quanti posti desideri prenotare? ");
int reservetSeats = Convert.ToInt32(Console.ReadLine());

Event event1 = new Event(title, date, maxSeats);
event1.BookSeats(reservetSeats);




bool status = true;
do
{
    Console.WriteLine($"Numero posti prenotati: {event1.ReservedSeats}");
    Console.WriteLine($"Numero posti disponibili: {event1.EmptySeats}");
    Console.WriteLine();
    Console.Write("Vuoi disidire dei posti (si/no)?");
    string risp = Console.ReadLine();
    switch (risp)
    {
        case "SI":
        case "S":
        case "Si":
        case "si":
        case "sI":
        case "s":
            Console.Write("Indica il numero di posti da disdire: ");
            int seats = Convert.ToInt32(Console.ReadLine());
            event1.CancelBookSeats(seats);
            break;
        case "NO":
        case "N":
        case "No":
        case "no":
        case "nO":
        case "n":
            Console.WriteLine("OK, va bene!");
            status = !status;
            break;
        default:
            Console.WriteLine("risposta non consentita");
            break;
    }


} while (status);
