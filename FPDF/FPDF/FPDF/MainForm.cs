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
using System.Text.RegularExpressions;
using System.Diagnostics;
/**/


namespace FPDF
{
    public partial class FPDF : Form
    {
        /*--Variables--*/

        /*Working varaibles*/
        private string PDFpath = null;
        private string HTMLpath = null;
        private string savePath = null;
        private User user;
        private bool workInProgress;

        /*form vasriables*/
        private LoginForm login = new LoginForm();
        private NewForm newForm = new NewForm();
        private LoadForm loadForm = new LoadForm();
        private HistoricForm historicForm = new HistoricForm();

        /*Filter array*/
        string[] stringsToRemove = new string[4];//<-- careful at this value

        /*Variable to prepare the mail*/
        private string mailCc = null;
        private string mailSubject = "Richiesta inviata dal sistema informatico";

        /*--Builder--*/
        public FPDF()
        {
            InitializeComponent();

            //Set work in progress
            this.workInProgress = false;
            
            //hide loading panel
            this.loading.Hide();

            // Disable buttons at start
            this.bSave.Enabled = false;
            this.bSend.Enabled = false;
            this.bDelete.Enabled = false;

            //Prepare filter strin array
            /*Prepare strings to check*/
            stringsToRemove[0] = "<div style=\"position:absolute; top:50px;\"><a name=\"1\">Page";
            stringsToRemove[1] = "<div style=\"position:absolute; top:0px;\">Page:";
            stringsToRemove[2] = "<br></span></div><div style=\"position:absolute; top:0px;\">Page:";
            stringsToRemove[3] = "<span style=\"font-family: Utopia-Regular; font-size:10px\">1";

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

        /*Check if a string starts with the strings to check */
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
            this.bDelete.Enabled = true;
            this.bDelete.Enabled = true; 
        }

        /*Erase all textfields*/
        private void EraseAll() 
        {
            this.pdfTextBox.Clear();
            this.tMails.Clear();
        }

        /*Get mail or mails from the text*/
        private string GetEmail(string text) 
        {
            Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",RegexOptions.IgnoreCase);
            MatchCollection emailMatches = emailRegex.Matches(text);
            StringBuilder sb = new StringBuilder();
            foreach (Match emailMatch in emailMatches)
            {
                sb.AppendLine(emailMatch.Value);
            }
            return sb.ToString();
        }

        /*Prepare mail for outlook*/
        private void SendMail(string mailTo, string subject, string body)
        {
            Process.Start("mailto:" + mailTo + "?subject=" + subject + "&body=" + body);
        }
        private void SendMail(string mailTo,string cc,string subject, string body)
        {
            Process.Start("mailto:"+ mailTo + "?cc="+cc+"&subject="+subject+"&body=" + body);
        }

        /*In case of closing form*/
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Check text before close panel
            if (this.workInProgress) 
            {

                switch (MessageBox.Show(this, "Ci potrebbero essere delle modifiche in sospeso, Proseguire?", "Avviso", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        break;
                    default:
                        e.Cancel = true;
                        break;
                }
            }
            
        }

