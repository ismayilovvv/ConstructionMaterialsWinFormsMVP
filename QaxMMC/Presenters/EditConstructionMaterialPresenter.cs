using QaxMMC.Models;
using QaxMMC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Presenters
{
    public class EditConstructionMaterialPresenter
    {
        private IEditConstructionMaterialView editConstructionMaterialView;
        public IView View { get { return editConstructionMaterialView; } }
        public ConstructionMaterial constructionMaterial { get; set; }
        public EditConstructionMaterialPresenter(IEditConstructionMaterialView editConstructionMaterialView)
        {
            constructionMaterial = new ConstructionMaterial();
            this.editConstructionMaterialView = editConstructionMaterialView;
            EventSubscription();
        }

        private void EventSubscription()
        {
            editConstructionMaterialView.updateCM += EditConstructionMaterialView_updateCM;
            editConstructionMaterialView.loadCM += EditConstructionMaterialView_loadCM;
        }

        private void EditConstructionMaterialView_loadCM(object sender, EventArgs e)
        {
            editConstructionMaterialView.LoadCm(constructionMaterial);
        }

        private void EditConstructionMaterialView_updateCM(object sender, CMEventArgs e)
        {
            constructionMaterial.date = e.constructionMaterial.date;
            constructionMaterial.Eded = e.constructionMaterial.Eded;
            constructionMaterial.En = e.constructionMaterial.En;
            constructionMaterial.Hundurluk = e.constructionMaterial.Hundurluk;
            constructionMaterial.Kub = e.constructionMaterial.Kub;
            constructionMaterial.Kvadrat = e.constructionMaterial.Kvadrat;
            constructionMaterial.Mebleg = e.constructionMaterial.Mebleg;
            constructionMaterial.Nomre = e.constructionMaterial.Nomre;
            constructionMaterial.Nov = e.constructionMaterial.Nov;
            constructionMaterial.Uzunluq = e.constructionMaterial.Uzunluq;
        }
    }
}
