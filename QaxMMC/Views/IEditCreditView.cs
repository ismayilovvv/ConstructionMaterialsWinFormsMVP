using QaxMMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Views
{
    public interface IEditCreditView : IView
    {
        event EventHandler<CreEventArgs> updateCredit;
        event EventHandler<EventArgs> loadCredit;
        void LoadCredit(Credit credit);
    }
}
