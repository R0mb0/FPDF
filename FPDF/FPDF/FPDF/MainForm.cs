﻿using iText.Html2pdf;
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
        private string savePath = null;

        /*form vasriables*/
        private LoginForm login = new LoginForm();
        private NewForm newForm = new NewForm();
        private LoadForm loadForm = new LoadForm();
        private HistoricForm historicForm = new HistoricForm();

        /*Filter variable*/
        string[] stringsToRemove = new string[4];

        /*--Builder--*/
        public FPDF()
        {
            InitializeComponent();
            
            //hide loading panel
            this.loading.Hide();

            //Prepare filter strin array
            /*Prepare strings to check*/
            stringsToRemove[0] = "<div style=\"position:absolute; top:50px;\"><a name=\"1\">Page";
            stringsToRemove[1] = "<div style=\"position:absolute; top:0px;\">Page:";
            stringsToRemove[2] = "<br></span></div><div style=\"position:absolute; top:0px;\">Page:";
            stringsToRemove[3] = "<span style=\"font-family: Utopia-Regular; font-size:10px\">1";

            /*
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
            }*/
        }

        /*--Private methods--*/

        /*Change element on a string*/
        private string ChangeString(string original, string find, string replace) 
        {
            StringBuilder builder = new StringBuilder(original);
            builder.Replace(find, replace);
            return builder.ToString();
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

        /*Enable Disabled buttons*/
        private void EnableButtons() 
        { 
            this.bSend.Enabled = true;
            this.bSave.Enabled = true;
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

            //Enable buttons
            EnableButtons();


            if (this.PDFpath != null)
            {

                try
                {
                    /*Convert pdf to html*/
                    this.HTMLpath = ChangeString(this.PDFpath, ".pdf", ".html");
                    PdfToHtmlNet.Converter converter = new PdfToHtmlNet.Converter();
                    converter.ConvertToFile(this.PDFpath, this.HTMLpath);

                    this.pdfTextBox.LoadFile(new MemoryStream(Encoding.UTF8.GetBytes((MarkupConverter.HtmlToRtfConverter.ConvertHtmlToRtf(RemoveLineFromFile(this.HTMLpath, stringsToRemove))))), RichTextBoxStreamType.RichText);
                }
                catch
                {
                    MessageBox.Show("Il documento non è caricabile", "Errore di lettura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                /*Delete html temp file*/
                File.Delete(this.HTMLpath);
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

            //MessageBox.Show("Saved_Documents\\"+DateTime.Now.ToString().Replace("/","-").Replace(" ","_").Replace(":","-")+"_"+this.PDFpath);
            if (!Directory.Exists("Saved_Documents")) 
            {
                Directory.CreateDirectory("Saved_Documents");
            }
            this.savePath = "Saved_Documents\\" + DateTime.Now.ToString().Replace("/", "-").Replace(" ", "_").Replace(":", "-") + "_" + this.PDFpath;
            File.Copy(this.PDFpath, this.savePath);
            File.Delete(this.PDFpath);

            //Text the documet
            if (File.Exists(this.savePath))
            {
                MessageBox.Show("Il documento è stato salvato");
                this.pdfTextBox.Clear();
            }
            else 
            {
                MessageBox.Show("Il documento non è stato salvato");
            }
        }

        /*Load olds files*/
        private void bLoad_Click(object sender, EventArgs e)
        {
            //Open new panel
            this.loadForm.ShowDialog();
            this.PDFpath = loadForm.filePath;

            //Show loading image
            this.loading.Show();
            //Reset text boc
            this.pdfTextBox.Clear();

            //Enable buttons
            EnableButtons();

            if (this.loadForm.loaded)
            {
                if (this.PDFpath != null)
                {

                    try
                    {
                        /*Convert pdf to html*/
                        this.HTMLpath = ChangeString(this.PDFpath, ".pdf", ".html");
                        PdfToHtmlNet.Converter converter = new PdfToHtmlNet.Converter();
                        converter.ConvertToFile(this.PDFpath, this.HTMLpath);

                        this.pdfTextBox.LoadFile(new MemoryStream(Encoding.UTF8.GetBytes((MarkupConverter.HtmlToRtfConverter.ConvertHtmlToRtf(RemoveLineFromFile(this.HTMLpath, stringsToRemove))))), RichTextBoxStreamType.RichText);
                    }
                    catch
                    {
                        MessageBox.Show("Il documento non è caricabile", "Errore di lettura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    /*Delete html temp file*/
                    File.Delete(this.HTMLpath);
                }
            }
            else 
            {
                MessageBox.Show("Il documento non è presente", "Errore di lettura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.loading.Hide();
        }

        /*View storics files*/
        private void bHistoric_Click(object sender, EventArgs e)
        {
            //Open new panel
            this.historicForm.ShowDialog();
            this.PDFpath = historicForm.filePath;

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

                    this.pdfTextBox.LoadFile(new MemoryStream(Encoding.UTF8.GetBytes((MarkupConverter.HtmlToRtfConverter.ConvertHtmlToRtf(RemoveLineFromFile(this.HTMLpath, stringsToRemove))))), RichTextBoxStreamType.RichText);
                }
                catch
                {
                    MessageBox.Show("Il documento non è caricabile", "Errore di lettura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                /*Delete html temp file*/
                File.Delete(this.HTMLpath);
                File.Delete(this.PDFpath);
            }

            /*Hide loading images*/
            this.loading.Hide();
            //Disable buttons
            this.bSend.Enabled = false;
            this.bSave.Enabled = false;

        }

        /*Send the document*/
        private void bSend_Click(object sender, EventArgs e)
        {
            //This works great only if the path is in pdf format
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            HtmlConverter.ConvertToPdf(Rtf.ToHtml(this.pdfTextBox.Rtf.ToString()), new FileStream(this.PDFpath, FileMode.Create));

            //MessageBox.Show("Saved_Documents\\"+DateTime.Now.ToString().Replace("/","-").Replace(" ","_").Replace(":","-")+"_"+this.PDFpath);
            if (!Directory.Exists("Sent_Documents"))
            {
                Directory.CreateDirectory("Sent_Documents");
            }
            this.savePath = "Sent_Documents\\" + DateTime.Now.ToString().Replace("/", "-").Replace(" ", "_").Replace(":", "-") + "_" + this.PDFpath;
            File.Copy(this.PDFpath, this.savePath);
            File.Delete(this.PDFpath);

            //Text the documet
            if (File.Exists(this.savePath))
            {
                MessageBox.Show("Il documento è stato salvato");
                this.pdfTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Il documento non è stato salvato");
            }
        }

        /*Reset buttons*/
        private void bDelete_Click(object sender, EventArgs e)
        {
            //Enable buttons
            EnableButtons();
            this.pdfTextBox.Clear();
        }
    }
}
