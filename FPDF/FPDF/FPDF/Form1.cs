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
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace FPDF
{
    public partial class FPDF : Form
    {
        /*--Variables--*/
        private string path;

        /*--Builder--*/
        public FPDF()
        {
            InitializeComponent();
            this.loading.Hide();
        }

        /*New Button*/
        private void bNew_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog ofd = new OpenFileDialog() { ValidateNames = true, Multiselect = false, Filter = "PDF|*.pdf" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path = ofd.FileName;
                }
            }

            /*Show loading image*/
            this.loading.Show();
            /*Reset text boc*/
            this.pdfTextBox.Clear();
            
            try 
            {
                
                using (PdfReader pdfReader = new PdfReader(path))
                {
                    using (PdfDocument pdfDocument = new PdfDocument(pdfReader))
                    {
                        for (int page = 1; page <= pdfDocument.GetNumberOfPages(); page++)
                        {
                            string currentText = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(page));
                            //currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                            //text.Append(currentText);
                            this.pdfTextBox.AppendText(currentText);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            /*Hide loading images*/
            this.loading.Hide();
        }

        /*Save Button*/
        private void bSave_Click(object sender, EventArgs e)
        {
            if (this.path != null) 
            {
                try
                {
                    PdfWriter writer = new PdfWriter(path);
                    PdfDocument pdf = new PdfDocument(writer);
                    iText.Layout.Document document = new iText.Layout.Document(pdf);

                    iText.Layout.Element.Paragraph paragraph = new iText.Layout.Element.Paragraph(this.pdfTextBox.Text);

                    document.Add(paragraph);
                    document.Close();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Non è stato aperto un documento");
            }

            this.loading.Hide();
        }
    }
}
