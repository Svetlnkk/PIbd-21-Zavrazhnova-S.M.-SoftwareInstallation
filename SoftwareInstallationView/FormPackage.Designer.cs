
namespace SoftwareInstallationView
{
    partial class FormPackage
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPackagePrice = new System.Windows.Forms.TextBox();
            this.textBoxPackageName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBoxComponents = new System.Windows.Forms.GroupBox();
            this.btnAddComponent = new System.Windows.Forms.Button();
            this.btnEditComponent = new System.Windows.Forms.Button();
            this.btnRemoveComponent = new System.Windows.Forms.Button();
            this.btnUpdateComponent = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ComponentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComponentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComponentCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Цена:";
            // 
            // textBoxPackagePrice
            // 
            this.textBoxPackagePrice.Location = new System.Drawing.Point(120, 51);
            this.textBoxPackagePrice.Name = "textBoxPackagePrice";
            this.textBoxPackagePrice.Size = new System.Drawing.Size(205, 27);
            this.textBoxPackagePrice.TabIndex = 2;
            // 
            // textBoxPackageName
            // 
            this.textBoxPackageName.Location = new System.Drawing.Point(120, 11);
            this.textBoxPackageName.Name = "textBoxPackageName";
            this.textBoxPackageName.Size = new System.Drawing.Size(205, 27);
            this.textBoxPackageName.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(534, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 37);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(534, 74);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 33);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBoxComponents
            // 
            this.groupBoxComponents.Controls.Add(this.dataGridView);
            this.groupBoxComponents.Controls.Add(this.btnUpdateComponent);
            this.groupBoxComponents.Controls.Add(this.btnRemoveComponent);
            this.groupBoxComponents.Controls.Add(this.btnEditComponent);
            this.groupBoxComponents.Controls.Add(this.btnAddComponent);
            this.groupBoxComponents.Location = new System.Drawing.Point(1, 113);
            this.groupBoxComponents.Name = "groupBoxComponents";
            this.groupBoxComponents.Size = new System.Drawing.Size(643, 334);
            this.groupBoxComponents.TabIndex = 6;
            this.groupBoxComponents.TabStop = false;
            this.groupBoxComponents.Text = "Компоненты";
            // 
            // btnAddComponent
            // 
            this.btnAddComponent.Location = new System.Drawing.Point(533, 47);
            this.btnAddComponent.Name = "btnAddComponent";
            this.btnAddComponent.Size = new System.Drawing.Size(94, 29);
            this.btnAddComponent.TabIndex = 0;
            this.btnAddComponent.Text = "Добавить";
            this.btnAddComponent.UseVisualStyleBackColor = true;
            this.btnAddComponent.Click += new System.EventHandler(this.btnAddComponent_Click);
            // 
            // btnEditComponent
            // 
            this.btnEditComponent.Location = new System.Drawing.Point(533, 99);
            this.btnEditComponent.Name = "btnEditComponent";
            this.btnEditComponent.Size = new System.Drawing.Size(94, 29);
            this.btnEditComponent.TabIndex = 1;
            this.btnEditComponent.Text = "Изменить";
            this.btnEditComponent.UseVisualStyleBackColor = true;
            this.btnEditComponent.Click += new System.EventHandler(this.btnEditComponent_Click);
            // 
            // btnRemoveComponent
            // 
            this.btnRemoveComponent.Location = new System.Drawing.Point(533, 153);
            this.btnRemoveComponent.Name = "btnRemoveComponent";
            this.btnRemoveComponent.Size = new System.Drawing.Size(94, 29);
            this.btnRemoveComponent.TabIndex = 2;
            this.btnRemoveComponent.Text = "Удалить";
            this.btnRemoveComponent.UseVisualStyleBackColor = true;
            this.btnRemoveComponent.Click += new System.EventHandler(this.btnRemoveComponent_Click);
            // 
            // btnUpdateComponent
            // 
            this.btnUpdateComponent.Location = new System.Drawing.Point(533, 210);
            this.btnUpdateComponent.Name = "btnUpdateComponent";
            this.btnUpdateComponent.Size = new System.Drawing.Size(94, 29);
            this.btnUpdateComponent.TabIndex = 3;
            this.btnUpdateComponent.Text = "Обновить";
            this.btnUpdateComponent.UseVisualStyleBackColor = true;
            this.btnUpdateComponent.Click += new System.EventHandler(this.btnUpdateComponent_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ComponentId,
            this.ComponentName,
            this.ComponentCount});
            this.dataGridView.Location = new System.Drawing.Point(0, 26);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(509, 302);
            this.dataGridView.TabIndex = 4;
            // 
            // ComponentId
            // 
            this.ComponentId.HeaderText = "Id";
            this.ComponentId.MinimumWidth = 6;
            this.ComponentId.Name = "ComponentId";
            this.ComponentId.Visible = false;
            this.ComponentId.Width = 125;
            // 
            // ComponentName
            // 
            this.ComponentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ComponentName.HeaderText = "Компонент";
            this.ComponentName.MinimumWidth = 6;
            this.ComponentName.Name = "ComponentName";
            // 
            // ComponentCount
            // 
            this.ComponentCount.HeaderText = "Количество";
            this.ComponentCount.MinimumWidth = 6;
            this.ComponentCount.Name = "ComponentCount";
            this.ComponentCount.Width = 125;
            // 
            // FormPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 450);
            this.Controls.Add(this.groupBoxComponents);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBoxPackageName);
            this.Controls.Add(this.textBoxPackagePrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormPackage";
            this.Text = "Изделие";
            this.Load += new System.EventHandler(this.FormPackage_Load);
            this.groupBoxComponents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPackagePrice;
        private System.Windows.Forms.TextBox textBoxPackageName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBoxComponents;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComponentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComponentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComponentCount;
        private System.Windows.Forms.Button btnUpdateComponent;
        private System.Windows.Forms.Button btnRemoveComponent;
        private System.Windows.Forms.Button btnEditComponent;
        private System.Windows.Forms.Button btnAddComponent;
    }
}