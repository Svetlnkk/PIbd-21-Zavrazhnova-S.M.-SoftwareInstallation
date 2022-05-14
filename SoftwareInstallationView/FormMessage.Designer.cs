
namespace SoftwareInstallationView
{
    partial class FormMessage
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
        private void InitializeComponent()
        {
            this.labelSenderName = new System.Windows.Forms.Label();
            this.labelDateDelivery = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.labelBody = new System.Windows.Forms.Label();
            this.labelAnswerText = new System.Windows.Forms.Label();
            this.textBoxAnswerText = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelSenderNameRes = new System.Windows.Forms.Label();
            this.labelDateDeliveryRes = new System.Windows.Forms.Label();
            this.labelSubjectRes = new System.Windows.Forms.Label();
            this.labelBodyRes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSenderName
            // 
            this.labelSenderName.AutoSize = true;
            this.labelSenderName.Location = new System.Drawing.Point(12, 27);
            this.labelSenderName.Name = "labelSenderName";
            this.labelSenderName.Size = new System.Drawing.Size(102, 20);
            this.labelSenderName.TabIndex = 0;
            this.labelSenderName.Text = "Отправитель:";
            // 
            // labelDateDelivery
            // 
            this.labelDateDelivery.AutoSize = true;
            this.labelDateDelivery.Location = new System.Drawing.Point(12, 68);
            this.labelDateDelivery.Name = "labelDateDelivery";
            this.labelDateDelivery.Size = new System.Drawing.Size(100, 20);
            this.labelDateDelivery.TabIndex = 1;
            this.labelDateDelivery.Text = "Дата письма:";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(12, 121);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(84, 20);
            this.labelSubject.TabIndex = 2;
            this.labelSubject.Text = "Заголовок:";
            // 
            // labelBody
            // 
            this.labelBody.AutoSize = true;
            this.labelBody.Location = new System.Drawing.Point(19, 177);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(48, 20);
            this.labelBody.TabIndex = 3;
            this.labelBody.Text = "Текст:";
            // 
            // labelAnswerText
            // 
            this.labelAnswerText.AutoSize = true;
            this.labelAnswerText.Location = new System.Drawing.Point(19, 258);
            this.labelAnswerText.Name = "labelAnswerText";
            this.labelAnswerText.Size = new System.Drawing.Size(51, 20);
            this.labelAnswerText.TabIndex = 4;
            this.labelAnswerText.Text = "Ответ:";
            // 
            // textBoxAnswerText
            // 
            this.textBoxAnswerText.Location = new System.Drawing.Point(20, 297);
            this.textBoxAnswerText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxAnswerText.Name = "textBoxAnswerText";
            this.textBoxAnswerText.Size = new System.Drawing.Size(384, 27);
            this.textBoxAnswerText.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(79, 369);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(106, 31);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(249, 369);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(86, 31);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelSenderNameRes
            // 
            this.labelSenderNameRes.AutoSize = true;
            this.labelSenderNameRes.Location = new System.Drawing.Point(165, 40);
            this.labelSenderNameRes.Name = "labelSenderNameRes";
            this.labelSenderNameRes.Size = new System.Drawing.Size(0, 20);
            this.labelSenderNameRes.TabIndex = 8;
            // 
            // labelDateDeliveryRes
            // 
            this.labelDateDeliveryRes.AutoSize = true;
            this.labelDateDeliveryRes.Location = new System.Drawing.Point(165, 95);
            this.labelDateDeliveryRes.Name = "labelDateDeliveryRes";
            this.labelDateDeliveryRes.Size = new System.Drawing.Size(0, 20);
            this.labelDateDeliveryRes.TabIndex = 9;
            // 
            // labelSubjectRes
            // 
            this.labelSubjectRes.AutoSize = true;
            this.labelSubjectRes.Location = new System.Drawing.Point(165, 147);
            this.labelSubjectRes.Name = "labelSubjectRes";
            this.labelSubjectRes.Size = new System.Drawing.Size(0, 20);
            this.labelSubjectRes.TabIndex = 10;
            // 
            // labelBodyRes
            // 
            this.labelBodyRes.AutoSize = true;
            this.labelBodyRes.Location = new System.Drawing.Point(165, 199);
            this.labelBodyRes.Name = "labelBodyRes";
            this.labelBodyRes.Size = new System.Drawing.Size(0, 20);
            this.labelBodyRes.TabIndex = 11;
            // 
            // FormMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 435);
            this.Controls.Add(this.labelBodyRes);
            this.Controls.Add(this.labelSubjectRes);
            this.Controls.Add(this.labelDateDeliveryRes);
            this.Controls.Add(this.labelSenderNameRes);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxAnswerText);
            this.Controls.Add(this.labelAnswerText);
            this.Controls.Add(this.labelBody);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.labelDateDelivery);
            this.Controls.Add(this.labelSenderName);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMessage";
            this.Text = "Письмо";
            this.Load += new System.EventHandler(this.FormMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label labelSenderName;
        private System.Windows.Forms.Label labelDateDelivery;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.Label labelBody;
        private System.Windows.Forms.Label labelAnswerText;
        private System.Windows.Forms.TextBox textBoxAnswerText;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelSenderNameRes;
        private System.Windows.Forms.Label labelDateDeliveryRes;
        private System.Windows.Forms.Label labelSubjectRes;
        private System.Windows.Forms.Label labelBodyRes;
    }
}