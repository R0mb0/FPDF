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
using FPDF.User_Util;

namespace FPDF
{
    public partial class FPDF : Form
    {
        /*--Variables--*/

        /*Working varaibles*/
        private string PDFpath = null;
        private string HTMLpath = null;

        /*form vasriables*/
        private LoginForm login = new LoginForm();
        private NewForm newForm = new NewForm();
        private User user;

        /*--Builder--*/
        public FPDF()
        {
            InitializeComponent();
            
            //hide loading panel
            this.loading.Hide();
            
            //Load login form
            this.login.ShowDialog();

            //Check if the login has been filled
            if (this.login.user != null)
            {
                this.user = this.login.user;
                this.tUserName.Text = user.obtainName();
                this.tUserMail.Text = user.getMail();
            }
            else
            {
                this.Close();
            }
        }

        /*--Private methods--*/

        /*Change element on a string*/
        private string ChangeString(string original, string find, string replace) 
        {
            StringBuilder builder = new StringBuilder(original);
            builder.Replace(find, replace);
            return builder.ToString();
        }

        /*Enable all buttons*/
        private void EnableAll() 
        {
            this.bNew.Enabled = true;
            this.bSave.Enabled = true;
            this.bLoad.Enabled = true;
            this.bHistoric.Enabled = true;
            this.bSend.Enabled = true;
            //this.bDelete.Enabled = true;
        }

        /*Check is a string starts with the strings to check */
        private bool stringStartsWith(string stringtoCheck, string[] stringsToChecks) 
        {
            foreach (var item in stringsToChecks)
            {
                if (stringtoCheck.StartsWith(item) || stringtoCheck.Contains(item))
                { 
                    return true;
                }
            }

            return false;
        }

        /*Remove Page number from string*/
        private string RemoveLineFromFile(string path, string[] stringstoRemove)
        {
            return string.Join("", File.ReadLines(path).Where(line => !stringStartsWith(line, stringstoRemove))); 
        }

        /*New Button*/
        private void bNew_Click(object sender, EventArgs e)
        {
            //Open new panel
            this.newForm.ShowDialog();
            this.PDFpath = newForm.filePath;

            //Show loading image
            this.loading.Show();
            //Reset text boc
            this.pdfTextBox.Clear();


            if (this.PDFpath != null)
            {

                try
                {
                    /*Convert pdf to html*/
                    this.HTMLpath = ChangeString(this.PDFpath, ".pdf", ".html");
                    PdfToHtmlNet.Converter converter = new PdfToHtmlNet.Converter();
                    converter.ConvertToFile(this.PDFpath, this.HTMLpath);

                    /*Prepare strings to check*/
                    string[] stringsToRemove = new string[4];
                    stringsToRemove[0] = "<div style=\"position:absolute; top:50px;\"><a name=\"1\">Page";
                    stringsToRemove[1] = "<div style=\"position:absolute; top:0px;\">Page:";
                    stringsToRemove[2] = "<br></span></div><div style=\"position:absolute; top:0px;\">Page:";
                    stringsToRemove[3] = "<span style=\"font-family: Utopia-Regular; font-size:10px\">1";

                    this.pdfTextBox.LoadFile(new MemoryStream(Encoding.UTF8.GetBytes((MarkupConverter.HtmlToRtfConverter.ConvertHtmlToRtf(RemoveLineFromFile(this.HTMLpath, stringsToRemove))))), RichTextBoxStreamType.RichText);
                }
                catch
                {
                    MessageBox.Show("Il documento ", "Errore di lettura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                /*Delete html temp file*/
                //File.Delete(this.HTMLpath);
            }

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
        private void bDelete_Click(object sender, EventArgs e)
        {
            this.pdfTextBox.Clear();
        }
    }
}
