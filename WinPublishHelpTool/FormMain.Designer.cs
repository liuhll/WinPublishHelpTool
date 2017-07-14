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
            this.txtFtpPwd = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtFtpUserName = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtFtpService = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button14 = new System.Windows.Forms.Button();
            this.btnChioceZip = new System.Windows.Forms.Button();
            this.lbDestVersion = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveProjectConfig = new System.Windows.Forms.Button();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChoiceDestDir = new System.Windows.Forms.Button();
            this.btnChioceSourceDir = new System.Windows.Forms.Button();
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
            this.bindingSourcePublish = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtDbServicePwd = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtDbServiceUserName = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDbAddress = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.rtxDbConnStr = new System.Windows.Forms.RichTextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.txtDbSourceName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbRestoreDb = new System.Windows.Forms.ComboBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.txtRestoreFile = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.txtDbBackupDir = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbBackupDb = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiChiceDbSource = new System.Windows.Forms.ToolStripMenuItem();
            this.清理缓存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackUpDirectory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackUpTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.publishDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOption = new System.Windows.Forms.DataGridViewButtonColumn();
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
            this.panel1.Controls.Add(this.txtFtpPwd);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.txtFtpUserName);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.txtFtpService);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.button14);
            this.panel1.Controls.Add(this.btnChioceZip);
            this.panel1.Controls.Add(this.lbDestVersion);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lbVersion);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSaveProjectConfig);
            this.panel1.Controls.Add(this.txtProjectName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnChoiceDestDir);
            this.panel1.Controls.Add(this.btnChioceSourceDir);
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
            // txtFtpPwd
            // 
            this.txtFtpPwd.Location = new System.Drawing.Point(370, 179);
            this.txtFtpPwd.Name = "txtFtpPwd";
            this.txtFtpPwd.Size = new System.Drawing.Size(191, 21);
            this.txtFtpPwd.TabIndex = 35;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(310, 183);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(47, 12);
            this.label28.TabIndex = 34;
            this.label28.Text = "Ftp密码";
            // 
            // txtFtpUserName
            // 
            this.txtFtpUserName.Location = new System.Drawing.Point(114, 179);
            this.txtFtpUserName.Name = "txtFtpUserName";
            this.txtFtpUserName.Size = new System.Drawing.Size(190, 21);
            this.txtFtpUserName.TabIndex = 33;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(36, 185);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(47, 12);
            this.label27.TabIndex = 32;
            this.label27.Text = "Ftp账号";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(567, 185);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(185, 12);
            this.label26.TabIndex = 31;
            this.label26.Text = "仅支持发布为本地或ftp服务器...";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(401, 151);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(353, 12);
            this.label25.TabIndex = 30;
            this.label25.Text = "格式为  ftp://ip:port/path || ftp://ip/path 默认端口号为21";
            // 
            // txtFtpService
            // 
            this.txtFtpService.Location = new System.Drawing.Point(114, 148);
            this.txtFtpService.Name = "txtFtpService";
            this.txtFtpService.Size = new System.Drawing.Size(270, 21);
            this.txtFtpService.TabIndex = 29;
            this.txtFtpService.TextChanged += new System.EventHandler(this.txtFtpService_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "FTP服务器";
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(286, 209);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(100, 39);
            this.button14.TabIndex = 27;
            this.button14.Text = "差异备份";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // btnChioceZip
            // 
            this.btnChioceZip.Location = new System.Drawing.Point(428, 72);
            this.btnChioceZip.Name = "btnChioceZip";
            this.btnChioceZip.Size = new System.Drawing.Size(64, 24);
            this.btnChioceZip.TabIndex = 26;
            this.btnChioceZip.Text = "压缩包..";
            this.btnChioceZip.UseVisualStyleBackColor = true;
            this.btnChioceZip.Click += new System.EventHandler(this.btnChioceZip_Click);
            // 
            // lbDestVersion
            // 
            this.lbDestVersion.AutoSize = true;
            this.lbDestVersion.Location = new System.Drawing.Point(614, 116);
            this.lbDestVersion.Name = "lbDestVersion";
            this.lbDestVersion.Size = new System.Drawing.Size(59, 12);
            this.lbDestVersion.TabIndex = 25;
            this.lbDestVersion.Text = "lvVersion";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(525, 116);
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
            this.label7.Location = new System.Drawing.Point(525, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "程序包版本号:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(497, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(390, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "*";
            // 
            // btnSaveProjectConfig
            // 
            this.btnSaveProjectConfig.Location = new System.Drawing.Point(38, 209);
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
            this.txtProjectName.Size = new System.Drawing.Size(270, 21);
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
            // btnChoiceDestDir
            // 
            this.btnChoiceDestDir.Location = new System.Drawing.Point(378, 110);
            this.btnChoiceDestDir.Name = "btnChoiceDestDir";
            this.btnChoiceDestDir.Size = new System.Drawing.Size(49, 24);
            this.btnChoiceDestDir.TabIndex = 14;
            this.btnChoiceDestDir.Text = "选择..";
            this.btnChoiceDestDir.UseVisualStyleBackColor = true;
            this.btnChoiceDestDir.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnChioceSourceDir
            // 
            this.btnChioceSourceDir.Location = new System.Drawing.Point(378, 72);
            this.btnChioceSourceDir.Name = "btnChioceSourceDir";
            this.btnChioceSourceDir.Size = new System.Drawing.Size(49, 24);
            this.btnChioceSourceDir.TabIndex = 13;
            this.btnChioceSourceDir.Text = "目录..";
            this.btnChioceSourceDir.UseVisualStyleBackColor = true;
            this.btnChioceSourceDir.Click += new System.EventHandler(this.button3_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(527, 209);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(110, 39);
            this.button6.TabIndex = 11;
            this.button6.Text = "还原为最近版本";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(662, 209);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 39);
            this.button5.TabIndex = 10;
            this.button5.Text = "重置";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(408, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 39);
            this.button2.TabIndex = 7;
            this.button2.Text = "备份";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(164, 209);
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
            this.txtPackageDestDir.Size = new System.Drawing.Size(270, 21);
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
            this.txtPackageSourceDir.Size = new System.Drawing.Size(270, 21);
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
            this.tsmiClearCache.Visible = false;
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
            this.Id,
            this.BackUpDirectory,
            this.optionTypeDataGridViewTextBoxColumn,
            this.BackUpTypeCol,
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
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.txtDbServicePwd);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.txtDbServiceUserName);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.txtDbAddress);
            this.panel2.Controls.Add(this.label19);
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
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(707, 74);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(11, 12);
            this.label24.TabIndex = 31;
            this.label24.Text = "*";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(707, 32);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(11, 12);
            this.label23.TabIndex = 30;
            this.label23.Text = "*";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(312, 74);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(11, 12);
            this.label22.TabIndex = 29;
            this.label22.Text = "*";
            // 
            // txtDbServicePwd
            // 
            this.txtDbServicePwd.Location = new System.Drawing.Point(497, 70);
            this.txtDbServicePwd.Name = "txtDbServicePwd";
            this.txtDbServicePwd.Size = new System.Drawing.Size(204, 21);
            this.txtDbServicePwd.TabIndex = 28;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(384, 74);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(107, 12);
            this.label21.TabIndex = 27;
            this.label21.Text = "数据库服务器密码:";
            // 
            // txtDbServiceUserName
            // 
            this.txtDbServiceUserName.Location = new System.Drawing.Point(137, 71);
            this.txtDbServiceUserName.Name = "txtDbServiceUserName";
            this.txtDbServiceUserName.Size = new System.Drawing.Size(169, 21);
            this.txtDbServiceUserName.TabIndex = 26;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 74);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(119, 12);
            this.label20.TabIndex = 25;
            this.label20.Text = "数据库服务器用户名:";
            // 
            // txtDbAddress
            // 
            this.txtDbAddress.Location = new System.Drawing.Point(137, 35);
            this.txtDbAddress.Name = "txtDbAddress";
            this.txtDbAddress.Size = new System.Drawing.Size(169, 21);
            this.txtDbAddress.TabIndex = 24;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(22, 38);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(101, 12);
            this.label19.TabIndex = 23;
            this.label19.Text = "数据库服务器Ip：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(312, 38);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(11, 12);
            this.label18.TabIndex = 22;
            this.label18.Text = "*";
            // 
            // rtxDbConnStr
            // 
            this.rtxDbConnStr.Location = new System.Drawing.Point(129, 109);
            this.rtxDbConnStr.Name = "rtxDbConnStr";
            this.rtxDbConnStr.Size = new System.Drawing.Size(502, 42);
            this.rtxDbConnStr.TabIndex = 21;
            this.rtxDbConnStr.Text = "";
            this.rtxDbConnStr.TextChanged += new System.EventHandler(this.rtxDbConnStr_TextChanged);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(664, 133);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 32);
            this.button11.TabIndex = 20;
            this.button11.Text = "保存该链接";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // txtDbSourceName
            // 
            this.txtDbSourceName.Location = new System.Drawing.Point(497, 29);
            this.txtDbSourceName.Name = "txtDbSourceName";
            this.txtDbSourceName.Size = new System.Drawing.Size(204, 21);
            this.txtDbSourceName.TabIndex = 19;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(406, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 12);
            this.label17.TabIndex = 18;
            this.label17.Text = "数据源名称：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbRestoreDb);
            this.groupBox2.Controls.Add(this.button12);
            this.groupBox2.Controls.Add(this.button10);
            this.groupBox2.Controls.Add(this.txtRestoreFile);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Location = new System.Drawing.Point(13, 295);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(726, 119);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据库还原";
            // 
            // cbRestoreDb
            // 
            this.cbRestoreDb.FormattingEnabled = true;
            this.cbRestoreDb.Location = new System.Drawing.Point(116, 65);
            this.cbRestoreDb.Name = "cbRestoreDb";
            this.cbRestoreDb.Size = new System.Drawing.Size(381, 20);
            this.cbRestoreDb.TabIndex = 19;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(455, 29);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(52, 23);
            this.button12.TabIndex = 18;
            this.button12.Text = "选择..";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(623, 63);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(97, 32);
            this.button10.TabIndex = 18;
            this.button10.Text = "还原";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // txtRestoreFile
            // 
            this.txtRestoreFile.Enabled = false;
            this.txtRestoreFile.Location = new System.Drawing.Point(116, 29);
            this.txtRestoreFile.Name = "txtRestoreFile";
            this.txtRestoreFile.Size = new System.Drawing.Size(342, 21);
            this.txtRestoreFile.TabIndex = 15;
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
            this.label15.Location = new System.Drawing.Point(511, 32);
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
            this.groupBox1.Controls.Add(this.txtDbBackupDir);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cbBackupDb);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(13, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 119);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库备份";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(603, 63);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(97, 32);
            this.button9.TabIndex = 17;
            this.button9.Text = "备份";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(503, 68);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(52, 23);
            this.button8.TabIndex = 16;
            this.button8.Text = "选择..";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // txtDbBackupDir
            // 
            this.txtDbBackupDir.Enabled = false;
            this.txtDbBackupDir.Location = new System.Drawing.Point(124, 70);
            this.txtDbBackupDir.Name = "txtDbBackupDir";
            this.txtDbBackupDir.Size = new System.Drawing.Size(383, 21);
            this.txtDbBackupDir.TabIndex = 15;
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
            this.label12.Location = new System.Drawing.Point(511, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(215, 12);
            this.label12.TabIndex = 13;
            this.label12.Text = "*输入连接字符串后请先点击\'测试连接\'";
            // 
            // cbBackupDb
            // 
            this.cbBackupDb.FormattingEnabled = true;
            this.cbBackupDb.Location = new System.Drawing.Point(124, 29);
            this.cbBackupDb.Name = "cbBackupDb";
            this.cbBackupDb.Size = new System.Drawing.Size(381, 20);
            this.cbBackupDb.TabIndex = 12;
            this.cbBackupDb.TextChanged += new System.EventHandler(this.cbBackupDb_TextChanged);
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
            this.button7.Location = new System.Drawing.Point(664, 104);
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
            this.label10.Location = new System.Drawing.Point(637, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "数据库连接字符串：";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiChiceDbSource,
            this.清理缓存ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(755, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiChiceDbSource
            // 
            this.tsmiChiceDbSource.Name = "tsmiChiceDbSource";
            this.tsmiChiceDbSource.Size = new System.Drawing.Size(80, 21);
            this.tsmiChiceDbSource.Text = "选择数据源";
            // 
            // 清理缓存ToolStripMenuItem
            // 
            this.清理缓存ToolStripMenuItem.Name = "清理缓存ToolStripMenuItem";
            this.清理缓存ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.清理缓存ToolStripMenuItem.Text = "清理缓存";
            // 
            // projectNameDataGridViewTextBoxColumn
            // 
            this.projectNameDataGridViewTextBoxColumn.DataPropertyName = "ProjectName";
            this.projectNameDataGridViewTextBoxColumn.FillWeight = 42.61511F;
            this.projectNameDataGridViewTextBoxColumn.HeaderText = "项目名称";
            this.projectNameDataGridViewTextBoxColumn.Name = "projectNameDataGridViewTextBoxColumn";
            this.projectNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
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
            // BackUpTypeCol
            // 
            this.BackUpTypeCol.DataPropertyName = "BackUpType";
            this.BackUpTypeCol.FillWeight = 40F;
            this.BackUpTypeCol.HeaderText = "备份类型";
            this.BackUpTypeCol.Name = "BackUpTypeCol";
            this.BackUpTypeCol.ReadOnly = true;
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
        private Button btnChoiceDestDir;
        private Button btnChioceSourceDir;
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
        private Label label5;
        private Label lbVersion;
        private Label label7;
        private BindingSource bindingSourcePublish;
        private Label lbDestVersion;
        private Label label8;
        private Panel panel2;
        private Button button7;
        private Label label10;
        private Label label9;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsmiChiceDbSource;
        private ToolStripMenuItem 清理缓存ToolStripMenuItem;
        private GroupBox groupBox2;
        private TextBox txtRestoreFile;
        private Label label14;
        private Label label15;
        private Label label16;
        private GroupBox groupBox1;
        private Button button8;
        private TextBox txtDbBackupDir;
        private Label label13;
        private Label label12;
        private ComboBox cbBackupDb;
        private Label label11;
        private Button button9;
        private TextBox txtDbSourceName;
        private Label label17;
        private Button button10;
        private Button button11;
        private Button button12;
        private RichTextBox rtxDbConnStr;
        private Label label18;
        private TextBox txtDbServicePwd;
        private Label label21;
        private TextBox txtDbServiceUserName;
        private Label label20;
        private TextBox txtDbAddress;
        private Label label19;
        private Label label24;
        private Label label23;
        private Label label22;
        private ComboBox cbRestoreDb;
        private Button btnChioceZip;
        private Button button14;
        private TextBox txtFtpService;
        private Label label6;
        private Label label25;
        private Label label26;
        private TextBox txtFtpPwd;
        private Label label28;
        private TextBox txtFtpUserName;
        private Label label27;
        private DataGridViewTextBoxColumn projectNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn BackUpDirectory;
        private DataGridViewTextBoxColumn optionTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn BackUpTypeCol;
        private DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn publishDateDataGridViewTextBoxColumn;
        private DataGridViewButtonColumn colOption;
    }
}

