namespace FPDF
{
    partial class NewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dView = new System.Windows.Forms.DataGridView();
            this.Documenti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dView)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dView
            // 
            this.dView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Documenti});
            this.dView.Location = new System.Drawing.Point(12, 12);
            this.dView.MultiSelect = false;
            this.dView.Name = "dView";
            this.dView.ReadOnly = true;
            this.dView.RowHeadersWidth = 10;
            this.dView.Size = new System.Drawing.Size(272, 400);
            this.dView.TabIndex = 0;
            // 
            // Documenti
            // 
            this.Documenti.HeaderText = "Documents";
            this.Documenti.Name = "Documenti";
            this.Documenti.ReadOnly = true;
            this.Documenti.Width = 260;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.bSelect);
            this.panel2.Location = new System.Drawing.Point(290, 311);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(103, 101);
            this.panel2.TabIndex = 13;
            // 
            // bSelect
            // 
            this.bSelect.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSelect.Location = new System.Drawing.Point(12, 19);
            this.bSelect.Name = "bSelect";
            this.bSelect.Size = new System.Drawing.Size(75, 63);
            this.bSelect.TabIndex = 0;
            this.bSelect.Text = "Seleziona";
            this.bSelect.UseVisualStyleBackColor = true;
            this.bSelect.Click += new System.EventHandler(this.bSelect_Click);
            // 
            // NewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(407, 424);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dView);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "NewForm";
            this.Text = "Nuovo documento";
            ((System.ComponentModel.ISupportInitialize)(this.dView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documenti;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bSelect;
    }
}