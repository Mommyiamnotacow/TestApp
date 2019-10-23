using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWebAPI.Model
{
    public class Log
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public bool isRequest { get; set; }
    }
}
