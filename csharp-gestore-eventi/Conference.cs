using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Conference : Event
    {
        public string Speaker { get; set; }
        public double Price { get; set; }
        public Conference(string? title, DateTime date, int seatsMax, string speaker, double price) : base(title, date, seatsMax)
        {
            Speaker = speaker;
            Price = price;
        }

        public override string? ToString()
        {
            string str = String.Format("| Relatore {0,10} | Prezzo {1:0.00} euro |", Speaker, Price);
            return base.ToString() + str;
        }
    }
}
