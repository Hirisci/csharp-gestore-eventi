using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Event
    {
        private string? _title;
        private DateTime _date;
        private int _maxSeats;
        private int _reservedSeats;
        
        public string? Title
        {
            get => _title;
            set
            {
                if (value == "" || value == null) { 
                throw new Exception("Impossibile impostare vuoto il campo titolo evento");
                }
                _title = value;
            }
        }  
        public DateTime Date { 
            get=> _date; 
            set {
                if (DateTime.Now > value) { 
                throw new Exception("Impossibile impostare la data");
                }

                _date = value;
            }
        }
        public int MaxSeats { 
            get => _maxSeats;  
            init {
                if (value <= 0) { 
                    throw new Exception("Impossibile inserire un numero negativo");
                } 
                
                _maxSeats = value;
            } 
        }
        public int ReservedSeats { 
            get=> _reservedSeats;
            private set {
                if (_date < DateTime.Now) { 
                    throw new Exception("Operazione impossibile, l'evento é gia passato");
                } 
                if ( value > _maxSeats){
                    throw new Exception($"Impossibile eseguire l'operazione, Sono disponibili solo {EmptySeats} posti ");
                }
                if ( value < 0) { 
                    throw new Exception($"Impossibile eseguire l'operazione, Posti riservati sono solo {_reservedSeats}");
                }

                _reservedSeats = value;

            } 
        }
        public int EmptySeats { get => MaxSeats - ReservedSeats; }
        
        
        //public int EmptySeats { get=>EmptySeats; private set=> EmptySeats=MaxSeats-ReservedSeats; }
        public Event(string? title, DateTime date, int seatsMax)
        {
            Title = title;
            Date = date;
            MaxSeats = seatsMax;
            ReservedSeats = 0;
        }

        //prenota posti
        public void BookSeats(int seats) 
        {
            ReservedSeats += seats;
        }

        //disdici posti
        public void CancelBookSeats(int seats)
        {
            ReservedSeats -= seats; 
        }

        //overdiver to string
        public override string? ToString()
        {
            return String.Format("  {0} - {1} | Posti Disponibili: {2,5} | Posti Prenotati {3,5}", Date.ToString("dd/MM/yyyy"), Title, EmptySeats, ReservedSeats);
        }

    }
}
