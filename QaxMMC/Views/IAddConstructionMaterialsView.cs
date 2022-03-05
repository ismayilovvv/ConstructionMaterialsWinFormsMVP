using QaxMMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Views
{
    public interface IAddConstructionMaterialsView : IView
    {
        event EventHandler<EventArgs> cmEnable;
        event EventHandler<CMEventArgs> addCM;
        void cmComboBoxSelectedIndexChanged();
    }

    public class CMEventArgs
    {
        public ConstructionMaterial constructionMaterial { get; set; }
    }

    public class idEventArgs
    {
        public int Id { get; set; }
    }

}
