using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.DTO
{
    public class LogRecordDTO
    {
        public int ID { get; set; }

        public DateTime Time { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool isRequest { get; set; }
    }
}
