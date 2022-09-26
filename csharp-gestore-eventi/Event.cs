using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class Event
    {
        
        public string Title
        {
            get => Title;
            set
            {
                if (value == "") throw new Exception("Impossibile impostare vuoto il campo titolo evento");
                else Title = value;
            }
        }  
        public DateTime Date { 
            get=> Date; 
            set {
                if (DateTime.Now > value) throw new Exception("Impossibile impostare la data");
                else Date = value;
            }
        } 
        
        public int SeatsMax { 
            get => SeatsMax;  
            init {
                if (value <= 0) throw new Exception("Impossibile inserire un numero negativo");
                else SeatsMax = value;
            } 
        }
        public int ReservedSeats { get; private set; }

        public Event(string title, DateTime date, int seatsMax)
        {
            Title = title;
            Date = date;
            SeatsMax = seatsMax;
            ReservedSeats = 0;
        }

        //prenota posti
        public void BookSeats(int seats) 
        {
             
            if (Date< DateTime.Now) throw new Exception("Impossibile riservare i posti, l'evento é gia passato");

            if (ReservedSeats + seats > ReservedSeats) throw new Exception($"Impossibile eseguire l'operazione, Sono disponibili solo {SeatsMax - ReservedSeats} posti ");

            ReservedSeats += seats;

        }

        //disdici posti
        public void CancelBookSeats(int seats)
        {
            if (Date < DateTime.Now) throw new Exception("Impossibile cancellare i posti riservati, l'evento é gia passato");

            if (ReservedSeats - seats <= 0) throw new Exception("Operazione non riuscita, I posti da disdire non sono sufficenti");

            ReservedSeats -= seats; 
        }


        //overdiver to string
        public override string? ToString()
        {
            return $"{Date.ToString("dd/MM/yyyy")} - {Title}";
        }




    }
}
