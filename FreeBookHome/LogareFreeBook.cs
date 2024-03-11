using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeBookHome
{
    public partial class LogareFreeBook : Form
    {
        public LogareFreeBook()
        {
            InitializeComponent();
        }
        private void GoToMain(object sender, EventArgs e)
        {

            MeniuFreeBook Menu = new MeniuFreeBook();
            Menu.Show();
            this.Close();

        }
    }
}
