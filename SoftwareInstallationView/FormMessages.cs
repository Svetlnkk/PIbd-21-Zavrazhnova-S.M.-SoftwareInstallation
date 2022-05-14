using SoftwareInstallationContracts.BusinessLogicsContracts;
using SoftwareInstallationContracts.BindingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace SoftwareInstallationView
{
    public partial class FormMessages : Form
    {
        private readonly IMessageInfoLogic _logic;
        private bool _isNext = false;
        private readonly int _messagesOnPage = 3;
        private int _currentPage = 0;
        public FormMessages(IMessageInfoLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }
        private void LoadData()
        {
            var list = _logic.Read(new MessageInfoBindingModel
            {
                ToSkip = _currentPage * _messagesOnPage,
                ToTake = _messagesOnPage + 1
            });
            _isNext = !(list.Count() <= _messagesOnPage);
            if (_isNext)
            {
                buttonNext.Enabled = true;
            }
            else
            {
                buttonNext.Enabled = false;
            }
            if (_currentPage == 0)
            {
                buttonBack.Enabled = false;
            }
            if (list != null)
            {
                dataGridView.DataSource = list.Take(_messagesOnPage).ToList();
            }
        }

        private void FormMessages_Load(object sender, EventArgs e)
        {
            LoadData();
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormMessage>();
                form.MessageId = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                form.ShowDialog();
                LoadData();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (_isNext)
            {
                _currentPage++;
                labelPage.Text = "Страница {" + (_currentPage + 1).ToString() + "}";
                buttonBack.Enabled = true;
                LoadData();
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if ((_currentPage - 1) >= 0)
            {
                _currentPage--;
                labelPage.Text = "Страница {" + (_currentPage + 1).ToString() + "}";
                buttonNext.Enabled = true;
                if (_currentPage == 0)
                {
                    buttonBack.Enabled = false;
                }
                LoadData();
            }
        }
    }
}
