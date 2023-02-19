using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezhednevnik
{
    public class Zametka
    {
        public string name;
        public string description;
        public string date;
        public Zametka(string z_name, string z_description, string z_date) 
        { 
            name = z_name;
            description= z_description;
            date = z_date;
        }
    }
}
