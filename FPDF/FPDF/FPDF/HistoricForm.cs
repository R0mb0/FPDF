using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPDF
{
    public partial class HistoricForm : Form
    {

        //Fields
        public string filePath { get; set; }

        public HistoricForm()
        {
            InitializeComponent();

            //Read the database for all files
            /*
            //string queryString = "";

                /*using (SqlConnection connection = new SqlConnection(Daabase.Database.GetUserDatabaseConnectionString()))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            
                        }
                    }
                    finally
                    {
                        reader.Close();
                    }
                }*/
        }

        private void bSelect_Click(object sender, EventArgs e)
        {
            // Here load files and close panel
            this.filePath = "Sent_Documents\\" + this.dView.SelectedCells[0].Value.ToString();
            try 
            {
                File.Copy(this.filePath, this.dView.SelectedCells[0].Value.ToString());
            }
            catch //(Exception ex) 
            {
                
                try 
                {
                    File.Delete(this.dView.SelectedCells[0].Value.ToString());
                    File.Copy(this.filePath, this.dView.SelectedCells[0].Value.ToString());
                }
                catch //(Exception ex2)
                {
                    MessageBox.Show("Errore durante la gestione dei file", "Errore gestione file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            this.filePath = this.dView.SelectedCells[0].Value.ToString();
            this.Close();

        }

        public void UpdateGrid() 
        {
            // Load Files inside Teh data grid
            if (Directory.Exists("Sent_Documents") && Directory.GetFiles("Sent_Documents").Length != 0)
            {
                try
                {
                    foreach (var item in Directory.GetFiles("Sent_Documents"))
                    {
                        this.dView.Rows.Add(item.Replace("Sent_Documents", "").Remove(0, 1));
                    }
                }
                catch //(Exception ex)
                {
                    MessageBox.Show("I file non sono raggiungibili", "Errore lettura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
