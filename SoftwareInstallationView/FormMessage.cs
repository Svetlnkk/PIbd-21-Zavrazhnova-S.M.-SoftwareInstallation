using SoftwareInstallationContracts.BindingModels;
using SoftwareInstallationContracts.BusinessLogicsContracts;
using SoftwareInstallationContracts.ViewModels;
using SoftwareInstallationContracts.StoragesContracts;
using SoftwareInstallationBusinessLogic.MailWorker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareInstallationView
{
    public partial class FormMessage : Form
    {
        public string MessageId;
        private readonly IMessageInfoLogic _messageLogic;        
        private readonly AbstractMailWorker _mailWorker;        
        public FormMessage(IMessageInfoLogic messageLogic, AbstractMailWorker mailWorker)
        {
            InitializeComponent();
            _messageLogic = messageLogic;
            _mailWorker = mailWorker;            
        }

        private void FormMessage_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            var message = _messageLogic.Read(null).FirstOrDefault(rec => rec.MessageId.Equals(MessageId));
            if (message == null)
            {
                throw new Exception("Письмо не найдено");
            }
            labelSenderName.Text = "Отправитель: " + message.SenderName;
            labelSubject.Text = "Заголовок писмьа: " + message.Subject;
            labelBody.Text = "Текст письма: " + message.Body;
            labelDateDelivery.Text = "Доставлено: " + message.DateDelivery.ToString();
            textBoxReplySubject.Text = "Re: " + message.Subject;
            if (!string.IsNullOrEmpty(message.Reply))
            {
                buttonReply.Enabled = false;
                textBoxReply.Text = message.Reply;
            }
        }

        private void buttonReply_Click(object sender, EventArgs e)
        {
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = labelSenderName.Text,
                Subject = textBoxReplySubject.Text,
                Text = textBoxReply.Text
            });
            _messageLogic.CreateOrUpdate(new MessageInfoBindingModel
            {
                MessageId = MessageId,
                Reply = textBoxReply.Text
            });
            MessageBox.Show("Письмо отправлено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
