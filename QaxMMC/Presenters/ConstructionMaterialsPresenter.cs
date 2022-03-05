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
    public class ConstructionMaterialsPresenter
    {
        private IConstructionMaterialsView constructionMaterialsView;
        private IConstructionMaterialService constructionMaterialService;
        public IView View { get { return constructionMaterialsView; } }
        public List<ConstructionMaterial> constructionMaterials { get; set; }
        public ConstructionMaterialsPresenter(IConstructionMaterialsView constructionMaterialsView, IConstructionMaterialService constructionMaterialService)
        {
            constructionMaterials = new List<ConstructionMaterial>();
            this.constructionMaterialService = constructionMaterialService;
            this.constructionMaterialsView = constructionMaterialsView;
            constructionMaterialService.AddDbContext(new QaxMmcDbContext());
            EventSubscribtion();
        }

        private void EventSubscribtion()
        {
            constructionMaterialsView.OpenAddConstructionMaterialsWindow += ConstructionMaterialsView_OpenAddConstructionMaterialsWindow;
            constructionMaterialsView.DeleteConstructionMaterial += ConstructionMaterialsView_DeleteConstructionMaterial;
            constructionMaterialsView.EditConstructionMaterial += ConstructionMaterialsView_EditConstructionMaterial;
            constructionMaterialsView.LoadCMEvent += ConstructionMaterialsView_LoadCMEvent;
        }

        private void ConstructionMaterialsView_LoadCMEvent(object sender, EventArgs e)
        {
            constructionMaterials = constructionMaterialService.GetConstructionMaterials();
            constructionMaterialsView.ReloadConstructionMaterials(constructionMaterials);
        }

        

        private void ConstructionMaterialsView_EditConstructionMaterial(object sender, idEventArgs e)
        {
            EditConstructionMaterialPresenter editConstructionMaterialPresenter = IOC.Resolve<EditConstructionMaterialPresenter>();
            editConstructionMaterialPresenter.constructionMaterial = constructionMaterials.Where(cm => cm.Id == e.Id).FirstOrDefault();
            if (!editConstructionMaterialPresenter.View.ShowDialog())
            {
                constructionMaterialService.EditConstructionMaterial(editConstructionMaterialPresenter.constructionMaterial);
                constructionMaterials=constructionMaterialService.GetConstructionMaterials();
                constructionMaterialsView.ReloadConstructionMaterials(constructionMaterials);
            }
        }

        private void ConstructionMaterialsView_DeleteConstructionMaterial(object sender, idEventArgs e)
        {
            constructionMaterialService.DeleteConstructionMaterial(e.Id);
            constructionMaterials = constructionMaterialService.GetConstructionMaterials();
            constructionMaterialsView.ReloadConstructionMaterials(constructionMaterials);
        }

        private void ConstructionMaterialsView_OpenAddConstructionMaterialsWindow(object sender, EventArgs e)
        {
            AddConstructionMaterialsPresenter addConstructionMaterialsPresenter = IOC.Resolve<AddConstructionMaterialsPresenter>();
            if (!addConstructionMaterialsPresenter.View.ShowDialog())
            {
                if (addConstructionMaterialsPresenter.constructionMaterial != null)
                {
                    constructionMaterialService.AddConstructionMaterial(addConstructionMaterialsPresenter.constructionMaterial);
                    constructionMaterials = constructionMaterialService.GetConstructionMaterials();
                    constructionMaterialsView.ReloadConstructionMaterials(constructionMaterials);
                }
            }
        }
    }
}
