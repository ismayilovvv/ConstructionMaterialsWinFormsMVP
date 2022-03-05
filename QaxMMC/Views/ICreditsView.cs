using QaxMMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Views
{
    public interface ICreditsView:IView
    {
        event EventHandler<EventArgs> OpenAddCreditWindow;
        void ReloadCredits(List<Credit> credits);
        event EventHandler<EventArgs> LoadCreditEvent;
        event EventHandler<idEventArgs> DeleteCredit;
        event EventHandler<idEventArgs> EditCredit;
    }
}
