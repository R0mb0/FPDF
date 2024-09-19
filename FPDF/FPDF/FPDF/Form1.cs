using AxAcroPDFLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void select_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { ValidateNames = true, Multiselect = false, Filter = "PDF|*.pdf" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.axAcroPDF.src = ofd.FileName;
                }
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            this.axAcroPDF.Print();
        }
    }
}
