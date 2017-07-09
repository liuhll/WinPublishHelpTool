using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace WinPublishHelpTool
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbDestVersion = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ckIsNew = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveProjectConfig = new System.Windows.Forms.Button();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPackageDestDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPackageSourceDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuPublishTool = new System.Windows.Forms.MenuStrip();
            this.tsmiChoiceProject = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearCache = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewPublish = new System.Windows.Forms.DataGridView();
            this.projectNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackUpDirectory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.publishDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOption = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bindingSourcePublish = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.rtxDbConnStr = new System.Windows.Forms.RichTextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.txtDbSourceName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.选择数据源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清理缓存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuPublishTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPublish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePublish)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(769, 463);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(761, 437);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "项目发布管理";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lbDestVersion);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lbVersion);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.ckIsNew);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSaveProjectConfig);
            this.panel1.Controls.Add(this.txtProjectName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtPackageDestDir);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPackageSourceDir);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.menuPublishTool);
            this.panel1.Controls.Add(this.dataGridViewPublish);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 431);
            this.panel1.TabIndex = 2;
            // 
            // lbDestVersion
            // 
            this.lbDestVersion.AutoSize = true;
            this.lbDestVersion.Location = new System.Drawing.Point(686, 116);
            this.lbDestVersion.Name = "lbDestVersion";
            this.lbDestVersion.Size = new System.Drawing.Size(59, 12);
            this.lbDestVersion.TabIndex = 25;
            this.lbDestVersion.Text = "lvVersion";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(603, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "当前版本号：";
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(614, 79);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(59, 12);
            this.lbVersion.TabIndex = 23;
            this.lbVersion.Text = "lvVersion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(514, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "程序包版本号:";
            // 
            // ckIsNew
            // 
            this.ckIsNew.AutoSize = true;
            this.ckIsNew.Location = new System.Drawing.Point(513, 115);
            this.ckIsNew.Name = "ckIsNew";
            this.ckIsNew.Size = new System.Drawing.Size(84, 16);
            this.ckIsNew.TabIndex = 21;
            this.ckIsNew.Text = "是否新发布";
            this.ckIsNew.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(497, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(497, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(451, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "*";
            // 
            // btnSaveProjectConfig
            // 
            this.btnSaveProjectConfig.Location = new System.Drawing.Point(40, 185);
            this.btnSaveProjectConfig.Name = "btnSaveProjectConfig";
            this.btnSaveProjectConfig.Size = new System.Drawing.Size(106, 39);
            this.btnSaveProjectConfig.TabIndex = 17;
            this.btnSaveProjectConfig.Text = "保存该项目配置";
            this.btnSaveProjectConfig.UseVisualStyleBackColor = true;
            this.btnSaveProjectConfig.Click += new System.EventHandler(this.button7_Click);
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(114, 34);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(331, 21);
            this.txtProjectName.TabIndex = 16;
            this.txtProjectName.TextChanged += new System.EventHandler(this.txtProjectName_TextChange);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "项目名称";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(442, 109);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(49, 24);
            this.button4.TabIndex = 14;
            this.button4.Text = "选择..";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(442, 69);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(49, 24);
            this.button3.TabIndex = 13;
            this.button3.Text = "选择..";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(442, 185);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(110, 39);
            this.button6.TabIndex = 11;
            this.button6.Text = "还原为最近版本";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(585, 185);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 39);
            this.button5.TabIndex = 10;
            this.button5.Text = "重置";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(327, 185);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 39);
            this.button2.TabIndex = 7;
            this.button2.Text = "备份";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(179, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "发布";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPackageDestDir
            // 
            this.txtPackageDestDir.Enabled = false;
            this.txtPackageDestDir.Location = new System.Drawing.Point(114, 112);
            this.txtPackageDestDir.Name = "txtPackageDestDir";
            this.txtPackageDestDir.Size = new System.Drawing.Size(331, 21);
            this.txtPackageDestDir.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "发布位置";
            // 
            // txtPackageSourceDir
            // 
            this.txtPackageSourceDir.Enabled = false;
            this.txtPackageSourceDir.Location = new System.Drawing.Point(114, 72);
            this.txtPackageSourceDir.Name = "txtPackageSourceDir";
            this.txtPackageSourceDir.Size = new System.Drawing.Size(331, 21);
            this.txtPackageSourceDir.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "包位置";
            // 
            // menuPublishTool
            // 
            this.menuPublishTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiChoiceProject,
            this.tsmiClearCache});
            this.menuPublishTool.Location = new System.Drawing.Point(0, 0);
            this.menuPublishTool.Name = "menuPublishTool";
            this.menuPublishTool.Size = new System.Drawing.Size(755, 25);
            this.menuPublishTool.TabIndex = 3;
            this.menuPublishTool.Text = "menuStrip1";
            // 
            // tsmiChoiceProject
            // 
            this.tsmiChoiceProject.Name = "tsmiChoiceProject";
            this.tsmiChoiceProject.Size = new System.Drawing.Size(68, 21);
            this.tsmiChoiceProject.Text = "选择项目";
            // 
            // tsmiClearCache
            // 
            this.tsmiClearCache.Name = "tsmiClearCache";
            this.tsmiClearCache.Size = new System.Drawing.Size(68, 21);
            this.tsmiClearCache.Text = "清除缓存";
            this.tsmiClearCache.Click += new System.EventHandler(this.tsmiClearCache_Click);
            // 
            // dataGridViewPublish
            // 
            this.dataGridViewPublish.AllowUserToAddRows = false;
            this.dataGridViewPublish.AllowUserToDeleteRows = false;
            this.dataGridViewPublish.AutoGenerateColumns = false;
            this.dataGridViewPublish.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPublish.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.projectNameDataGridViewTextBoxColumn,
            this.BackUpDirectory,
            this.optionTypeDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn,
            this.publishDateDataGridViewTextBoxColumn,
            this.colOption});
            this.dataGridViewPublish.DataSource = this.bindingSourcePublish;
            this.dataGridViewPublish.Location = new System.Drawing.Point(0, 254);
            this.dataGridViewPublish.MultiSelect = false;
            this.dataGridViewPublish.Name = "dataGridViewPublish";
            this.dataGridViewPublish.ReadOnly = true;
            this.dataGridViewPublish.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewPublish.RowTemplate.Height = 23;
            this.dataGridViewPublish.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPublish.Size = new System.Drawing.Size(750, 184);
            this.dataGridViewPublish.TabIndex = 12;
            this.dataGridViewPublish.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewPublish_CellMouseClick);
            // 
            // projectNameDataGridViewTextBoxColumn
            // 
            this.projectNameDataGridViewTextBoxColumn.DataPropertyName = "ProjectName";
            this.projectNameDataGridViewTextBoxColumn.FillWeight = 42.61511F;
            this.projectNameDataGridViewTextBoxColumn.HeaderText = "项目名称";
            this.projectNameDataGridViewTextBoxColumn.Name = "projectNameDataGridViewTextBoxColumn";
            this.projectNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BackUpDirectory
            // 
            this.BackUpDirectory.DataPropertyName = "BackUpDirectory";
            this.BackUpDirectory.HeaderText = "BackUpDirectory";
            this.BackUpDirectory.Name = "BackUpDirectory";
            this.BackUpDirectory.ReadOnly = true;
            this.BackUpDirectory.Visible = false;
            // 
            // optionTypeDataGridViewTextBoxColumn
            // 
            this.optionTypeDataGridViewTextBoxColumn.DataPropertyName = "OptionType";
            this.optionTypeDataGridViewTextBoxColumn.FillWeight = 42.61511F;
            this.optionTypeDataGridViewTextBoxColumn.HeaderText = "操作类型";
            this.optionTypeDataGridViewTextBoxColumn.Name = "optionTypeDataGridViewTextBoxColumn";
            this.optionTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // versionDataGridViewTextBoxColumn
            // 
            this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
            this.versionDataGridViewTextBoxColumn.FillWeight = 42.61511F;
            this.versionDataGridViewTextBoxColumn.HeaderText = "版本号";
            this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
            this.versionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // publishDateDataGridViewTextBoxColumn
            // 
            this.publishDateDataGridViewTextBoxColumn.DataPropertyName = "PublishDate";
            this.publishDateDataGridViewTextBoxColumn.FillWeight = 42.61511F;
            this.publishDateDataGridViewTextBoxColumn.HeaderText = "发布/备份日期";
            this.publishDateDataGridViewTextBoxColumn.Name = "publishDateDataGridViewTextBoxColumn";
            this.publishDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // colOption
            // 
            this.colOption.FillWeight = 20F;
            this.colOption.HeaderText = "操作";
            this.colOption.Name = "colOption";
            this.colOption.ReadOnly = true;
            this.colOption.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colOption.Text = "还原";
            this.colOption.UseColumnTextForButtonValue = true;
            // 
            // bindingSourcePublish
            // 
            this.bindingSourcePublish.AllowNew = false;
            this.bindingSourcePublish.DataSource = typeof(WinPublishHelpTool.Models.PublishInfo);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(761, 437);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "数据库备份";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.rtxDbConnStr);
            this.panel2.Controls.Add(this.button11);
            this.panel2.Controls.Add(this.txtDbSourceName);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(755, 431);
            this.panel2.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(637, 38);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(11, 12);
            this.label18.TabIndex = 22;
            this.label18.Text = "*";
            // 
            // rtxDbConnStr
            // 
            this.rtxDbConnStr.Location = new System.Drawing.Point(129, 74);
            this.rtxDbConnStr.Name = "rtxDbConnStr";
            this.rtxDbConnStr.Size = new System.Drawing.Size(502, 54);
            this.rtxDbConnStr.TabIndex = 21;
            this.rtxDbConnStr.Text = "";
            this.rtxDbConnStr.TextChanged += new System.EventHandler(this.rtxDbConnStr_TextChanged);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(664, 99);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 32);
            this.button11.TabIndex = 20;
            this.button11.Text = "保存该链接";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // txtDbSourceName
            // 
            this.txtDbSourceName.Location = new System.Drawing.Point(129, 35);
            this.txtDbSourceName.Name = "txtDbSourceName";
            this.txtDbSourceName.Size = new System.Drawing.Size(502, 21);
            this.txtDbSourceName.TabIndex = 19;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(46, 38);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 12);
            this.label17.TabIndex = 18;
            this.label17.Text = "数据源名称：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button12);
            this.groupBox2.Controls.Add(this.button10);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Location = new System.Drawing.Point(13, 271);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(726, 119);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据库还原";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(364, 28);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(52, 23);
            this.button12.TabIndex = 18;
            this.button12.Text = "选择..";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(508, 68);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(97, 32);
            this.button10.TabIndex = 18;
            this.button10.Text = "还原";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(116, 68);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(248, 21);
            this.textBox4.TabIndex = 17;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(116, 29);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(248, 21);
            this.textBox3.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 12);
            this.label14.TabIndex = 14;
            this.label14.Text = "数据库备份位置：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(426, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(215, 12);
            this.label15.TabIndex = 13;
            this.label15.Text = "*输入连接字符串后请先点击\'测试连接\'";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 12);
            this.label16.TabIndex = 11;
            this.label16.Text = "数据库名称：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(13, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 119);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库备份";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(508, 63);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(97, 32);
            this.button9.TabIndex = 17;
            this.button9.Text = "备份";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(372, 68);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(52, 23);
            this.button8.TabIndex = 16;
            this.button8.Text = "选择..";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(124, 70);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(248, 21);
            this.textBox2.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 12);
            this.label13.TabIndex = 14;
            this.label13.Text = "数据库备份位置：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(390, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(215, 12);
            this.label12.TabIndex = 13;
            this.label12.Text = "*输入连接字符串后请先点击\'测试连接\'";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(124, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(248, 20);
            this.comboBox1.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "选择备份数据库：";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(664, 68);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 4;
            this.button7.Text = "测试连接";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(637, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "数据库连接字符串：";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择数据源ToolStripMenuItem,
            this.清理缓存ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(755, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 选择数据源ToolStripMenuItem
            // 
            this.选择数据源ToolStripMenuItem.Name = "选择数据源ToolStripMenuItem";
            this.选择数据源ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.选择数据源ToolStripMenuItem.Text = "选择数据源";
            // 
            // 清理缓存ToolStripMenuItem
            // 
            this.清理缓存ToolStripMenuItem.Name = "清理缓存ToolStripMenuItem";
            this.清理缓存ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.清理缓存ToolStripMenuItem.Text = "清理缓存";
            // 
            // FormMain
            // 
            this.ClientSize = new System.Drawing.Size(769, 463);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Main";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuPublishTool.ResumeLayout(false);
            this.menuPublishTool.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPublish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePublish)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Panel panel1;
        private Button btnSaveProjectConfig;
        private TextBox txtProjectName;
        private Label label3;
        private Button button4;
        private Button button3;
        private DataGridView dataGridViewPublish;
        private Button button6;
        private Button button5;
        private Button button2;
        private Button button1;
        private TextBox txtPackageDestDir;
        private Label label2;
        private TextBox txtPackageSourceDir;
        private Label label1;
        private MenuStrip menuPublishTool;
        private ToolStripMenuItem tsmiChoiceProject;
        private ToolStripMenuItem tsmiClearCache;
        private TabPage tabPage2;
        private Label label4;
        private Label label6;
        private Label label5;
        private CheckBox ckIsNew;
        private Label lbVersion;
        private Label label7;
        private BindingSource bindingSourcePublish;
        private Label lbDestVersion;
        private Label label8;
        private DataGridViewTextBoxColumn projectNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn BackUpDirectory;
        private DataGridViewTextBoxColumn optionTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn publishDateDataGridViewTextBoxColumn;
        private DataGridViewButtonColumn colOption;
        private Panel panel2;
        private Button button7;
        private Label label10;
        private Label label9;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 选择数据源ToolStripMenuItem;
        private ToolStripMenuItem 清理缓存ToolStripMenuItem;
        private GroupBox groupBox2;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label14;
        private Label label15;
        private Label label16;
        private GroupBox groupBox1;
        private Button button8;
        private TextBox textBox2;
        private Label label13;
        private Label label12;
        private ComboBox comboBox1;
        private Label label11;
        private Button button9;
        private TextBox txtDbSourceName;
        private Label label17;
        private Button button10;
        private Button button11;
        private Button button12;
        private RichTextBox rtxDbConnStr;
        private Label label18;
    }
}

