using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectData.Models
{
    public struct Residence
    {
        public DateTime Date { get; }
        public string Village { get; }

        public Residence(DateTime d, string village)
        {
            Date = d;
            Village = village;
        }

        public override string ToString()
        {
            return $"{Date.ToString("yyyy-M-dd")}        {Village}";
        }
    }
}
