using iText.Html2pdf;
using iText.Kernel.Pdf;
using RtfPipe;
using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml.Linq;
/*--New Imports--*/

/**/


/*--My Classes--*/
//using FPDF.PDF_Util;

namespace FPDF
{
    public partial class FPDF : Form
    {
        /*--Variables--*/
        private string PDFpath;
        private string HTMLpath;
        //private string filename;

        /*--Builder--*/
        public FPDF()
        {
            InitializeComponent();
            this.loading.Hide();
        }

        /*--Private methods--*/
        private string ChangeString(string original, string find, string replace) 
        {
            StringBuilder builder = new StringBuilder(original);
            builder.Replace(find, replace);
            return builder.ToString();
        }

        /*New Button*/
        private void bNew_Click(object sender, EventArgs e)
        {
            //Show loading image
            this.loading.Show();
            //Reset text boc
            this.pdfTextBox.Clear();

            // Create an OpenFileDialog to request a file to open.
            OpenFileDialog openFile1 = new OpenFileDialog();

            // Initialize the OpenFileDialog to look for RTF files.
            //openFile1.DefaultExt = "*.rtf";
            //openFile1.Filter = "RTF Files|*.rtf";

            openFile1.DefaultExt = "*.pdf";
            openFile1.Filter = "PDF Files|*.pdf";

            // Determine whether the user selected a file from the OpenFileDialog. 
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               openFile1.FileName.Length > 0)
            {
                this.PDFpath = openFile1.FileName;
            }

            /*Convert pdf to html*/
            this.HTMLpath = ChangeString(this.PDFpath, ".pdf", ".html");
            PdfToHtmlNet.Converter converter = new PdfToHtmlNet.Converter();
            converter.ConvertToFile(this.PDFpath,this.HTMLpath);

            this.pdfTextBox.LoadFile(new MemoryStream(Encoding.UTF8.GetBytes((MarkupConverter.HtmlToRtfConverter.ConvertHtmlToRtf(File.ReadAllText(this.HTMLpath))))), RichTextBoxStreamType.RichText);

            /*Delete html temp file*/
            File.Delete(this.HTMLpath);

            /*Hide loading images*/
            this.loading.Hide();
        }

        /*Save Button*/
        private void bSave_Click(object sender, EventArgs e)
        {
            //This works great only if the path is in pdf format
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            HtmlConverter.ConvertToPdf(Rtf.ToHtml(this.pdfTextBox.Rtf.ToString()), new FileStream(this.PDFpath, FileMode.Create));

            /*Send a postivie message*/
            MessageBox.Show("Il documento è stato inviato");
            
        }

        /*View storics files*/
        private void bHistoric_Click(object sender, EventArgs e)
        {
            
        }

        /*Reset buttons*/
        private void delete_Click(object sender, EventArgs e)
        {
            this.pdfTextBox.Clear();
        }
    }
}
