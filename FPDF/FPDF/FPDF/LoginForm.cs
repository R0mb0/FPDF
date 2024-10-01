using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FPDF.User_Util;

namespace FPDF
{
    public partial class LoginForm : Form
    {
        /*--Fields--*/
        User user { get; set; }
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            /*Check if all fileds aren't empty*/
            if (this.tMail.Text.Count() > 0 && this.tPassword.Text.Count() > 0)
            {


                /*Last operation*/
                this.Close();
            }
            else 
            {
                MessageBox.Show("Completare tutti i campi", "Errore campi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
