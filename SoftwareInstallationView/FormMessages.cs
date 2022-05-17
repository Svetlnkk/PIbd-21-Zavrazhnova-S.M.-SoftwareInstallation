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
        int currentPage = 1;        
        public FormMessages(IMessageInfoLogic logic)
        {
            InitializeComponent();
            _logic = logic;            
        }
        private void LoadData()
        {
            try
            {
                var list = _logic.Read(new MessageInfoBindingModel
                {
                    PageNumber = currentPage
                });
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[1].ReadOnly = true;
                }
                textBoxPage.Text = currentPage.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       

        private void FormMessages_Load(object sender, EventArgs e)
        {
            LoadData();            
            
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
            int stringsCountOnPage = _logic.Read(new MessageInfoBindingModel
            {
                PageNumber = currentPage + 1
            }).Count;

            if (stringsCountOnPage != 0)
            {
                currentPage++;
                LoadData();
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
            }
            LoadData();
        }

        private void textBoxPage_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPage.Text != "")
            {
                int textBoxNumber = Convert.ToInt32(textBoxPage.Text);
                int stringsCountOnPage = _logic.Read(new MessageInfoBindingModel
                {
                    PageNumber = textBoxNumber
                }).Count;

                if (textBoxNumber > 1 && stringsCountOnPage != 0)
                {
                    currentPage = textBoxNumber;
                    LoadData();
                }
            }
        }
    }
}
