namespace FPDF
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            axAcropdf1 = new AxAcroPDFLib.AxAcroPDF();
            select = new Button();
            ((System.ComponentModel.ISupportInitialize)axAcropdf1).BeginInit();
            SuspendLayout();
            // 
            // axAcropdf1
            // 
            axAcropdf1.Enabled = true;
            axAcropdf1.Location = new Point(12, 12);
            axAcropdf1.Name = "axAcropdf1";
            axAcropdf1.OcxState = (AxHost.State)resources.GetObject("axAcropdf1.OcxState");
            axAcropdf1.Size = new Size(476, 426);
            axAcropdf1.TabIndex = 0;
            // 
            // select
            // 
            select.Location = new Point(713, 415);
            select.Name = "select";
            select.Size = new Size(75, 23);
            select.TabIndex = 1;
            select.Text = "Select";
            select.UseVisualStyleBackColor = true;
            select.Click += select_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(select);
            Controls.Add(axAcropdf1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)axAcropdf1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF axAcropdf1;
        private Button select;
    }
}
