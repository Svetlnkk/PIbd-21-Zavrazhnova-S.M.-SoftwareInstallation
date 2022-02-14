using SoftwareInstallationContracts.BindingModels;
using SoftwareInstallationContracts.ViewModels;
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

namespace SoftwareInstallationView
{
    public partial class FormWarehouse : Form
    {
        public int Id { set { id = value; } }
        private readonly IWarehouseLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> warehouseComponents;
        public FormWarehouse(IWarehouseLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormWarehouse_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    WarehouseViewModel view = logic.Read(new WarehouseBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.WarehouseName;
                        textBoxFIO.Text = view.Responsible;
                        warehouseComponents = view.WarehouseComponents;
                        if (warehouseComponents != null)
                        {
                            dataGridView.Rows.Clear();
                            foreach (var pc in warehouseComponents)
                            {
                                dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                warehouseComponents = new Dictionary<int, (string, int)>();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название склада", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new WarehouseBindingModel
                {
                    Id = id,
                    WarehouseName = textBoxName.Text,
                    Responsible = textBoxFIO.Text,
                    WarehouseComponents = warehouseComponents,
                    DateCreate = DateTime.Now
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
