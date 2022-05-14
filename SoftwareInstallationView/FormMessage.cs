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
        private readonly IMessageInfoLogic _messageLogic;
        private readonly IClientStorage _clientStorage;
        private readonly AbstractMailWorker _mailWorker;
        private string _messageId;
        public string MessageId { set { _messageId = value; } }
        public FormMessage(IMessageInfoLogic messageLogic, AbstractMailWorker mailWorker, IClientStorage clientStorage)
        {
            InitializeComponent();
            _messageLogic = messageLogic;
            _mailWorker = mailWorker;
            _clientStorage = clientStorage;
        }

        private void FormMessage_Load(object sender, EventArgs e)
        {
            if (_messageId != null)
            {
                try
                {
                    MessageInfoViewModel mes = _messageLogic.Read(new MessageInfoBindingModel { MessageId = _messageId })?[0];
                    if (mes != null)
                    {
                        if (!mes.Checked)
                        {
                            _messageLogic.CreateOrUpdate(new MessageInfoBindingModel
                            {
                                MessageId = _messageId,
                                FromMailAddress = mes.SenderName,
                                Subject = mes.Subject,
                                Body = mes.Body,
                                DateDelivery = mes.DateDelivery,
                                Checked = true,
                                AnswerText = mes.AnswerText
                            });
                        }
                        labelSenderNameRes.Text = mes.SenderName;
                        labelDateDeliveryRes.Text = mes.DateDelivery.ToString();
                        labelSubjectRes.Text = mes.Subject;
                        labelBodyRes.Text = mes.Body;
                        textBoxAnswerText.Text = mes.AnswerText;
                        if (!string.IsNullOrEmpty(mes.AnswerText))
                        {
                            buttonSave.Enabled = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + _messageId, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAnswerText.Text))
            {
                MessageBox.Show("Введите ответ на письмо", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _messageLogic.CreateOrUpdate(new MessageInfoBindingModel
                {
                    ClientId = _clientStorage.GetElement(new ClientBindingModel { Login = labelSenderNameRes.Text })?.Id,
                    MessageId = _messageId,
                    FromMailAddress = labelSenderNameRes.Text,
                    Subject = labelSubjectRes.Text,
                    Body = labelBodyRes.Text,
                    DateDelivery = DateTime.Parse(labelDateDeliveryRes.Text),
                    Checked = true,
                    AnswerText = textBoxAnswerText.Text
                });

                _mailWorker.MailSendAsync(new MailSendInfoBindingModel
                {
                    MailAddress = labelSenderNameRes.Text,
                    Subject = "Ответ: <" + labelSubjectRes.Text + ">",
                    Text = textBoxAnswerText.Text
                });
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
