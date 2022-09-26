// See https://aka.ms/new-console-template for more information
using csharp_gestore_eventi;
using System.Security;
using System.Xml.Schema;

ProgramEvent tour = CreateTour();
CreateTourEvent(tour);
ShowTour(tour);





Event InfoEvent()
{
    bool status = true;
    string? title = String.Empty ;
    DateTime date = default;
    int maxSeats = 0;
   
    do
    {
        try
        {
            Console.WriteLine();
            Console.Write("Iserisci il nome del evento: ");
            title = Console.ReadLine();
            Console.Write("Iserisci la data del evento (gg/mm/yyyy): ");
            date = DateTime.Parse(Console.ReadLine());
            Console.Write("Iserisci il numero di posti totali: ");
            maxSeats = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            status = false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            status = true;
        }

    } while (status);

    return new Event(title, date, maxSeats);
}

Conference InfoConference()
{
    bool status = true;
    string? title = String.Empty;
    string? speaker = String.Empty;
    double price = 0.00;
    DateTime date = default;
    int maxSeats = 0;

    do
    {
        try
        {
            Console.WriteLine();
            Console.Write("Iserisci il nome del evento: ");
            title = Console.ReadLine();
            Console.Write("Iserisci la data del evento (gg/mm/yyyy): ");
            date = DateTime.Parse(Console.ReadLine());
            Console.Write("Iserisci il nome del relatore del evento: ");
            speaker = Console.ReadLine();
            Console.Write("Iserisci il numero di posti totali: ");
            maxSeats = Convert.ToInt32(Console.ReadLine());
            Console.Write("Iserisci il prezzo del biglietto: ");
            price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            status = false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            status = true;
        }

    } while (status);

    return new Conference(title, date, maxSeats,speaker,price);
}

ProgramEvent CreateTour()
{
    bool status = true;
    string title = string.Empty;
    List<Event> events = new List<Event>();
    do
    {
        try
        {
            Console.Write("Iserisci il nome del Tour: ");
            title = Console.ReadLine()!;

            if (title is null or "") { status = true; }
            else { status = false; }
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            status = true;
        }
    } while (status);
        return new ProgramEvent(events, title);
}

void CreateTourEvent(ProgramEvent tour)
{
    
        try
        {
            Console.Write("indica il numero di eventi da inserire? ");
            int countEvent = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();


            for (int i = 0; i < countEvent; i++)
            {
                string choise = "asd";
                do
                {
                    Console.Write("Vuoi inserire un evento o una conferenza: ");
                    choise = Console.ReadLine();
                } while (choise.ToLower() != "evento" && choise.ToLower() != "conferenza");
                if (choise.ToLower() == "evento") { tour.AddEvent(InfoEvent()); } 
                else { tour.AddEvent(InfoConference()); };
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            
        }
    
}

void ShowTour(ProgramEvent tour)
{
    Console.WriteLine($"Il numero di eventi nel programma é {tour.Count}");
    Console.WriteLine("Ecco il programma del evento:");
    try
    {

    Console.WriteLine(tour.infoTour());
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
