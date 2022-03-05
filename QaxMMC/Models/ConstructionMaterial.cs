using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Models
{
    public class ConstructionMaterial
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public Nullable<float> En { get; set; }
        public Nullable<float> Uzunluq { get; set; }
        public Nullable<float> Hundurluk { get; set; }
        public Nullable<int> Eded { get; set; }
        public Nullable<float> Kub { get; set; }
        public Nullable<float> Kvadrat { get; set; }
        public Nullable<short> Nomre { get; set; }
        public string Nov { get; set; }
        public DateTime date { get; set; }
        public float Mebleg { get; set; }
    }

   
}
