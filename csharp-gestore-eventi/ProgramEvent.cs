using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class ProgramEvent
    {
        private List<Event> _events;
        private string _title;
        public string Title
        {
            get => _title;
            set {
                if (value is "" or null)
                {
                    throw new Exception("Impossibile impostare vuoto il campo");
                }
                _title = value;
            }
        }
        public int Count { get { return _events.Count; } }
        public ReadOnlyCollection<Event> Events { get; }

        public ProgramEvent(List<Event> events, string title)
        {
            _events = events;
            Title = title;
            Events = _events.AsReadOnly();
        }

        public void AddEvent(Event newEvent){
            _events.Add(newEvent);
        }
        public void AddEvent(Conference newEvent)
        {
            _events.Add(newEvent);
        }
        public void ClearList() { 
            _events.Clear();
        } 

        public List<Event> EventsAvailable(DateTime date)
        {
            return _events.FindAll(vnt => vnt.Date > date);
        }

        public string infoTour()
        {
            return $"{Title}\n" + infoFilterTour(_events) ;
        }

        static string infoFilterTour(List<Event> ListEvent)
        {
            string str = "";
            foreach(Event e in ListEvent)
            {
                str += e.ToString()+"\n";
            }
            if(str.Length > 0){
                return str;
            }

            throw new Exception("Nessun evento presente nel Tour");
        }


        
    }
}
