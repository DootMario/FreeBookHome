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
    public partial class FreeBookHome : Form
    {
        public FreeBookHome()
        {
            InitializeComponent();
        }

        private void goToSignUp(object sender, EventArgs e)
        {
            CreazaContFreeBook SignUp = new CreazaContFreeBook();
            SignUp.Show();
            this.Hide();
        }

        private void goToLogin(object sender, EventArgs e)
        {
            LogareFreeBook Login = new LogareFreeBook();
            Login.Show();
            this.Hide();
        }

    }
}
