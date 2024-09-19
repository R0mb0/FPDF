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
                    axAcropdf1.src = ofd.FileName;
                }
            }
        }
    }
}
