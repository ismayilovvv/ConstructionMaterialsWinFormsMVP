using QaxMMC.EntityFramework;
using QaxMMC.Models;
using QaxMMC.Services;
using QaxMMC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Presenters
{
    public class CreditsPresenter
    {
        private ICreditsView creditView;
        private IConstructionMaterialService constructionMaterialService;
        public List<Credit> credits { get; set; }
        public IView View { get { return creditView; } }
        public CreditsPresenter(ICreditsView creditView, IConstructionMaterialService constructionMaterialService)
        {
            credits = new List<Credit>();
            this.creditView = creditView;
            this.constructionMaterialService = constructionMaterialService;
            constructionMaterialService.AddDbContext(new QaxMmcDbContext());
            EventsSubscription();
        }

        private void EventsSubscription()
        {
            creditView.OpenAddCreditWindow += CreditView_OpenAddCreditWindow;
            creditView.LoadCreditEvent += CreditView_LoadCreditEvent;
            creditView.DeleteCredit += CreditView_DeleteCredit;
            creditView.EditCredit += CreditView_EditCredit;
        }

        private void CreditView_EditCredit(object sender, idEventArgs e)
        {
            EditCreditPresenter editCreditPresenter = IOC.Resolve<EditCreditPresenter>();
            editCreditPresenter.credit = credits.Where(c => c.Id == e.Id).FirstOrDefault();
            if (!editCreditPresenter.View.ShowDialog())
            {
                constructionMaterialService.EditCredit(editCreditPresenter.credit);
                constructionMaterialService.GetCredits();
                creditView.ReloadCredits(credits);
            }
        }

        private void CreditView_DeleteCredit(object sender, idEventArgs e)
        {
            constructionMaterialService.DeleteCredit(e.Id);
            constructionMaterialService.GetCredits();
            creditView.ReloadCredits(credits);
        }

        private void CreditView_LoadCreditEvent(object sender, EventArgs e)
        {
            credits = constructionMaterialService.GetCredits();
            creditView.ReloadCredits(credits);
        }

        private void CreditView_OpenAddCreditWindow(object sender, EventArgs e)
        {
            AddCreditPresenter addCreditPresenter = IOC.Resolve<AddCreditPresenter>();
            if(!addCreditPresenter.View.ShowDialog())
            {
                if(addCreditPresenter.credit != null)
                {
                    constructionMaterialService.AddCredit(addCreditPresenter.credit);
                    credits = constructionMaterialService.GetCredits();
                    creditView.ReloadCredits(credits);
                }
            }
        }
    }
}
