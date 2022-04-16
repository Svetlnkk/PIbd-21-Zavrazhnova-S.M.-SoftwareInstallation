﻿
namespace SoftwareInstallationView
{
    partial class FormMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнениеСкладаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокДеталейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияПоКомпонентамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.btnTakeOrderInWork = new System.Windows.Forms.Button();
            this.btnOrderReady = new System.Windows.Forms.Button();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.btnIssuedOrder = new System.Windows.Forms.Button();
            this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокСкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыПоКомпонентамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовПоДатеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пополнениеСкладаToolStripMenuItem,
            this.отчетыToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1152, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.изделияToolStripMenuItem,
            this.складыToolStripMenuItem,
            this.клиентыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.компонентыToolStripMenuItem_Click);
            // 
            // изделияToolStripMenuItem
            // 
            this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            this.изделияToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.изделияToolStripMenuItem.Text = "Изделия";
            this.изделияToolStripMenuItem.Click += new System.EventHandler(this.изделияToolStripMenuItem_Click);
            // 
            // пополнениеСкладаToolStripMenuItem
            // 
            this.пополнениеСкладаToolStripMenuItem.Name = "пополнениеСкладаToolStripMenuItem";
            this.пополнениеСкладаToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.пополнениеСкладаToolStripMenuItem.Text = "Пополнение склада";
            this.пополнениеСкладаToolStripMenuItem.Click += new System.EventHandler(this.пополнениеСкладаToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокДеталейToolStripMenuItem,
            this.изделияПоКомпонентамToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem,
            this.списокСкладовToolStripMenuItem,
            this.складыПоКомпонентамToolStripMenuItem,
            this.списокЗаказовПоДатеToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокДеталейToolStripMenuItem
            // 
            this.списокДеталейToolStripMenuItem.Name = "списокДеталейToolStripMenuItem";
            this.списокДеталейToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.списокДеталейToolStripMenuItem.Text = "Список изделий";
            this.списокДеталейToolStripMenuItem.Click += new System.EventHandler(this.списокИзделийToolStripMenuItem_Click);
            // 
            // изделияПоКомпонентамToolStripMenuItem
            // 
            this.изделияПоКомпонентамToolStripMenuItem.Name = "изделияПоКомпонентамToolStripMenuItem";
            this.изделияПоКомпонентамToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.изделияПоКомпонентамToolStripMenuItem.Text = "Компоненты по изделия";
            this.изделияПоКомпонентамToolStripMenuItem.Click += new System.EventHandler(this.компонентыПоИзделиямToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 31);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(866, 419);
            this.dataGridView.TabIndex = 1;
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(906, 48);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(211, 29);
            this.btnCreateOrder.TabIndex = 2;
            this.btnCreateOrder.Text = "Создать заказ";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // btnTakeOrderInWork
            // 
            this.btnTakeOrderInWork.Location = new System.Drawing.Point(906, 123);
            this.btnTakeOrderInWork.Name = "btnTakeOrderInWork";
            this.btnTakeOrderInWork.Size = new System.Drawing.Size(211, 29);
            this.btnTakeOrderInWork.TabIndex = 3;
            this.btnTakeOrderInWork.Text = "Отдать на выполнение";
            this.btnTakeOrderInWork.UseVisualStyleBackColor = true;
            this.btnTakeOrderInWork.Click += new System.EventHandler(this.btnTakeOrderInWork_Click);
            // 
            // btnOrderReady
            // 
            this.btnOrderReady.Location = new System.Drawing.Point(906, 190);
            this.btnOrderReady.Name = "btnOrderReady";
            this.btnOrderReady.Size = new System.Drawing.Size(211, 29);
            this.btnOrderReady.TabIndex = 4;
            this.btnOrderReady.Text = "Заказ готов";
            this.btnOrderReady.UseVisualStyleBackColor = true;
            this.btnOrderReady.Click += new System.EventHandler(this.btnOrderReady_Click);
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.Location = new System.Drawing.Point(906, 341);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(211, 29);
            this.btnRefreshList.TabIndex = 5;
            this.btnRefreshList.Text = "Обновить список";
            this.btnRefreshList.UseVisualStyleBackColor = true;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // btnIssuedOrder
            // 
            this.btnIssuedOrder.Location = new System.Drawing.Point(906, 259);
            this.btnIssuedOrder.Name = "btnIssuedOrder";
            this.btnIssuedOrder.Size = new System.Drawing.Size(211, 29);
            this.btnIssuedOrder.TabIndex = 6;
            this.btnIssuedOrder.Text = "Заказ выдан";
            this.btnIssuedOrder.UseVisualStyleBackColor = true;
            this.btnIssuedOrder.Click += new System.EventHandler(this.btnIssuedOrder_Click);
            // 
            // складыToolStripMenuItem
            // 
            this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            this.складыToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.складыToolStripMenuItem.Text = "Склады";
            this.складыToolStripMenuItem.Click += new System.EventHandler(this.складыToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // списокСкладовToolStripMenuItem
            // 
            this.списокСкладовToolStripMenuItem.Name = "списокСкладовToolStripMenuItem";
            this.списокСкладовToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.списокСкладовToolStripMenuItem.Text = "Список складов";
            this.списокСкладовToolStripMenuItem.Click += new System.EventHandler(this.списокСкладовToolStripMenuItem_Click);
            // 
            // складыПоКомпонентамToolStripMenuItem
            // 
            this.складыПоКомпонентамToolStripMenuItem.Name = "складыПоКомпонентамToolStripMenuItem";
            this.складыПоКомпонентамToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.складыПоКомпонентамToolStripMenuItem.Text = "Склады по компонентам";
            this.складыПоКомпонентамToolStripMenuItem.Click += new System.EventHandler(this.складыПоКомпонентамToolStripMenuItem_Click);
            // 
            // списокЗаказовПоДатеToolStripMenuItem
            // 
            this.списокЗаказовПоДатеToolStripMenuItem.Name = "списокЗаказовПоДатеToolStripMenuItem";
            this.списокЗаказовПоДатеToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.списокЗаказовПоДатеToolStripMenuItem.Text = "Список заказов по дате";
            this.списокЗаказовПоДатеToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовПоДатеToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 450);
            this.Controls.Add(this.btnIssuedOrder);
            this.Controls.Add(this.btnRefreshList);
            this.Controls.Add(this.btnOrderReady);
            this.Controls.Add(this.btnTakeOrderInWork);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Установка ПО";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button btnTakeOrderInWork;
        private System.Windows.Forms.Button btnOrderReady;
        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.Button btnIssuedOrder;
        private System.Windows.Forms.ToolStripMenuItem пополнениеСкладаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокДеталейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изделияПоКомпонентамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокСкладовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складыПоКомпонентамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовПоДатеToolStripMenuItem;
    }
}