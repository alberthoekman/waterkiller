namespace Waterkiller
{
    partial class Form1
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
            this.btScan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btMapSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btScan
            // 
            this.btScan.Location = new System.Drawing.Point(430, 61);
            this.btScan.Name = "btScan";
            this.btScan.Size = new System.Drawing.Size(75, 23);
            this.btScan.TabIndex = 0;
            this.btScan.Text = "Scan";
            this.btScan.UseVisualStyleBackColor = true;
            this.btScan.Click += new System.EventHandler(this.btScan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(373, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // btMapSelect
            // 
            this.btMapSelect.Location = new System.Drawing.Point(415, 16);
            this.btMapSelect.Name = "btMapSelect";
            this.btMapSelect.Size = new System.Drawing.Size(90, 23);
            this.btMapSelect.TabIndex = 2;
            this.btMapSelect.Text = "Select Map...";
            this.btMapSelect.UseVisualStyleBackColor = true;
            this.btMapSelect.Click += new System.EventHandler(this.btMapSelect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 332);
            this.Controls.Add(this.btMapSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btScan);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btScan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btMapSelect;
    }
}

