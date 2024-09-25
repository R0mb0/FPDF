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
using System.Windows.Controls;
/**/


/*--My Classes--*/
//using FPDF.PDF_Util;

namespace FPDF
{
    public partial class FPDF : Form
    {
        /*--Variables--*/
        private string path;
        private string filename;

        /*--Builder--*/
        public FPDF()
        {
            InitializeComponent();
            this.loading.Hide();
        }

        /*New Button*/
        private void bNew_Click(object sender, EventArgs e)
        {

            // Create an OpenFileDialog to request a file to open.
            OpenFileDialog openFile1 = new OpenFileDialog();

            // Initialize the OpenFileDialog to look for RTF files.
            openFile1.DefaultExt = "*.rtf";
            openFile1.Filter = "RTF Files|*.rtf";

            // Determine whether the user selected a file from the OpenFileDialog. 
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               openFile1.FileName.Length > 0)
            {
                // Load the contents of the file into the RichTextBox.
               this.pdfTextBox.LoadFile(openFile1.FileName);
            }

            /*using (OpenFileDialog ofd = new OpenFileDialog() { ValidateNames = true, Multiselect = false, Filter = "PDF|*.pdf" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path = ofd.FileName;
                }
            }*/

            //Show loading image
            //this.loading.Show();
            //Reset text boc
            //this.pdfTextBox.Clear();


            // try 
            // {

            /*using (PdfReader pdfReader = new PdfReader(path))
             {
                 using (iText.Kernel.Pdf.PdfDocument pdfDocument = new iText.Kernel.Pdf.PdfDocument(pdfReader))
                 {


                    for (int page = 1; page <= pdfDocument.GetNumberOfPages(); page++)
                     {
                        string currentText = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(page));
                        //currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                        this.pdfTextBox.AppendText(currentText);
                        PdfTextExtractor.GetTextFromPage
                    }
                 }
             }*/


            /* }
             catch (Exception ex)
              {
                  MessageBox.Show(ex.Message);
              }*/

            /*Hide loading images*/
            // this.loading.Hide();
        }

        /*Save Button*/
        private void bSave_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.SaveFileDialog saveFileDialog1;
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
                //save file using stream.
            }


            //if (this.path != null) 
            //{
            try
                {
                    PdfWriter writer = new PdfWriter(filename);
                    iText.Kernel.Pdf.PdfDocument pdf = new iText.Kernel.Pdf.PdfDocument(writer);
                    iText.Layout.Document document = new iText.Layout.Document(pdf);

                    iText.Layout.Element.Paragraph paragraph = new iText.Layout.Element.Paragraph(this.pdfTextBox.Text);

                    document.Add(paragraph);
                    document.Close();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            /*}
            else
            {
                MessageBox.Show("Non è stato aperto un documento");
            }*/

            this.loading.Hide();
        }

        /*Reset buttons*/
        private void delete_Click(object sender, EventArgs e)
        {
            this.pdfTextBox.Clear();
        }
    }
}
