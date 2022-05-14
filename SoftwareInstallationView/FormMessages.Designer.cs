
namespace SoftwareInstallationView
{
    partial class FormMessages
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.labelPage = new System.Windows.Forms.Label();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.labelPageMax = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(657, 544);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(138, 573);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(44, 36);
            this.buttonBack.TabIndex = 1;
            this.buttonBack.Text = "<";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(456, 576);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(44, 36);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(678, 250);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(94, 29);
            this.buttonCheck.TabIndex = 3;
            this.buttonCheck.Text = "Открыть";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(222, 581);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(79, 20);
            this.labelPage.TabIndex = 4;
            this.labelPage.Text = "Страница:";
            // 
            // textBoxPage
            // 
            this.textBoxPage.Location = new System.Drawing.Point(307, 581);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(47, 27);
            this.textBoxPage.TabIndex = 5;
            this.textBoxPage.TextChanged += new System.EventHandler(this.textBoxPage_TextChanged);
            // 
            // labelPageMax
            // 
            this.labelPageMax.AutoSize = true;
            this.labelPageMax.Location = new System.Drawing.Point(379, 588);
            this.labelPageMax.Name = "labelPageMax";
            this.labelPageMax.Size = new System.Drawing.Size(36, 20);
            this.labelPageMax.TabIndex = 6;
            this.labelPageMax.Text = "из ?";
            // 
            // FormMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 636);
            this.Controls.Add(this.labelPageMax);
            this.Controls.Add(this.textBoxPage);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormMessages";
            this.Text = "Письма";
            this.Load += new System.EventHandler(this.FormMessages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.Label labelPageMax;
    }
}