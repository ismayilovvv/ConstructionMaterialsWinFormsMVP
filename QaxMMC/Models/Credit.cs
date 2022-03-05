using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Models
{
    public class Credit
    {
        public int Id { get; set; }
        public virtual Customer customer { get; set; }
        public virtual Sale sale { get; set; }
    }
}
