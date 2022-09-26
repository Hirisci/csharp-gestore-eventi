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
        private string? _title;
        private DateTime _date;
        private int _seatsMax;
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
        public int SeatsMax { 
            get => _seatsMax;  
            init {
                if (value <= 0) { 
                    throw new Exception("Impossibile inserire un numero negativo");
                } 
                
                _seatsMax = value;
            } 
        }
        public int ReservedSeats { 
            get=> _reservedSeats;
            private set {
                if (_date < DateTime.Now) { 
                    throw new Exception("Operazione impossibile, l'evento é gia passato");
                } 
                if (_reservedSeats + value > _seatsMax){
                    throw new Exception($"Impossibile eseguire l'operazione, Sono disponibili solo {_seatsMax - _reservedSeats} posti ");
                }
                if (_reservedSeats - value <= 0) { 
                    throw new Exception($"Impossibile eseguire l'operazione, Posti riservati sono solo {_reservedSeats}");
                }

                _reservedSeats = value;

            } 
        }
        
        
        //public int EmptySeats { get=>EmptySeats; private set=> EmptySeats=SeatsMax-ReservedSeats; }
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
            return $"{Date.ToString("dd/MM/yyyy")} - {Title}";
        }




    }
}
