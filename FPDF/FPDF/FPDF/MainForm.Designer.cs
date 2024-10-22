namespace FPDF
{
    partial class FPDF
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPDF));
            this.pdfTextBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tMails = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tUserMail = new System.Windows.Forms.TextBox();
            this.tUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.bNew = new System.Windows.Forms.Button();
            this.bHistoric = new System.Windows.Forms.Button();
            this.bSend = new System.Windows.Forms.Button();
            this.loading = new System.Windows.Forms.PictureBox();
            this.bDelete = new System.Windows.Forms.Button();
            this.bLoad = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loading)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pdfTextBox
            // 
            this.pdfTextBox.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pdfTextBox.Location = new System.Drawing.Point(13, 12);
            this.pdfTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pdfTextBox.Name = "pdfTextBox";
            this.pdfTextBox.Size = new System.Drawing.Size(576, 364);
            this.pdfTextBox.TabIndex = 0;
            this.pdfTextBox.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.tMails);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tUserMail);
            this.panel1.Controls.Add(this.tUserName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 399);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 120);
            this.panel1.TabIndex = 2;
            // 
            // tMails
            // 
            this.tMails.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tMails.Location = new System.Drawing.Point(283, 37);
            this.tMails.Multiline = true;
            this.tMails.Name = "tMails";
            this.tMails.ReadOnly = true;
            this.tMails.Size = new System.Drawing.Size(265, 73);
            this.tMails.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(338, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Email Destinatario";
            // 
            // tUserMail
            // 
            this.tUserMail.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tUserMail.Location = new System.Drawing.Point(7, 87);
            this.tUserMail.Name = "tUserMail";
            this.tUserMail.ReadOnly = true;
            this.tUserMail.Size = new System.Drawing.Size(209, 28);
            this.tUserMail.TabIndex = 3;
            // 
            // tUserName
            // 
            this.tUserName.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tUserName.Location = new System.Drawing.Point(7, 37);
            this.tUserName.Name = "tUserName";
            this.tUserName.ReadOnly = true;
            this.tUserName.Size = new System.Drawing.Size(209, 26);
            this.tUserName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome Utente";
            // 
            // bSave
            // 
            this.bSave.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSave.Location = new System.Drawing.Point(624, 94);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 5;
            this.bSave.Text = "Salva";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bNew
            // 
            this.bNew.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNew.Location = new System.Drawing.Point(624, 53);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(75, 23);
            this.bNew.TabIndex = 6;
            this.bNew.Text = "Nuovo";
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // bHistoric
            // 
            this.bHistoric.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bHistoric.Location = new System.Drawing.Point(10, 20);
            this.bHistoric.Name = "bHistoric";
            this.bHistoric.Size = new System.Drawing.Size(75, 23);
            this.bHistoric.TabIndex = 7;
            this.bHistoric.Text = "Storico";
            this.bHistoric.UseVisualStyleBackColor = true;
            this.bHistoric.Click += new System.EventHandler(this.bHistoric_Click);
            // 
            // bSend
            // 
            this.bSend.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSend.Location = new System.Drawing.Point(10, 28);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(75, 23);
            this.bSend.TabIndex = 8;
            this.bSend.Text = "Invia";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // loading
            // 
            this.loading.Image = ((System.Drawing.Image)(resources.GetObject("loading.Image")));
            this.loading.Location = new System.Drawing.Point(84, 53);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(438, 285);
            this.loading.TabIndex = 9;
            this.loading.TabStop = false;
            // 
            // bDelete
            // 
            this.bDelete.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDelete.Location = new System.Drawing.Point(10, 74);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(75, 23);
            this.bDelete.TabIndex = 10;
            this.bDelete.Text = "Cancella";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // bLoad
            // 
            this.bLoad.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLoad.Location = new System.Drawing.Point(624, 135);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(75, 23);
            this.bLoad.TabIndex = 11;
            this.bLoad.Text = "Carica";
            this.bLoad.UseVisualStyleBackColor = true;
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Location = new System.Drawing.Point(614, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(97, 153);
            this.panel2.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel3.Controls.Add(this.bSend);
            this.panel3.Controls.Add(this.bDelete);
            this.panel3.Location = new System.Drawing.Point(614, 399);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(97, 120);
            this.panel3.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.bHistoric);
            this.panel4.Location = new System.Drawing.Point(614, 225);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(97, 67);
            this.panel4.TabIndex = 14;
            // 
            // FPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(723, 532);
            this.Controls.Add(this.bLoad);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.bNew);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pdfTextBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FPDF";
            this.Text = "FPDF";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loading)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox pdfTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tUserMail;
        private System.Windows.Forms.TextBox tUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bNew;
        private System.Windows.Forms.TextBox tMails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bHistoric;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.PictureBox loading;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Button bLoad;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}

