using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;
using WinPublishHelpTool.Dal;
using WinPublishHelpTool.Models;
using WinPublishHelpTool.Tools;

namespace WinPublishHelpTool
{
    public partial class FormMain
    {
        private bool isConnection = false;
        private void button7_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDbSourceName.Text))
            {
                MessageTip("请输入数据源名称");
                return;
            }
            if (string.IsNullOrEmpty(rtxDbConnStr.Text))
            {
                MessageTip("请输入数据链接字符串");
                return;
            }

            string errorMsg = string.Empty;
            if (SqlHelper.IsConnection(out errorMsg))
            {
                MessageTip(errorMsg);
                rtxDbConnStr.Enabled = false;
                txtDbSourceName.Enabled = false;

                isConnection = true;
                var dbList = new BackupDbDal().GetAllDbName();
                cbBackupDb.DataSource = dbList;
                cbBackupDb.ValueMember = "Id";
                cbBackupDb.DisplayMember = "Name";

                cbRestoreDb.DataSource = dbList;
                cbRestoreDb.ValueMember = "Id";
                cbRestoreDb.DisplayMember = "Name";
                

            }
            else
            {
                MessageError("数据库链接失败,原因：" + errorMsg);
            }

        }

        private void rtxDbConnStr_TextChanged(object sender, EventArgs e)
        {
            SqlHelper.SetConnection(rtxDbConnStr.Text.Trim());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.Text == "保存该链接")
            {
                string errorMsg = String.Empty;
                if (!ValidDbConfig(out errorMsg))
                {
                    MessageTip(errorMsg);
                    return;
                }
                var config = new DbConfigInfo()
                {
                    DbSourceName = txtDbSourceName.Text.Trim(),
                    DbConnectionString = rtxDbConnStr.Text.Trim(),
                    DbSourceAddress = txtDbAddress.Text.Trim(),
                    DbSourceServiceName = txtDbServiceUserName.Text.Trim(),
                    DbSourceServicePwd = txtDbServicePwd.Text.Trim()
                };
                _dbConfigInfoDal.InsertConfig(config);
                LoadDbConfigInfo();
                MessageTip("保存成功");
                button11.Text = "重置";
            }
            else if (button11.Text == "重置")
            {
                isConnection = false;
                button11.Text = "保存该链接";
                txtDbSourceName.Text = string.Empty;
                txtDbSourceName.Enabled = true;
                rtxDbConnStr.Text = string.Empty;
                rtxDbConnStr.Enabled = true;

                txtDbServiceUserName.Text = string.Empty;
                txtDbServiceUserName.Enabled = true;
                txtDbServicePwd.Text = string.Empty;
                txtDbServicePwd.Enabled = true;
            }
        }

        private bool ValidDbConfig(out string msg)
        {
            if (string.IsNullOrEmpty(txtDbSourceName.Text))
            {
                msg = "数据库链接源名称不能为空";
                return false;
            }
            if (string.IsNullOrEmpty(rtxDbConnStr.Text))
            {
                msg = "数据库链接字符串不能为空";
                return false;
            }
            if (!isConnection)
            {
                msg = "请先测试数据库链接是否正常";
                return false;
            }

            if (_dbConfigInfoDal.ExsitDbConfigInfo(txtDbSourceName.Text))
            {
                msg = "已经存在名称为" + txtDbSourceName.Text + "的配置";
                return false;
            }
            msg = "OK";
            return true;

        }

        private void LoadDbConfigInfo()
        {
            var configs = _dbConfigInfoDal.GetAllConfigInfos();
            tsmiChiceDbSource.DropDownItems.Clear();
            foreach (var projectInfo in configs)
            {
                tsmiChiceDbSource.DropDownItems.Add(new ToolStripMenuItem(projectInfo.DbSourceName, ReadImageFromRes("WinPublishHelpTool.images.choice.png"), menuDbItem_OnClick));

            }
        }

        private void menuDbItem_OnClick(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            var dbConfigInfo = _dbConfigInfoDal.GetDbConfigInfo(menuItem.Text);
            isConnection = false;
            button11.Text = "重置";
            txtDbSourceName.Text = dbConfigInfo.DbSourceName;
            txtDbSourceName.Enabled = false;
            rtxDbConnStr.Text = dbConfigInfo.DbConnectionString;
            rtxDbConnStr.Enabled = false;
            cbBackupDb.DataSource = null;
            txtDbAddress.Text = dbConfigInfo.DbSourceAddress;
            
            txtDbServiceUserName.Text = dbConfigInfo.DbSourceServiceName;
            txtDbServicePwd.Text = dbConfigInfo.DbSourceServicePwd;
                     
            cbRestoreDb.DataSource = null;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!isConnection)
            {
                MessageTip("请选确认数据库链接状态");
                return;
            }
            if (string.IsNullOrEmpty(cbBackupDb.Text))
            {
                MessageTip("请选择您要备份的数据库");
                return;
            }
            var dialog = new FolderBrowserDialog();
            dialog.Description = "请选择备份的数据包保存位置";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageTip("文件夹路径不能为空");
                    return;
                }

                txtDbBackupDir.Text = Path.Combine(dialog.SelectedPath, String.Format("{0}{1}.bak", cbBackupDb.Text, DateTime.Now.ToString("yyyyMMddhhMMss")));

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!isConnection)
            {
                MessageTip("请选确认数据库链接状态");
                return;
            }
            if (string.IsNullOrEmpty(cbBackupDb.Text))
            {
                MessageTip("请选择您要备份的数据库");
                return;
            }

            if (string.IsNullOrEmpty(txtDbBackupDir.Text))
            {
                MessageTip("请选择您要备份的数据库位置");
                return;
            }

            RunBackGroudWork((o, e1) =>
            {
                var bk = o as BackgroundWorker;
                bk.ReportProgress(5, "开始备份数据库,请稍等...");
                bk.ReportProgress(15, "正在链接数据库服务器,请稍等...");

                var dbConfigInfo = _dbConfigInfoDal.GetDbConfigInfo(txtDbSourceName.Text.Trim());

                if (dbConfigInfo == null)
                {
                    MessageError("请先保存该配置");
                    return;
                }

                var backupDal = new BackupDbDal();

                try
                {
                    string linkErrMsg = String.Empty;
                    if (!backupDal.LinkDbService(dbConfigInfo.DbSourceAddress, dbConfigInfo.DbSourceServiceName,
                        dbConfigInfo.DbSourceServicePwd, out linkErrMsg))
                    {
                        bk.ReportProgress(100, "数据服务器当前无权执行远程备份，请与DBA联系...");
                        MessageError(linkErrMsg);
                        return;
                    }
                    bk.ReportProgress(30, "数据库服务器链接成功");
                    bk.ReportProgress(35, "正在备份数据库,请稍等...");
                    backupDal.BackupDbInfo(txtDbBackupDir.Text, cbBackupDb.Text);
                    bk.ReportProgress(60, "数据库备份成功");
                    bk.ReportProgress(65, "正在从服务的拷贝数据库文件到本地,请稍等...");
                    File.Copy(string.Format("Z:\\{0}", Path.GetFileName(txtDbBackupDir.Text)), txtDbBackupDir.Text);
                    bk.ReportProgress(75, "数据库文件拷贝成功");
                    bk.ReportProgress(85, "正在从服务端清理备份数据,请稍等...");

                    File.Delete(string.Format("Z:\\{0}", Path.GetFileName(txtDbBackupDir.Text)));

                    bk.ReportProgress(90, "服务器备份数据清理成功");

                    bk.ReportProgress(91, "正在删除服务器链接,请稍等...");
                    backupDal.RomoveLink();
                    bk.ReportProgress(95, "服务器链接删除成功");

                    bk.ReportProgress(100, "数据库备份成功");
                }
                catch (Exception ex)
                {
                    MessageError(ex.Message);

                }
                finally
                {
                    try
                    {
                        backupDal.RomoveLink();
                    }
                    catch (Exception exception)
                    {

                    }
                }
            });
        }

        private void cbBackupDb_TextChanged(object sender, EventArgs e)
        {
            if (!isConnection)
            {
                MessageTip("请先确认数据库链接是否正确");
                return;
            }
            if (string.IsNullOrEmpty(txtDbBackupDir.Text))
            {
                return;
            }

            txtDbBackupDir.Text = Path.Combine(Path.GetDirectoryName(txtDbBackupDir.Text), String.Format("{0}{1}.bak", cbBackupDb.Text, DateTime.Now.ToString("yyyyMMddhhMMss")));
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!isConnection)
            {
                MessageTip("请选确认数据库链接状态");
                return;
            }
     
            var dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Filter = "数据库备份文件(*.bak)|*.bak";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(dialog.FileName))
                {
                    MessageTip("文件夹路径不能为空");
                    return;
                }

                txtRestoreFile.Text = dialog.FileName;
                

            }
            if (string.IsNullOrEmpty(cbBackupDb.Text))
            {
                MessageTip("请输入您要还原的数据库名称");
                return;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            if (!isConnection)
            {
                MessageTip("请选确认数据库链接状态");
                return;
            }

            if (string.IsNullOrEmpty(txtRestoreFile.Text))
            {
                MessageTip("请确认您要还原的数据库备份文件");
                return;
            }

            RunBackGroudWork((o, e1) =>
            {
                var bk = o as BackgroundWorker;
                bk.ReportProgress(5, "开始还原数据库,请稍等...");
                bk.ReportProgress(15, "正在链接数据库服务器,请稍等...");

                var dbConfigInfo = _dbConfigInfoDal.GetDbConfigInfo(txtDbSourceName.Text.Trim());

                if (dbConfigInfo == null)
                {
                    if (string.IsNullOrEmpty(cbBackupDb.Text))
                    {
                        MessageTip("请选择您要备份的数据库");
                        return;
                    }
                    return;
                }

                var backupDal = new BackupDbDal();

                try
                {
                    string linkErrMsg = String.Empty;
                    if (!backupDal.LinkDbService(dbConfigInfo.DbSourceAddress, dbConfigInfo.DbSourceServiceName,
                        dbConfigInfo.DbSourceServicePwd, out linkErrMsg))
                    {
                        bk.ReportProgress(100, "数据服务器当前无权执行远程备份，请与DBA联系...");
                        MessageError(linkErrMsg);
                        return;
                    }
                    bk.ReportProgress(30, "数据库服务器链接成功");
 
                    bk.ReportProgress(65, "正在从本地的拷贝数据库文件到服务器,请稍等...");

                    File.Copy(txtRestoreFile.Text, string.Format("Z:\\{0}", Path.GetFileName(txtRestoreFile.Text)));
                    bk.ReportProgress(75, "数据库文件拷贝成功");

                    bk.ReportProgress(80, "正在还原数据库,请稍等...");

                    backupDal.RestoreDb(cbRestoreDb.Text,string.Format("Z:\\{0}", Path.GetFileName(txtRestoreFile.Text)));
                    
                    bk.ReportProgress(89, "数据库还原成功");

                    bk.ReportProgress(90, "正在从服务端清理备份数据,请稍等...");

                    File.Delete(string.Format("Z:\\{0}", Path.GetFileName(txtRestoreFile.Text)));

                    bk.ReportProgress(90, "服务器备份数据清理成功");

                    bk.ReportProgress(91, "正在删除服务器链接,请稍等...");
                    backupDal.RomoveLink();
                    bk.ReportProgress(95, "服务器链接删除成功");

                    bk.ReportProgress(100, "还原成功");
                }
                catch (Exception ex)
                {
                    MessageError(ex.Message);

                }
                finally
                {
                    try
                    {
                        if (File.Exists(string.Format("Z:\\{0}", Path.GetFileName(txtRestoreFile.Text))))
                        {
                            File.Delete(string.Format("Z:\\{0}", Path.GetFileName(txtRestoreFile.Text)));
                        }                     
                        backupDal.RomoveLink();

                    }
                    catch (Exception exception)
                    {

                    }
                }
            });
        }

    }
}