using QaxMMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Views
{
    public interface IAddSaleView: IView
    {
        event EventHandler<SEventArgs> addSaleEvent;
    }

    public class SEventArgs
    {
        public Sale sale { get; set; }
    }
}
