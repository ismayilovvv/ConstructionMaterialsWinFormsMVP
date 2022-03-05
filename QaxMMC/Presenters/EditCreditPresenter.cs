using QaxMMC.Models;
using QaxMMC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Presenters
{
    public class EditCreditPresenter
    {
        private IEditCreditView editCreditView;
        public IView View { get { return editCreditView; } }
        public Credit credit { get; set; }
        public EditCreditPresenter(IEditCreditView editCreditView)
        {
            credit = new Credit();
            this.editCreditView = editCreditView;
            EventSubscription();
        }

        private void EventSubscription()
        {
            editCreditView.updateCredit += EditCreditView_updateCredit;
            editCreditView.loadCredit += EditCreditView_loadCredit;
        }

        private void EditCreditView_loadCredit(object sender, EventArgs e)
        {
            editCreditView.LoadCredit(credit);
        }

        private void EditCreditView_updateCredit(object sender, CreEventArgs e)
        {
            credit.sale.saleDate = e.credit.sale.saleDate;
            credit.sale.sum = e.credit.sale.sum;
            credit.sale.Ad = e.credit.sale.Ad;
            credit.sale.En = e.credit.sale.En;
            credit.sale.Hundurluk = e.credit.sale.Hundurluk;
            credit.sale.Uzunluq = e.credit.sale.Uzunluq;
            credit.sale.Miqdar = e.credit.sale.Miqdar;
            credit.sale.Kub = e.credit.sale.Kub;
            credit.sale.Kvadrat = e.credit.sale.Kvadrat;
            credit.sale.Nomre = e.credit.sale.Nomre;
            credit.sale.Nov = e.credit.sale.Nov;
        }
    }
}
