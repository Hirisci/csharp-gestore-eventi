// See https://aka.ms/new-console-template for more information
using csharp_gestore_eventi;

ProgramEvent tour = CreateTour();
ShowTour(tour);





static Event InfoEvent()
{
    Console.WriteLine();
    Console.Write("Iserisci il nome del evento: ");
    string? title = Console.ReadLine();
    Console.Write("Iserisci la data del evento (gg/mm/yyyy): ");
    DateTime date = DateTime.Parse(Console.ReadLine());
    Console.Write("Iserisci il numero di posti totali: ");
    int maxSeats = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    return new Event(title, date, maxSeats);
}

static ProgramEvent CreateTour()
{
    Console.Write("Iserisci il nome del Tour: ");
    string? title = Console.ReadLine();
    Console.Write("indica il numero di eventi da inserire? ");
    int countEvent = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();
    List<Event> events = new List<Event>();
    for (int i = 0; i < countEvent; i++)
    {
        events.Add(InfoEvent());
    }

    return new ProgramEvent(events, title);
}

static void ShowTour(ProgramEvent tour)
{
    Console.WriteLine($"Il numero di eventi nel programma é {tour.Count}");
    Console.WriteLine("Ecco il programma del evento:");
    Console.WriteLine(tour.infoTour());
}
