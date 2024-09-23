using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*--New Imports--*/
using System.IO;
using iText;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;

namespace FPDF
{
    public partial class FPDF : Form
    {

        String path;

        public FPDF()
        {
            InitializeComponent();
        }

        private void bNew_Click(object sender, EventArgs e)
        {
             

            using (OpenFileDialog ofd = new OpenFileDialog() { ValidateNames = true, Multiselect = false, Filter = "PDF|*.pdf" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path = ofd.FileName;
                }
            }

            try 
            {
                MessageBox.Show(path);

                using (PdfReader pdfReader = new PdfReader(path))
                {
                    using (PdfDocument pdfDocument = new PdfDocument(pdfReader))
                    {
                        for (int page = 1; page <= pdfDocument.GetNumberOfPages(); page++)
                        {
                            string currentText = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(page));
                            currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                            text.Append(currentText);
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
