using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week6.Entities
{
    class RateData
    {
        public DateTime Date { get; internal set; }
        public string Currency { get; internal set; }
        public decimal Value { get; internal set; }
    }
}
