
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
            this.textBoxReply = new System.Windows.Forms.TextBox();
            this.buttonReply = new System.Windows.Forms.Button();
            this.labelSenderName = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.labelBody = new System.Windows.Forms.Label();
            this.labelDateDelivery = new System.Windows.Forms.Label();
            this.textBoxReplySubject = new System.Windows.Forms.TextBox();
            this.labelReplySubject = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxReply
            // 
            this.textBoxReply.Location = new System.Drawing.Point(14, 504);
            this.textBoxReply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxReply.Multiline = true;
            this.textBoxReply.Name = "textBoxReply";
            this.textBoxReply.Size = new System.Drawing.Size(886, 329);
            this.textBoxReply.TabIndex = 0;
            // 
            // buttonReply
            // 
            this.buttonReply.Location = new System.Drawing.Point(720, 851);
            this.buttonReply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonReply.Name = "buttonReply";
            this.buttonReply.Size = new System.Drawing.Size(161, 44);
            this.buttonReply.TabIndex = 1;
            this.buttonReply.Text = "Отправить ответ";
            this.buttonReply.UseVisualStyleBackColor = true;
            this.buttonReply.Click += new System.EventHandler(this.buttonReply_Click);
            // 
            // labelSenderName
            // 
            this.labelSenderName.AutoSize = true;
            this.labelSenderName.Location = new System.Drawing.Point(24, 29);
            this.labelSenderName.Name = "labelSenderName";
            this.labelSenderName.Size = new System.Drawing.Size(102, 20);
            this.labelSenderName.TabIndex = 2;
            this.labelSenderName.Text = "Отправитель:";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(32, 73);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(84, 20);
            this.labelSubject.TabIndex = 3;
            this.labelSubject.Text = "Заголовок:";
            // 
            // labelBody
            // 
            this.labelBody.AutoSize = true;
            this.labelBody.Location = new System.Drawing.Point(113, 164);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(48, 20);
            this.labelBody.TabIndex = 4;
            this.labelBody.Text = "Текст:";
            // 
            // labelDateDelivery
            // 
            this.labelDateDelivery.AutoSize = true;
            this.labelDateDelivery.Location = new System.Drawing.Point(32, 116);
            this.labelDateDelivery.Name = "labelDateDelivery";
            this.labelDateDelivery.Size = new System.Drawing.Size(94, 20);
            this.labelDateDelivery.TabIndex = 5;
            this.labelDateDelivery.Text = "Доставлено:";
            // 
            // textBoxReplySubject
            // 
            this.textBoxReplySubject.Location = new System.Drawing.Point(95, 451);
            this.textBoxReplySubject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxReplySubject.Name = "textBoxReplySubject";
            this.textBoxReplySubject.Size = new System.Drawing.Size(724, 27);
            this.textBoxReplySubject.TabIndex = 6;
            // 
            // labelReplySubject
            // 
            this.labelReplySubject.AutoSize = true;
            this.labelReplySubject.Location = new System.Drawing.Point(14, 455);
            this.labelReplySubject.Name = "labelReplySubject";
            this.labelReplySubject.Size = new System.Drawing.Size(81, 20);
            this.labelReplySubject.TabIndex = 7;
            this.labelReplySubject.Text = "Заголовок";
            // 
            // FormMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 911);
            this.Controls.Add(this.labelReplySubject);
            this.Controls.Add(this.textBoxReplySubject);
            this.Controls.Add(this.labelDateDelivery);
            this.Controls.Add(this.labelBody);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.labelSenderName);
            this.Controls.Add(this.buttonReply);
            this.Controls.Add(this.textBoxReply);
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
        private System.Windows.Forms.TextBox textBoxReply;
        private System.Windows.Forms.Button buttonReply;
        private System.Windows.Forms.TextBox textBoxReplySubject;
        private System.Windows.Forms.Label labelReplySubject;        
    }
}