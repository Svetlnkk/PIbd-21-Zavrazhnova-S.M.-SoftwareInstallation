using SoftwareInstallationContracts.BindingModels;
using SoftwareInstallationContracts.BusinessLogicsContracts;
using SoftwareInstallationContracts.ViewModels;
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
    public partial class FormPackage : Form
    {
        public int Id
        {
            set { id = value; }
        }

        private readonly IPackageLogic _logic;

        private int? id;

        private Dictionary<int, (string, int)> packageComponents;
        public FormPackage(IPackageLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormPackage_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    PackageViewModel view = _logic.Read(new PackageBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxPackageName.Text = view.PackageName;
                        textBoxPackagePrice.Text = view.Price.ToString();
                        packageComponents = view.PackageComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                packageComponents = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (packageComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in packageComponents)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPackageName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPackagePrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (packageComponents == null || packageComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new PackageBindingModel
                {
                    Id = id,
                    PackageName = textBoxPackageName.Text,
                    Price = Convert.ToDecimal(textBoxPackagePrice.Text),
                    PackageComponents = packageComponents
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAddComponent_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormPackageComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (packageComponents.ContainsKey(form.Id))
                {
                    packageComponents[form.Id] = (form.ComponentName, form.Count);
                }
                else
                {
                    packageComponents.Add(form.Id, (form.ComponentName, form.Count));
                }
                LoadData();
            }
        }

        private void btnEditComponent_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormPackageComponent>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[1].Value);
                form.Id = id;
                form.Count = packageComponents[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    packageComponents[form.Id] = (form.ComponentName, form.Count);
                    LoadData();
                }
            }
        }

        private void btnRemoveComponent_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        packageComponents.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void btnUpdateComponent_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
