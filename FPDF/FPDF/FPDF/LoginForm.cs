using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FPDF.User_Util;
using FPDF.Database;

namespace FPDF
{
    public partial class LoginForm : Form
    {
        /*--Fields--*/
        public User user { get; set; }
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            /*Check if all fileds aren't empty*/
            if (this.tMail.Text.Count() > 0 && this.tPassword.Text.Count() > 0)
            {

                // Part to make some tests
                if (this.tMail.Text == "example@gmail.com" & this.tPassword.Text == "R0mb0")
                {
                    user = User.getUser(this.tMail.Text, "Francesco", "Rombaldoni", "1234");
                    
                    //Last operation
                    this.Close();
                }
                else 
                {
                    MessageBox.Show("Le credenziali non sono corrette", "Errore credenziali", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //Test if the credentials are correct
                //string queryString = "";

                
                /*using (SqlConnection connection = new SqlConnection(Database.Database.GetUserDatabaseConnectionString()))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            //make test here
                            if(test = true)
                            {

                                //Other query to retrieve user informations

                                user.getUser(this.tMail.Text);

                                //Last operation
                                this.Close();

                            }
                            else{
                                MessageBox.Show("Le credenziali non sono corrette", "Errore credenziali", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    finally
                    {
                        reader.Close();
                    }
                }*/
            }
            else 
            {
                MessageBox.Show("Completare tutti i campi", "Errore campi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //public User Ciao() { return user; }
    }
}
