
namespace SoftwareInstallationView
{
    partial class FormReportOrdersDate
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
            this.panel = new System.Windows.Forms.Panel();
            this.btnToPdf = new System.Windows.Forms.Button();
            this.btnMake = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.btnToPdf);
            this.panel.Controls.Add(this.btnMake);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(894, 65);
            this.panel.TabIndex = 0;
            // 
            // btnToPdf
            // 
            this.btnToPdf.Location = new System.Drawing.Point(510, 23);
            this.btnToPdf.Name = "btnToPdf";
            this.btnToPdf.Size = new System.Drawing.Size(151, 29);
            this.btnToPdf.TabIndex = 4;
            this.btnToPdf.Text = "в pdf";
            this.btnToPdf.UseVisualStyleBackColor = true;
            this.btnToPdf.Click += new System.EventHandler(this.btnToPdf_Click);
            // 
            // btnMake
            // 
            this.btnMake.Location = new System.Drawing.Point(154, 23);
            this.btnMake.Name = "btnMake";
            this.btnMake.Size = new System.Drawing.Size(145, 29);
            this.btnMake.TabIndex = 3;
            this.btnMake.Text = "Сформировать";
            this.btnMake.UseVisualStyleBackColor = true;
            this.btnMake.Click += new System.EventHandler(this.btnMake_Click);
            // 
            // FormReportOrdersDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 443);
            this.Controls.Add(this.panel);
            this.Name = "FormReportOrdersDate";
            this.Text = "Отчет заказов по дате";
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnToPdf;
        private System.Windows.Forms.Button btnMake;
    }
}