        /*-------------------------------------Buttons Part-------------------------------------*/
        /*New Button*/
        private void bNew_Click(object sender, EventArgs e)
        {
            if (this.workInProgress)
            {
                if (MessageBox.Show("Ci potrebbero essere delle modifiche in sospeso, Proseguire?", "Avviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                
            }

            //Prepare before open form
            this.PDFpath = null;

            //Open new panel
            this.newForm.ShowDialog();
            this.PDFpath = newForm.filePath;

            //Show loading image
            this.loading.Show();
            //Reset boxes
            EraseAll();


            if (this.PDFpath != null)
            {
                //Set work in progress variable
                this.workInProgress = true;

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

                //Extract mail from text
                this.tMails.Text = GetEmail(this.pdfTextBox.Text);

                /*Delete html temp file*/
                File.Delete(this.HTMLpath);

                //Enable buttons
                EnableButtons();
            }

            /*Hide loading images*/
            this.loading.Hide();

        }


        /*Save Button*/
        private void bSave_Click(object sender, EventArgs e)
        {
            //Show loading image
            this.loading.Show();

            //This works great only if the path is for a pdf file
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
                //Reset boxes
                EraseAll();
                //Set work in progress variable
                this.workInProgress = false;
            }
            else 
            {
                MessageBox.Show("Il documento non è stato salvato");
            }

            /*Hide loading images*/
            this.loading.Hide();

            //Manage buttons
            EnableButtons();
            //Disable send buttons
            this.bSend.Enabled = false;
        }

        /*Load olds files*/
        private void bLoad_Click(object sender, EventArgs e)
        {
            //Show loading image
            this.loading.Show();

            if (this.workInProgress) 
            {
                if (MessageBox.Show("Ci potrebbero essere delle modifiche in sospeso, Proseguire?", "Avviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) 
                {
                    return; 
                }
            }

            //Prepare before open form
            this.PDFpath = null;
            this.loadForm.loaded = false;

            //Open new panel
            this.loadForm.UpdateGrid();
            this.loadForm.ShowDialog();

            if (this.loadForm.loaded) 
            {
                //Rename file for saving purpose
                this.PDFpath = loadForm.filePath.Remove(0, 20);
                try
                {   //Try to rename 
                    System.IO.File.Move(loadForm.filePath, this.PDFpath);
                }
                catch
                {
                    //Delete old files
                    File.Delete(loadForm.filePath);
                    File.Delete(this.PDFpath);
                    //Now rename
                    System.IO.File.Move(loadForm.filePath, this.PDFpath);
                }
            }
            
            //Reset boxes
            EraseAll();

            if (this.loadForm.loaded && this.PDFpath != null)
            {
                //Set work in progress variable
                this.workInProgress = true;

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

                //Extract mail from text
                this.tMails.Text = GetEmail(this.pdfTextBox.Text);

                /*Delete html temp file*/
                File.Delete(this.HTMLpath);

                    //Enable buttons
                    EnableButtons();
            }
            /*Hide loading images*/
            this.loading.Hide();
        }

        /*View storics files*/
        private void bHistoric_Click(object sender, EventArgs e)
        {

            if (this.workInProgress) 
            {
                if (MessageBox.Show("Ci potrebbero essere delle modifiche in sospeso, Proseguire?", "Avviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) 
                {
                    return;
                }
            }

            //Prepare before open form
            this.PDFpath = null;
            this.historicForm.loaded = false;

            //Open new panel
            this.historicForm.UpdateGrid();
            this.historicForm.ShowDialog();
            this.PDFpath = historicForm.filePath;

            //Show loading image
            this.loading.Show();
            //Reset boxes
            EraseAll();


            if (this.historicForm.loaded && this.PDFpath != null)
            {
                //Set work in progress variable
                this.workInProgress = false;
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
                //Extract mail from text
                this.tMails.Text = GetEmail(this.pdfTextBox.Text);

                /*Delete html temp file*/
                File.Delete(this.HTMLpath);
                File.Delete(this.PDFpath);

                //Manage buttons
                EnableButtons();
                //Disable buttons
                this.bSend.Enabled = false;
                this.bSave.Enabled = false;
            }

            /*Hide loading images*/
            this.loading.Hide();
        }

        /*Send the document*/
        private void bSend_Click(object sender, EventArgs e)
        {
            //Show loading image
            this.loading.Show();

            //Set work in progress variable
            this.workInProgress = false;

            //This works great only if the path is in pdf format
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            HtmlConverter.ConvertToPdf(Rtf.ToHtml(this.pdfTextBox.Rtf.ToString()), new FileStream(this.PDFpath, FileMode.Create));

            if (!Directory.Exists("Sent_Documents"))
            {
                Directory.CreateDirectory("Sent_Documents");
            }
            this.savePath = "Sent_Documents\\" + DateTime.Now.ToString().Replace("/", "-").Replace(" ", "_").Replace(":", "-") + "_" + this.PDFpath;
            File.Copy(this.PDFpath, this.savePath);

            // Open the mail clinet
            if (this.mailCc != null)
            {
                SendMail(this.tMails.Text, this.mailCc, this.mailSubject, this.pdfTextBox.Text);
            }
            else 
            {
                SendMail(this.tMails.Text, this.mailSubject, this.pdfTextBox.Text);
            }

            //Write document in the database
            /*
           //string queryString = "";

               /*using (SqlConnection connection = new SqlConnection(Database.Database.GetDatesDatabaseConnectionString()))
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

            //In the end remove current pdf file
            File.Delete(this.PDFpath);

            //Text the documet
            if (File.Exists(this.savePath))
            {
                MessageBox.Show("Il documento è stato salvato");
                //Reset boxes
                EraseAll();
            }
            else
            {
                MessageBox.Show("Il documento non è stato salvato");
            }

            /*Hide loading images*/
            this.loading.Hide();

            //Manage buttons 
            EnableButtons(); 
            //Disable buttons
            this.bSave.Enabled = false;
        }

        /*Reset buttons*/
        private void bDelete_Click(object sender, EventArgs e)
        {

            if (this.workInProgress) 
            {
                if (MessageBox.Show("Ci potrebbero essere delle modifiche in sospeso, Proseguire?", "Avviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) 
                {
                    return;
                }
            }

            //Set work in progress variable
            this.workInProgress = false;
            //Erase text fields
            EraseAll();
            //Enable buttons
            EnableButtons();
            this.bSave.Enabled = false;
            this.bSend.Enabled = false;
        }
    }
}
