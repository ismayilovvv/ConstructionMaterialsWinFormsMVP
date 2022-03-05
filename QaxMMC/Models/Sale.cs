using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime saleDate { get; set; }
        public float sum { get; set; }
        public string Ad { get; set; }
        public Nullable<float> En { get; set; }
        public Nullable<float> Uzunluq { get; set; }
        public Nullable<float> Hundurluk { get; set; }
        public Nullable<int> Miqdar { get; set; }
        public Nullable<float> Kub { get; set; }
        public Nullable<float> Kvadrat { get; set; }
        public Nullable<short> Nomre { get; set; }
        public string Nov { get; set; }
    }
}
