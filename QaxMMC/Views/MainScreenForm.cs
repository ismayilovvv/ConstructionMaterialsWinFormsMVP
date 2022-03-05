using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QaxMMC.Views
{
    public partial class MainScreenForm : Form, IMainScreenView
    {
        public MainScreenForm()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> OpenSalesWindow;
        public event EventHandler<EventArgs> OpenConstructionMaterialsWindow;
        public event EventHandler<EventArgs> OpenCustomersWindow;
        public event EventHandler<EventArgs> OpenCreditsWindow;

        bool IView.ShowDialog()
        {
            return this.ShowDialog() == DialogResult.OK;
        }

        private void salesBtn_Click(object sender, EventArgs e)
        {
            OpenSalesWindow?.Invoke(this, new EventArgs());
        }

        private void constructionMaterialsBtn_Click(object sender, EventArgs e)
        {
            OpenConstructionMaterialsWindow?.Invoke(this, new EventArgs());
        }

        private void customersBtn_Click(object sender, EventArgs e)
        {
            OpenCustomersWindow?.Invoke(this, new EventArgs());
        }

        private void creditsBtn_Click(object sender, EventArgs e)
        {
            OpenCreditsWindow?.Invoke(this, new EventArgs());
        }
    }
}
