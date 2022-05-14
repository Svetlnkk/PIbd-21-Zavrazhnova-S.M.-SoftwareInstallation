using SoftwareInstallationContracts.BindingModels;
using SoftwareInstallationContracts.BusinessLogicsContracts;
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
    public partial class FormPackages : Form
    {
        private readonly IPackageLogic _logic;
        public FormPackages(IPackageLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormPackages_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = _logic.Read(null);
                Program.ConfigGrid(list, dataGridView);
                if (list != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var package in list)
                    {
                        string strComponents = string.Empty;
                        foreach (var component in package.PackageComponents)
                        {
                            strComponents += component.Value.Item1 + " = " + component.Value.Item2 + " шт.; ";
                        }
                        dataGridView.Rows.Add(new object[] { package.Id, package.PackageName, package.Price, strComponents });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormPackage>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormPackage>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[1].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[1].Value);
                    try
                    {
                        _logic.Delete(new PackageBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
