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
    public partial class LoadForm : Form
    {

        //Fields
        public string filePath { get; set; }
        public bool loaded { get; set; }

        public LoadForm()
        {
            InitializeComponent();

            // In the case of closing panel
            loaded = false;
        }

        /*Load Saved files*/
        private void bLoad_Click(object sender, EventArgs e)
        {
            // Load file
            this.filePath = "Saved_Documents\\" + this.dView.SelectedCells[0].Value.ToString();
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

                loaded = true;
                File.Delete(this.filePath);
            }
            this.filePath = this.dView.SelectedCells[0].Value.ToString();
            this.Close();
        }

        /*Delete files*/
        private void bDel_Click(object sender, EventArgs e)
        {
            //Delete old files
            loaded = false;

            if (MessageBox.Show("La cancellazione del file è permanente, Proseguire?", "Avviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                //Delete selected files
                File.Delete("Saved_Documents\\" + this.dView.SelectedCells[0].Value.ToString());

                //Reload
                this.dView.Rows.Clear();
                try
                {
                    foreach (var item in Directory.GetFiles("Saved_Documents"))
                    {
                        this.dView.Rows.Add(item.Replace("Saved_Documents", "").Remove(0, 1));
                    }
                }
                catch //(Exception ex)
                {
                    MessageBox.Show("I file non sono raggiungibili", "Errore lettura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void UpdateGrid() 
        {
            // Load Files inside Teh data grid
            if (Directory.Exists("New_Documents_Example") && Directory.GetFiles("New_Documents_Example").Length != 0)
            {
                try
                {
                    foreach (var item in Directory.GetFiles("Saved_Documents"))
                    {
                        this.dView.Rows.Add(item.Replace("Saved_Documents", "").Remove(0, 1));
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
