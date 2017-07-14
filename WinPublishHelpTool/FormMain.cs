using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using DotNet.Utilities;
using WinPublishHelpTool.Commons;
using WinPublishHelpTool.Dal;
using WinPublishHelpTool.Models;
using WinPublishHelpTool.Tools;

namespace WinPublishHelpTool
{
    public partial class FormMain : Form
    {
        private ProjectInfoDal _projectInfoDal;
        private PublishInfoDal _publishInfoDal;
        private DbConfigInfoDal _dbConfigInfoDal;
        private bool _isNewPublish = false;
        private const string versionName = "ProjectVersion.xml";
        private bool _isFptPublish = false;


        public FormMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            _projectInfoDal = new ProjectInfoDal();
            _publishInfoDal = new PublishInfoDal();
            _dbConfigInfoDal = new DbConfigInfoDal();
            LoadProjectInfo();
            LoadDbConfigInfo();
            lbVersion.Text = "";
            lbDestVersion.Text = "";
        }

        private void LoadProjectInfo()
        {
            var projectInfos = _projectInfoDal.GetAllProjectInfos();
            tsmiChoiceProject.DropDownItems.Clear();
            foreach (var projectInfo in projectInfos)
            {
                tsmiChoiceProject.DropDownItems.Add(new ToolStripMenuItem(projectInfo.ProjectName, ReadImageFromRes("WinPublishHelpTool.images.choice.png"), menuItem_OnClick));

            }

        }

        private void menuItem_OnClick(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;
            BindProjectInfo(item.Text.Trim());
        }

        private void BindProjectInfo(string projectName, bool isNeedSetEnable = false)
        {
            var projectInfo = _projectInfoDal.GetProjectInfoByName(projectName);
            try
            {
                txtProjectName.Text = projectInfo.ProjectName;
                txtPackageSourceDir.Text = projectInfo.SourceDirectory;
                bool isZipPage = !string.IsNullOrEmpty(Path.GetFileName(txtPackageSourceDir.Text)) &&
                                 Path.GetExtension(txtPackageSourceDir.Text).ToLower() == ".zip";

                if (!isZipPage)
                {
                    if (!Directory.Exists(txtPackageSourceDir.Text))
                    {
                        txtPackageSourceDir.Text = "";
                        lbVersion.Text = "";
                        var destVersion = SysHelper.GetVersionName(Path.Combine(txtPackageDestDir.Text, versionName));

                        lbDestVersion.Text = destVersion;
                        if (!isNeedSetEnable)
                        {
                            MessageError("系统配置程序包不存在，请重新选择！");
                        }
                    }
                    else
                    {
                        var version = SysHelper.GetVersionName(Path.Combine(txtPackageSourceDir.Text, versionName));
                        lbVersion.Text = version;
                    }
                }
                txtPackageDestDir.Text = projectInfo.DestDirectory;
                txtFtpUserName.Text = projectInfo.FtpUserName;
                txtFtpService.Text = projectInfo.FtpServiceAddress;
                txtFtpPwd.Text = projectInfo.FtpPwd;
                _isFptPublish = projectInfo.IsFtp;

                if (!isNeedSetEnable)
                {
                    txtProjectName.Enabled = false;
                    btnSaveProjectConfig.Enabled = false;
                    txtFtpPwd.Enabled = false;
                    txtFtpService.Enabled = false;
                    txtFtpUserName.Enabled = false;
                }
                //if (!projectInfo.IsFtp)
                //{

                //    if (!isNeedSetEnable)
                //    {
                //        txtProjectName.Enabled = false;
                //        btnSaveProjectConfig.Enabled = false;                       
                //        txtFtpUserName.Enabled = false;                     
                //        txtFtpPwd.Enabled = false;                        
                //    }

                //}
                //else
                //{
                //    if (!isNeedSetEnable)
                //    {
                //        txtProjectName.Enabled = false;
                //        txtFtpPwd.Enabled = false;
                //        txtFtpService.Enabled = false;
                //        txtFtpUserName.Enabled = false;
                //    }

                //}

                BindGridView(projectInfo.Id);
            }
            catch (Exception ex)
            {
                MessageError("无效的配置,请确认您的程序包是否合法,合法的程序包必须包含版本配置信息");
                _projectInfoDal.Remove(projectInfo.Id);
                LoadProjectInfo();
                txtProjectName.Text = "";
                txtProjectName.Enabled = true;
                btnSaveProjectConfig.Enabled = true;
                txtPackageSourceDir.Text = "";
                txtPackageDestDir.Text = "";
                lbVersion.Text = "";
                lbDestVersion.Text = "";
                bindingSourcePublish.DataSource = null;
            }
        }

        private void SetVersionInfo()
        {
            var version = SysHelper.GetVersionName(Path.Combine(txtPackageSourceDir.Text, versionName));
            lbVersion.Text = version;

            var destVersion = SysHelper.GetVersionName(Path.Combine(txtPackageDestDir.Text, versionName));

            lbDestVersion.Text = destVersion;
        }

        private void BindGridView(string projectId)
        {
            var publishList = _publishInfoDal.GetPublishInfosByProjectId(projectId);

            if (publishList != null && publishList.Count > 0)
            {
                bindingSourcePublish.DataSource = new BindingList<PublishInfo>(publishList).OrderByDescending(p => p.PublishDate);
            }
            else
            {
                bindingSourcePublish.DataSource = null;
            }
        }

        [Obsolete]
        private DataGridViewComboBoxColumn CreateComboBoxWithEnums()
        {
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.DataSource = "还原";
            combo.DataPropertyName = null;
            combo.Name = "操作";
            return combo;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtProjectName.Text))
            {
                MessageTip("请先输入项目名称");
                return;
            }
            var dialog = new FolderBrowserDialog();
            dialog.Description = "请选择您要发布的项目所在文件夹";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageTip("文件夹路径不能为空");
                    return;
                }

                if (!IsProjectPackage(dialog.SelectedPath))
                {
                    MessageTip("您选择的目录不是程序包,请确认您选择的目录是否正确");
                    return;
                }

                if (!File.Exists(Path.Combine(dialog.SelectedPath, versionName)))
                {
                    MessageTip("非法的程序包,请确认您的软件包版本号");
                    return;
                }
                lbVersion.Text = SysHelper.GetVersionName(Path.Combine(dialog.SelectedPath, versionName));

                txtPackageSourceDir.Text = dialog.SelectedPath;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtProjectName.Text))
            {
                MessageTip("请先输入项目名称");
                return;
            }
            var dialog = new FolderBrowserDialog();
            dialog.Description = "请选择您要部署的项目所在的文件夹";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageTip("文件夹路径不能为空");
                    return;
                }
                DirectoryInfo dir = new DirectoryInfo(dialog.SelectedPath);
                if (dir.FullName == Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory))
                {
                    MessageTip("部署项目目录错误，请重新选择~~~");
                    return;
                }

                txtPackageDestDir.Text = dialog.SelectedPath;
                txtFtpService.Text = String.Empty;
                txtFtpService.Enabled = false;
                txtFtpUserName.Enabled = false;
                txtFtpUserName.Text = string.Empty;
                txtFtpPwd.Enabled = false;
                txtFtpPwd.Text = string.Empty;
                _isFptPublish = false;

                if (File.Exists(Path.Combine(txtPackageDestDir.Text, versionName)))
                {
                    lbDestVersion.Text = SysHelper.GetVersionName(Path.Combine(txtPackageDestDir.Text, versionName));
                }

            }
        }

        private bool IsProjectPackage(string path)
        {
            bool isProjectPackage = false;
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (var file in dir.GetFiles())
            {
                if (file.Extension == ".exe" || file.Extension == ".dll")
                {
                    isProjectPackage = true;
                    break;
                }
            }
            if (!isProjectPackage)
            {
                foreach (var item in dir.GetDirectories())
                {
                    if (item.Name.ToLower() == "bin")
                    {
                        isProjectPackage = true;
                        break;
                    }
                }
            }
            return isProjectPackage;

        }

        protected void MessageTip(string message)
        {
            MessageBox.Show(this, message, "提示");
        }

        protected void MessageError(string message)
        {
            MessageBox.Show(this, message, "错误");
        }

        public Bitmap ReadImageFromRes(string name)
        {
            Bitmap bitmap = null;
            Assembly assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(name);
            if (stream != null)
            {
                bitmap = new Bitmap(stream);
            }

            return bitmap;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (VerifyData())
            {

                if (_projectInfoDal.IsExistProjectConfig(txtProjectName.Text.Trim()))
                {
                    MessageTip(String.Format("已经存在项目名为{0}的配置,无需重复配置", txtProjectName.Text.Trim()));
                    return;
                }

                ProjectInfo projectInfo = null;
                if (!_isFptPublish)
                {
                    projectInfo = new ProjectInfo()
                    {
                        SourceDirectory = txtPackageSourceDir.Text.Trim(),
                        DestDirectory = txtPackageDestDir.Text.Trim(),
                        ProjectName = txtProjectName.Text.Trim(),
                    };
                }
                else
                {
                    projectInfo = new ProjectInfo()
                    {
                        SourceDirectory = txtPackageSourceDir.Text.Trim(),
                        ProjectName = txtProjectName.Text.Trim(),
                        FtpServiceAddress = txtFtpService.Text,
                        FtpUserName = txtFtpUserName.Text,
                        FtpPwd = txtFtpPwd.Text,
                        IsFtp = true,
                    };
                }

                if (_projectInfoDal.InsertProjectInfoConfig(projectInfo))
                {
                    MessageTip("配置成功!再次发布时,您可以通过\"选择项目\"来获取该项目的发布配置信息");
                    LoadProjectInfo();
                    txtProjectName.Enabled = false;
                    btnSaveProjectConfig.Enabled = false;
                    txtFtpPwd.Enabled = false;
                    txtFtpService.Enabled = false;
                    txtFtpUserName.Enabled = false;
                }
            }

        }

        private bool VerifyData()
        {
            if (!_isFptPublish)
            {
                if (String.IsNullOrEmpty(txtProjectName.Text))
                {
                    MessageTip("请输入您要发布的项目名称");
                    return false;
                }
                if (String.IsNullOrEmpty(txtPackageSourceDir.Text))
                {
                    MessageTip("请选择您要发布的程序包位置");
                    return false;
                }
                if (String.IsNullOrEmpty(txtPackageDestDir.Text))
                {
                    MessageTip("请选择您要发布程序的位置");
                    return false;
                }
            }
            else
            {
                Regex ftpRegex = new Regex(@"/^ftp:\/\/([a-zA-Z0-9_-])+:([a-zA-Z0-9_-])+@(([1-9]|([1-9]\d)|(1\d\d)|(2([0-4]\d|5[0-5])))\.)((d|([1-9]\d)|(1\d\d)|(2([0-4]\d|5[0-5])))\.){2}([1-9]|([1-9]\d)|(1\d\d)|(2([0-4]\d|5[0-5])))$/");
                if (ftpRegex.IsMatch(txtFtpService.Text.Trim()))
                {
                    MessageTip("您输入的FTP格式不正确");
                    return false;
                }

                if (string.IsNullOrEmpty(txtFtpUserName.Text))
                {
                    MessageTip("您输入的FTP服务器用户名");
                    return false;
                }

                if (string.IsNullOrEmpty(txtFtpPwd.Text))
                {
                    MessageTip("您输入的FTP服务器密码");
                    return false;
                }

            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (VerifyData())
            {
                bool isZipPage = !string.IsNullOrEmpty(Path.GetFileName(txtPackageSourceDir.Text)) &&
                                 Path.GetExtension(txtPackageSourceDir.Text).ToLower() == ".zip";


                if (_isFptPublish)
                {
                    #region FTP发布

                    RunBackGroudWork((o, e1) =>
                    {
                        try
                        {
                            var ftpHelper = new FTPHelper(txtFtpService.Text, txtFtpUserName.Text, txtFtpPwd.Text);

                            _isNewPublish = ftpHelper.GetFilesDetailList().Length <= 0;
                            var bk = o as BackgroundWorker;
                            if (isZipPage)
                            {
                                PublishZipPackageForFtp(bk, e1, ftpHelper);
                                MessageTip("程序包发布成功！");
                            }
                            else
                            {
                                //ftpHelper.UploadFile(txtPackageSourceDir.Text);
                                PublishPackageForFtp(bk, e1, ftpHelper);
                                MessageTip("程序包发布成功！");

                            }
                            _isNewPublish = false;
                            var projectInfo = _projectInfoDal.GetProjectInfoByName(txtProjectName.Text);
                            BindGridView(projectInfo.Id);
                        }
                        catch (Exception exception)
                        {
                            MessageError("发布失败，原因:" + exception.Message);
                        }
                    });


                    #endregion
                }
                else
                {
                    #region 本地发布

                    _isNewPublish = Directory.GetFiles(txtPackageDestDir.Text).Length <= 0;


                    RunBackGroudWork((o, e1) =>
                    {
                        var bk = o as BackgroundWorker;
                        try
                        {
                            if (isZipPage)
                            {
                                PublishZipPackage(bk, e1);
                                var destVersion = SysHelper.GetVersionName(Path.Combine(txtPackageDestDir.Text, versionName));
                                lbDestVersion.Text = destVersion;

                            }
                            else
                            {
                                PublishPackage(bk, e1);
                                SetVersionInfo();
                            }

                            _isNewPublish = false;
                            var projectInfo = _projectInfoDal.GetProjectInfoByName(txtProjectName.Text);
                            BindGridView(projectInfo.Id);

                        }
                        catch (Exception ex)
                        {
                            MessageError("发布异常,原因:" + ex.Message);
                            if (e1.Result != null)
                            {
                                bk.ReportProgress(5, "尝试还原程序包,请稍等...");
                                var publishInfo = _publishInfoDal.GetPublishInfoById(e1.Result.ToString());
                                if (publishInfo == null)
                                {
                                    MessageError("很遗憾，系统备份程序包失败，无法还原程序包...");
                                }
                                else
                                {
                                    bk.ReportProgress(20, "正在还原程序包,请稍等...");
                                    SysHelper.CopyDir(publishInfo.BackUpDirectory, txtPackageDestDir.Text);
                                    bk.ReportProgress(100, "程序包还原成功");
                                }
                            }
                        }
                    });

                    #endregion
                }

            }

        }

        private void PublishPackageForFtp(BackgroundWorker bk, DoWorkEventArgs e, FTPHelper ftpHelper)
        {
            bk.ReportProgress(0, "开始发布程序...");
            CacheProjectInfo(bk);

            var backupDir = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) +
                            "\\WinBulish\\" + txtProjectName.Text;
            if (!Directory.Exists(backupDir))
            {
                Directory.CreateDirectory(backupDir);
            }

            var publishId = DateTime.Now.ToString("yyyyMMddHHmmss");
            e.Result = publishId;

            var thisPublishDir = txtPackageSourceDir.Text;

            var versionSource = SysHelper.GetVersionName(Path.Combine(thisPublishDir, versionName));
            var thisBackDir = Path.Combine(backupDir, publishId);
            if (!_isNewPublish)
            {
                bk.ReportProgress(30, "正在备份程序包,请稍等...");
                BackUpFtpPackage(thisPublishDir, thisBackDir, ftpHelper);
                bk.ReportProgress(55, "正在备份程序包,请稍等...");

                bk.ReportProgress(60, "正在保存发布信息，请稍等...");
                _publishInfoDal.InsertPublishInfo(new PublishInfo()
                {
                    BackUpDirectory = thisBackDir,
                    BackUpType = BackUpType.Increment.ToString(),
                    Id = publishId,
                    OptionType = OptionType.Publish.ToString(),
                    ProjectId = _projectInfoDal.GetProjectInfoByName(txtProjectName.Text.Trim()).Id,
                    PublishDate = DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss"),
                    Version = versionSource,
                    IsFtp = _isFptPublish


                });
                bk.ReportProgress(75, "发布信息保存成功");
            }
            bk.ReportProgress(79, "正在发布程序，请稍等...");
            var files = Directory.GetFiles(thisPublishDir);
            foreach (var file in files)
            {
                ftpHelper.UploadFile(file);

            }
            var dirs = Directory.GetDirectories(thisPublishDir);
            foreach (var dir in dirs)
            {
                ftpHelper.UploadDir(thisPublishDir, dir.Substring(thisPublishDir.Length));
            }

            bk.ReportProgress(80, "正在移除临时文件夹，请稍等...");
            Directory.Delete(thisPublishDir, true);
            bk.ReportProgress(90, "移除临时文件夹成功...");
            lbDestVersion.Text = versionSource;
            bk.ReportProgress(100, "发布成功...");
        }

        private void PublishZipPackageForFtp(BackgroundWorker bk, DoWorkEventArgs e, FTPHelper ftpHelper)
        {
            bk.ReportProgress(0, "开始发布程序...");
            CacheProjectInfo(bk);

            var backupDir = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) +
                            "\\WinBulish\\" + txtProjectName.Text;
            if (!Directory.Exists(backupDir))
            {
                Directory.CreateDirectory(backupDir);
            }

            var publishId = DateTime.Now.ToString("yyyyMMddHHmmss");
            e.Result = publishId;

            var thisPublishDir = Path.Combine(backupDir, publishId);
            Directory.CreateDirectory(thisPublishDir);

            bk.ReportProgress(10, "请稍等，正在解压程序包...");
            if (SharpZip.UnpackFiles(txtPackageSourceDir.Text, thisPublishDir))
            {
                bk.ReportProgress(20, "程序包解压成功...");

                var versionSource = SysHelper.GetVersionName(Path.Combine(thisPublishDir, versionName));
                lbVersion.Text = versionSource;


                if (!_isNewPublish)
                {
                    bk.ReportProgress(30, "正在备份程序包,请稍等...");
                    var thisbackupDir = thisPublishDir + "_bak";
                    BackUpFtpPackage(thisPublishDir, thisbackupDir, ftpHelper);
                    bk.ReportProgress(55, "正在备份程序包,请稍等...");

                    bk.ReportProgress(60, "正在保存发布信息，请稍等...");
                    _publishInfoDal.InsertPublishInfo(new PublishInfo()
                    {
                        BackUpDirectory = thisbackupDir,
                        BackUpType = BackUpType.Increment.ToString(),
                        Id = publishId,
                        OptionType = OptionType.Publish.ToString(),
                        ProjectId = _projectInfoDal.GetProjectInfoByName(txtProjectName.Text.Trim()).Id,
                        PublishDate = DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss"),
                        Version = versionSource,
                        IsFtp = _isFptPublish


                    });
                    bk.ReportProgress(75, "发布信息保存成功");
                }
                bk.ReportProgress(79, "正在发布程序，请稍等...");
                var files = Directory.GetFiles(thisPublishDir);
                foreach (var file in files)
                {
                    ftpHelper.UploadFile(file);

                }
                var dirs = Directory.GetDirectories(thisPublishDir);
                foreach (var dir in dirs)
                {
                    ftpHelper.UploadDir(thisPublishDir, dir.Substring(thisPublishDir.Length));
                }
             

                bk.ReportProgress(80, "正在移除临时文件夹，请稍等...");
                Directory.Delete(thisPublishDir, true);
                bk.ReportProgress(90, "移除临时文件夹成功...");
                lbDestVersion.Text = versionSource;
                bk.ReportProgress(100, "发布成功...");
            }
            else
            {
                bk.ReportProgress(100, "程序包解压失败,请确认您的程序包是否正常");
                throw new Exception("程序包解压失败,请确认您的程序包是否正常");
            }
        }

        private void BackUpFtpPackage(string packageDir, string backupDir, FTPHelper ftpHelper, string subDir = null)
        {
            if (subDir == null)
            {
                // var backupDir = packageDir + "_bak";
                if (!Directory.Exists(backupDir))
                {
                    Directory.CreateDirectory(backupDir);
                }

                DirectoryInfo packageDirectoryInfo = new DirectoryInfo(packageDir);
                var files = packageDirectoryInfo.GetFiles();
                var ftpFiles = ftpHelper.GetDirAllList("/");
                var ftpFileNames = ftpFiles.Select(p =>
                {
                    var tempLine1 = Regex.Split(p, @"\s{2,}")[2];
                    var tempLine2 = Regex.Split(tempLine1, @"\s+").Skip(1);
                    var sb = new StringBuilder();
                    foreach (var item in tempLine2)
                    {
                        sb.Append(item);
                    }
                    return sb.ToString();
                }).ToList();


                foreach (var file in files)
                {
                    if (ftpFileNames.Any(p => p.Equals(file.Name.Replace(" ",""))))
                    {
                        ftpHelper.Download(backupDir, file.Name);
                    }
                }

                var dirs = packageDirectoryInfo.GetDirectories();
                foreach (var dir in dirs)
                {
                    BackUpFtpPackage(packageDir, backupDir, ftpHelper, dir.FullName.Substring(packageDir.Length));
                }
            }
            else
            {
                if (subDir.StartsWith("\\"))
                {
                    subDir = subDir.Remove(0, 1);
                }
                var packageSubDir = Path.Combine(packageDir, subDir);
                var backupSubDir = Path.Combine(backupDir, subDir);

                if (!Directory.Exists(backupSubDir))
                {
                    Directory.CreateDirectory(backupSubDir);
                }

                if (!subDir.StartsWith("/"))
                {
                    subDir = "/" + subDir;
                }
                if (!subDir.EndsWith("/"))
                {
                    subDir = subDir + "/";
                }
                if (subDir.Contains("\\"))
                {
                    subDir = subDir.Replace("\\", "/");
                }
                var packageSubDirInfo = new DirectoryInfo(packageSubDir);
                var files = packageSubDirInfo.GetFiles();
                //var ftpFiles = ftpHelper.GetDirAllList(subDir);
                var ftpFiles = ftpHelper.GetDirAllList(subDir);
                var ftpFileNames = ftpFiles.Select(p =>
                {
                    var tempLine1 = Regex.Split(p, @"\s{2,}")[2];
                    var tempLine2 = Regex.Split(tempLine1, @"\s+").Skip(1);
                    var sb = new StringBuilder();
                    foreach (var item in tempLine2)
                    {
                        sb.Append(item);
                    }
                    return sb.ToString();
                }).ToList();
                foreach (var file in files)
                {
                    if (ftpFileNames.Any(p => p.Equals(file.Name.Replace(" ",""))))
                    {
                        ftpHelper.Download(backupSubDir, file.Name, subDir);
                    }
                }
                var dirs = packageSubDirInfo.GetDirectories();
                foreach (var dir in dirs)
                {
                    BackUpFtpPackage(packageDir, backupDir, ftpHelper, dir.FullName.Substring(packageDir.Length));
                }
            }


        }

        private void PublishZipPackage(BackgroundWorker bk, DoWorkEventArgs e)
        {
            bk.ReportProgress(0, "开始发布程序...");
            CacheProjectInfo(bk);

            var backupDir = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) +
                            "\\WinBulish\\" + txtProjectName.Text;
            if (!Directory.Exists(backupDir))
            {
                Directory.CreateDirectory(backupDir);
            }
            var publishId = DateTime.Now.ToString("yyyyMMddHHmmss");
            e.Result = publishId;
            var thisPublishBackupDir = Path.Combine(backupDir, publishId);
            Directory.CreateDirectory(thisPublishBackupDir);
            bk.ReportProgress(10, "请稍等，正在解压程序包...");
            if (SharpZip.UnpackFiles(txtPackageSourceDir.Text, thisPublishBackupDir))
            {
                bk.ReportProgress(20, "程序包解压成功...");

                var versionSource = SysHelper.GetVersionName(Path.Combine(thisPublishBackupDir, versionName));
                lbVersion.Text = versionSource;


                if (!_isNewPublish)
                {
                    var versionDest = SysHelper.GetVersionName(Path.Combine(txtPackageDestDir.Text, versionName));
                    bk.ReportProgress(30, "正在检查程序包版本,请稍等...");

                    var compareResult = SysHelper.CompareVersion(versionSource, versionDest);
                    if (compareResult == 1)
                    {
                        if (MessageBox.Show(this, "当前版本比发布版本版本号高,您确定要替换当前版本吗？", "警告", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            return;
                        }

                    }
                    else if (compareResult == 0)
                    {
                        if (MessageBox.Show(this, "当前版本与发布版本版本号相同,您确定要替换当前版本吗？", "警告", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                    bk.ReportProgress(40, "程序包版本号验证成功");

                    bk.ReportProgress(45, "开始差异备份程序包，请稍等...");
                    var diffBackDir = Path.Combine(backupDir, publishId + "_Bak");
                    DiffBackUp(new DirectoryInfo(thisPublishBackupDir), new DirectoryInfo(txtPackageDestDir.Text), diffBackDir);
                    // 备份版本文件
                    File.Copy(Path.Combine(txtPackageDestDir.Text, versionName), Path.Combine(diffBackDir, versionName), true);
                    bk.ReportProgress(60, "备份成功");

                    _publishInfoDal.InsertPublishInfo(new PublishInfo()
                    {
                        BackUpDirectory = diffBackDir,
                        BackUpType = BackUpType.Increment.ToString(),
                        Id = publishId,
                        OptionType = OptionType.Publish.ToString(),
                        ProjectId = _projectInfoDal.GetProjectInfoByName(txtProjectName.Text.Trim()).Id,
                        PublishDate = DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss"),
                        Version = versionDest,
                    });

                }

                bk.ReportProgress(70, "开始发布程序包，请稍等...");
                SysHelper.Replace(thisPublishBackupDir, txtPackageDestDir.Text);

                bk.ReportProgress(80, "正在删除解压缩文件,请稍等...");
                SysHelper.DeleteDir(thisPublishBackupDir);
                bk.ReportProgress(99, "解压缩文件删除成功");
                bk.ReportProgress(100, "程序包发布成功");
            }
            else
            {
                bk.ReportProgress(100, "程序包解压失败,请确认您的程序包是否正常");
                throw new Exception("程序包解压失败,请确认您的程序包是否正常");
            }


        }

        private void PublishPackage(BackgroundWorker bk, DoWorkEventArgs e)
        {
            bk.ReportProgress(0, "开始发布程序...");
            //缓存项目配置文件
            CacheProjectInfo(bk);

            if (!_isNewPublish)
            {
                bk.ReportProgress(10, "检查程序包版本号，请稍等...");
                var versionSource = SysHelper.GetVersionName(Path.Combine(txtPackageSourceDir.Text, versionName));
                var versionDest = SysHelper.GetVersionName(Path.Combine(txtPackageDestDir.Text, versionName));

                var compareResult = SysHelper.CompareVersion(versionSource, versionDest);
                if (compareResult == 1)
                {
                    if (MessageBox.Show(this, "当前版本比发布版本版本号高,您确定要替换当前版本吗？", "警告", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }

                }
                else if (compareResult == 0)
                {
                    if (MessageBox.Show(this, "当前版本与发布版本版本号相同,您确定要替换当前版本吗？", "警告", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                lbVersion.Text = versionSource;
                bk.ReportProgress(40, "程序包版本号验证成功");
                //备份之前发布的包
                bk.ReportProgress(45, "开始备份程序包,请稍等...");
                var backupDir = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) +
                                "\\WinBulish\\" + txtProjectName.Text;
                if (!Directory.Exists(backupDir))
                {
                    Directory.CreateDirectory(backupDir);
                }
                var publishId = DateTime.Now.ToString("yyyyMMddHHmmdd");
                e.Result = publishId;
                var thisPublishBackupDir = Path.Combine(backupDir, publishId);
                Directory.CreateDirectory(thisPublishBackupDir);

                //删除之前发布的文件
                //  SysHelper.MoveDirAndStayFromDir(txtPackageDestDir.Text, thisPublishBackupDir);
                // 使用差异备份
                DiffBackUp(new DirectoryInfo(txtPackageSourceDir.Text.Trim()), new DirectoryInfo(txtPackageDestDir.Text), thisPublishBackupDir);
                bk.ReportProgress(50, "程序备份成功...");
                bk.ReportProgress(51, "开始保存备份信息,请稍等...");
                //保存备份信息
                _publishInfoDal.InsertPublishInfo(new PublishInfo()
                {
                    Id = publishId,
                    BackUpDirectory = thisPublishBackupDir,
                    ProjectId = _projectInfoDal.GetProjectInfoByName(txtProjectName.Text.Trim()).Id,
                    PublishDate = DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss"),
                    Version = versionDest,
                    BackUpType = BackUpType.Increment.ToString(),
                    OptionType = OptionType.Publish.ToString()
                });
                bk.ReportProgress(70, "备份信息保存成功...");
            }

            bk.ReportProgress(75, "开始发布新的程序包，请稍等...");
            // 发布新的包
            SysHelper.Replace(txtPackageSourceDir.Text.Trim(), txtPackageDestDir.Text);

            bk.ReportProgress(100, "新的程序包发布成功...");

            MessageTip("程序包发布成功...");
            //5.如果发布失败还原之前的包
        }

        public void DiffBackUp(DirectoryInfo sourceDir, DirectoryInfo destDir, string diffBackUpDirStr)
        {
            if (!Directory.Exists(diffBackUpDirStr))
            {
                Directory.CreateDirectory(diffBackUpDirStr);
            }

            var diffBackUpDir = new DirectoryInfo(diffBackUpDirStr);

            var files = sourceDir.GetFiles();
            foreach (var file in files)
            {
                if (!File.Exists(Path.Combine(destDir.FullName, file.Name)))
                {
                    continue;
                }
                if (!SysHelper.IsEqualFile(file.FullName, Path.Combine(destDir.FullName, file.Name)))
                {
                    File.Copy(Path.Combine(destDir.FullName, file.Name), Path.Combine(diffBackUpDir.FullName, file.Name), true);
                }
            }

            var dirs = sourceDir.GetDirectories();
            foreach (var dir in dirs)
            {
                var subDestDir = Path.Combine(destDir.FullName, dir.Name);
                var diffsubBackUpDir = Path.Combine(diffBackUpDir.FullName, dir.Name);
                DiffBackUp(dir, new DirectoryInfo(subDestDir), diffsubBackUpDir);
            }

        }

        private void CacheProjectInfo(BackgroundWorker bk)
        {
            if (!_projectInfoDal.IsExistProjectConfig(txtProjectName.Text.Trim()))
            {
                bk.ReportProgress(1, "缓存项目配置文件,请稍等...");
                var projectInfo = new ProjectInfo()
                {
                    SourceDirectory = txtPackageSourceDir.Text.Trim(),
                    DestDirectory = txtPackageDestDir.Text.Trim(),
                    ProjectName = txtProjectName.Text.Trim(),
                    FtpPwd = txtFtpPwd.Text.Trim(),
                    FtpServiceAddress = txtFtpService.Text.Trim(),
                    FtpUserName = txtFtpUserName.Text.Trim(),
                    IsFtp = _isFptPublish
                };
                _projectInfoDal.InsertProjectInfoConfig(projectInfo);
                LoadProjectInfo();
                bk.ReportProgress(10, "缓存项目配置文件成功...");
            }
            else
            {
                bk.ReportProgress(1, "检查更新项目配置文件,请稍等...");

                var existProjectInfo = _projectInfoDal.GetProjectInfoByName(txtProjectName.Text.Trim());
                var newProjectInfo = new ProjectInfo()
                {
                    Id = existProjectInfo.Id,
                    SourceDirectory = txtPackageSourceDir.Text.Trim(),
                    DestDirectory = txtPackageDestDir.Text.Trim(),
                    ProjectName = existProjectInfo.ProjectName,
                    FtpPwd = txtFtpPwd.Text.Trim(),
                    FtpServiceAddress = txtFtpService.Text.Trim(),
                    FtpUserName = txtFtpUserName.Text.Trim(),
                    IsFtp = _isFptPublish
                };
                if (_projectInfoDal.IsNeedUpdate(newProjectInfo, existProjectInfo))
                {
                    _projectInfoDal.UpdateProjectInfo(newProjectInfo);
                    LoadProjectInfo();
                }
                bk.ReportProgress(10, "项目配置文件更新成功...");
            }
        }

        protected void RunBackGroudWork(DoWorkEventHandler handler)
        {
            var bkWorker = new BackgroundWorker();
            bkWorker.DoWork += handler;
            bkWorker.RunWorkerCompleted += CompleteWork;
            bkWorker.ProgressChanged += bkWorker_ProgressChanged;
            bkWorker.WorkerReportsProgress = true;
            bkWorker.RunWorkerAsync();
            HandleProgressBar.ProgressBar.ShowDialog(this.Owner);
            HandleProgressBar.ProgressBar.UseWaitCursor = true;
        }

        private void bkWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Thread.Sleep(300);
            HandleProgressBar.ProgressBar.SetNotifyInfo(e.ProgressPercentage, e.UserState.ToString());
        }

        private void CompleteWork(object sender, RunWorkerCompletedEventArgs e)
        {
            HandleProgressBar.ProgressBar.Close();
            HandleProgressBar.ProgressBar.UseWaitCursor = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (VerifyData())
            {
                RunBackGroudWork((o, e1) =>
                {
                    try
                    {
                        var bk = o as BackgroundWorker;
                        bk.ReportProgress(0, "开始备份程序包，请稍等...");

                        var backupDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                        "\\WinBulish\\" + txtProjectName.Text;
                        if (!Directory.Exists(backupDir))
                        {
                            Directory.CreateDirectory(backupDir);
                        }
                        var publishId = DateTime.Now.ToString("yyyyMMddHHMMss");
                        e1.Result = publishId;
                        var thisBackupDir = Path.Combine(backupDir, publishId);
                        Directory.CreateDirectory(thisBackupDir);
                        if (_isFptPublish)
                        {
                            var ftpHelper = new FTPHelper(txtFtpService.Text, txtFtpUserName.Text, txtFtpPwd.Text);
                            ftpHelper.DownloadDir(thisBackupDir);
                        }
                        else
                        {
                          
                            SysHelper.CopyDir(txtPackageDestDir.Text, thisBackupDir);
                        }

                        bk.ReportProgress(80, "程序包备份成功");

                        bk.ReportProgress(85, "开始保存备份信息");
                        _publishInfoDal.InsertPublishInfo(new PublishInfo()
                        {
                            Id = publishId,
                            BackUpDirectory = thisBackupDir,
                            ProjectId = _projectInfoDal.GetProjectInfoByName(txtProjectName.Text.Trim()).Id,
                            PublishDate = DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss"),
                            Version = lbDestVersion.Text,
                            OptionType = OptionType.BackUp.ToString(),
                            BackUpType = BackUpType.Full.ToString()
                        });
                        //SetVersionInfo();

                        bk.ReportProgress(100, "备份信息保存成功...");
                        MessageTip("程序包备份成功...");
                        BindGridView(_projectInfoDal.GetProjectInfoByName(txtProjectName.Text).Id);
                    }
                    catch (Exception exception)
                    {
                        MessageError("备份失败,原因:" + exception.Message);
                    }

                });

            }
        }

        private void txtProjectName_TextChange(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            if (!string.IsNullOrEmpty(txt.Text))
            {
                var projectInfo = _projectInfoDal.GetProjectInfoByName(txt.Text.Trim());
                if (projectInfo != null)
                {

                    BindProjectInfo(txt.Text.Trim(), true);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // LoadProjectInfo();
            txtProjectName.Text = "";
            txtProjectName.Enabled = true;
            btnSaveProjectConfig.Enabled = true;
            txtPackageSourceDir.Text = "";
            txtPackageDestDir.Text = "";
            lbVersion.Text = "";
            lbDestVersion.Text = "";
            bindingSourcePublish.DataSource = null;
            txtFtpService.Enabled = true;
            txtFtpService.Text = "";
            txtFtpUserName.Enabled = true;
            txtFtpUserName.Text = "";
            txtFtpPwd.Enabled = true;
            txtFtpPwd.Text = "";

            btnChoiceDestDir.Enabled = true;
            _isFptPublish = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProjectName.Text))
            {
                MessageTip("请先输入项目名称");
                txtProjectName.Focus();
                return;
            }
            var prejectInfo = _projectInfoDal.GetProjectInfoByName(txtProjectName.Text.Trim());
            if (prejectInfo == null)
            {
                MessageTip("不存在该项目，请确认要发布的项目名称");
                txtProjectName.Focus();
                return;
            }
            var publishInfo = _publishInfoDal.GetLatestPublish(prejectInfo.Id);
            if (publishInfo == null)
            {
                MessageTip("该项目不存在备份数据，无法还原历史版本");
                return;
            }

            RunBackGroudWork((o, e1) =>
            {
                var bk = o as BackgroundWorker;

                try
                {
                    bk.ReportProgress(0, string.Format("开始还原版本号为{0}的历史版本,请稍等...", publishInfo.Version));

                    bk.ReportProgress(10, string.Format("正在还原版本号为{0}的历史版本,请稍等...", publishInfo.Version));
                    //Directory.Delete(txtPackageDestDir.Text, true);
                    //Directory.CreateDirectory(txtPackageDestDir.Text);
                    //SysHelper.CopyDir(publishInfo.BackUpDirectory, txtPackageDestDir.Text);
                    if (!_isFptPublish)
                    {
                        SysHelper.Replace(publishInfo.BackUpDirectory, txtPackageDestDir.Text);
                    }
                    else
                    {
                        var ftpHelper = new FTPHelper(txtFtpService.Text, txtFtpUserName.Text, txtFtpPwd.Text);
                        var files = Directory.GetFiles(publishInfo.BackUpDirectory);
                        foreach (var file in files)
                        {
                            ftpHelper.UploadFile(file);

                        }
                        var dirs = Directory.GetDirectories(publishInfo.BackUpDirectory);
                        foreach (var dir in dirs)
                        {
                            if (Directory.GetFiles(dir).Length <=0)
                            {
                                break;
                            }
                            ftpHelper.UploadDir(publishInfo.BackUpDirectory, dir.Substring(publishInfo.BackUpDirectory.Length));
                        }
                    }
                   
                    bk.ReportProgress(100, string.Format("版本号为{0}的程序包还原成功！", publishInfo.Version));
                    //SetVersionInfo();
                    lbDestVersion.Text = publishInfo.Version;
                    MessageTip(string.Format("版本号为{0}的程序包还原成功！", publishInfo.Version));
                }
                catch (Exception ex)
                {
                    MessageTip(string.Format("版本号为{0}的程序包还原失败！原因：" + ex.Message, publishInfo.Version));
                }
            });
        }

        private void dataGridViewPublish_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                RunBackGroudWork((o, e1) =>
                {
                    var dataGrid = sender as DataGridView;
                    var bk = o as BackgroundWorker;

                    var backupDir = dataGrid.CurrentRow.Cells["BackUpDirectory"].Value.ToString();
                    var version = dataGrid.CurrentRow.Cells["versionDataGridViewTextBoxColumn"].Value;
      
                    var publishId = dataGrid.CurrentRow.Cells["Id"].Value;
                    var publishInfo = _publishInfoDal.GetPublishInfoById(publishId.ToString());
                    try
                    {

                        bk.ReportProgress(0, string.Format("开始还原版本号为{0}的历史版本,请稍等...", version));
                        bk.ReportProgress(10, string.Format("正在还原版本号为{0}的历史版本,请稍等...", version));

                        //Directory.Delete(txtPackageDestDir.Text, true);
                        //Directory.CreateDirectory(txtPackageDestDir.Text);
                        //SysHelper.CopyDir(backupDir, txtPackageDestDir.Text);

                        if (publishInfo.IsFtp)
                        {
                            var ftpHelper = new FTPHelper(txtFtpService.Text, txtFtpUserName.Text, txtFtpPwd.Text);
                            var files = Directory.GetFiles(backupDir);
                            foreach (var file in files)
                            {
                                ftpHelper.UploadFile(file);

                            }
                            var dirs = Directory.GetDirectories(backupDir);
                            foreach (var dir in dirs)
                            {
                                if (Directory.GetFiles(dir).Length <= 0)
                                {
                                    break;
                                }
                                ftpHelper.UploadDir(backupDir, dir.Substring(backupDir.Length));
                            }
                        }
                        else
                        {
                            SysHelper.Replace(backupDir, txtPackageDestDir.Text);
                            lbDestVersion.Text = version.ToString();
                        }
                   
                        bk.ReportProgress(100, string.Format("版本号为{0}的程序包还原成功！", version));
                        // SetVersionInfo();
                      
                        MessageTip(string.Format("版本号为{0}的程序包还原成功！", version));

                    }
                    catch (Exception ex)
                    {
                        MessageTip(string.Format("版本号为{0}的程序包还原失败！原因：" + ex.Message, version));
                    }
                });

            }
        }

        private void tsmiClearCache_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProjectName.Text))
            {
                if (MessageBox.Show(this, "您确定要清除所有的缓存吗?清除缓存后，小工具将无法还原历史包？", "警告", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    RunBackGroudWork((o, e1) =>
                    {
                        var bk = o as BackgroundWorker;
                        bk.ReportProgress(5, "正在获取所有的项目配置,请稍等...");

                        var projects = _projectInfoDal.GetAllProjectInfos();
                        if (projects.Count > 0)
                        {
                            bk.ReportProgress(10, "获取项目配置");
                            bk.ReportProgress(15, "正在项目配置缓存,请稍等...");

                            var stepCount = (90 - 15) / projects.Count;
                            for (var i = 0; i < projects.Count; i++)
                            {

                                var project = projects[i];
                                bk.ReportProgress(15 + stepCount * (i + 1), string.Format("正在项目{0}缓存,请稍等...", project.ProjectName));
                                _projectInfoDal.Remove(project.Id);

                                var pulishList = _publishInfoDal.GetPublishInfosByProjectId(project.Id);
                                if (pulishList != null && pulishList.Count > 0)
                                {
                                    foreach (var publish in pulishList)
                                    {
                                        _publishInfoDal.Remove(publish.Id);
                                    }
                                }

                                bk.ReportProgress(15 + stepCount * (i + 1), string.Format("项目{0}缓存清理成功", project.ProjectName));
                            }

                            txtProjectName.Text = "";
                            txtProjectName.Enabled = true;
                            btnSaveProjectConfig.Enabled = true;
                            txtPackageSourceDir.Text = "";
                            txtPackageDestDir.Text = "";
                            lbVersion.Text = "";
                            lbDestVersion.Text = "";
                            bk.ReportProgress(100, ",小工具缓存清理成功...");
                            LoadProjectInfo();


                            MessageTip("小工具缓存清理成功");
                            bindingSourcePublish.DataSource = null;
                        }
                        else
                        {
                            bk.ReportProgress(100, "小工具不存在缓存，无需清理");
                        }
                    });
                }
            }
            else
            {
                if (MessageBox.Show(this, "您确定要清除" + txtProjectName.Text + "的缓存吗?清除缓存后，小工具将无法还原历史包？", "警告", MessageBoxButtons.OKCancel) ==
                    DialogResult.OK)
                {
                    RunBackGroudWork((o, e1) =>
                    {
                        var bk = o as BackgroundWorker;
                        bk.ReportProgress(5, "正在获取所有的项目配置,请稍等...");

                        var project = _projectInfoDal.GetProjectInfoByName(txtProjectName.Text);
                        if (project != null)
                        {
                            bk.ReportProgress(10, "获取项目配置");
                            bk.ReportProgress(15, "正在项目配置缓存,请稍等...");

                            bk.ReportProgress(100, string.Format("正在项目{0}缓存,请稍等...", project.ProjectName));
                            _projectInfoDal.Remove(project.Id);

                            var pulishList = _publishInfoDal.GetPublishInfosByProjectId(project.Id);
                            if (pulishList != null && pulishList.Count > 0)
                            {
                                foreach (var publish in pulishList)
                                {
                                    _publishInfoDal.Remove(publish.Id);
                                }
                            }
                            txtProjectName.Text = "";
                            txtProjectName.Enabled = true;
                            btnSaveProjectConfig.Enabled = true;
                            txtPackageSourceDir.Text = "";
                            txtPackageDestDir.Text = "";
                            lbVersion.Text = "";
                            lbDestVersion.Text = "";


                            bk.ReportProgress(100, "小工具缓存清理成功...");
                            LoadProjectInfo();


                            MessageTip("小工具缓存清理成功");
                            bindingSourcePublish.DataSource = null;
                        }
                        else
                        {
                            bk.ReportProgress(100, "不存在该项目的配置，无需清理");
                        }
                    });
                }

            }

        }

        private void btnChioceZip_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtProjectName.Text))
            {
                MessageTip("请先输入项目名称");
                return;
            }
            var dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Filter = "压缩文件(*.ZIP)|*.zip;*.ZIP;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtPackageSourceDir.Text = dialog.FileName;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (VerifyData())
            {
                bool isZipPage = !string.IsNullOrEmpty(Path.GetFileName(txtPackageSourceDir.Text)) &&
                                 Path.GetExtension(txtPackageSourceDir.Text).ToLower() == ".zip";
                try
                {
                    RunBackGroudWork((o, e1) => { IncrementBackUpPackage(o, e1, isZipPage); });
                }
                catch (Exception exception)
                {
                    MessageError("程序包备份失败,原因:" + exception.Message);
                }
            }
        }

        private void IncrementBackUpPackage(object o, DoWorkEventArgs e1, bool isZipPage)
        {
            var bk = o as BackgroundWorker;
            bk.ReportProgress(0, "开始备份程序包，请稍等...");

            var backupDir = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) +
                            "\\WinBulish\\" + txtProjectName.Text;
            if (!Directory.Exists(backupDir))
            {
                Directory.CreateDirectory(backupDir);
            }
            var publishId = DateTime.Now.ToString("yyyyMMddHHMMss");
            e1.Result = publishId;
            var thisBackupDir = Path.Combine(backupDir, publishId);


            if (isZipPage)
            {
                bk.ReportProgress(10, "请稍等，正在解压程序包...");
                if (SharpZip.UnpackFiles(txtPackageSourceDir.Text, thisBackupDir))
                {
                    bk.ReportProgress(20, "程序包解压成功...");

                    var versionSource =
                        SysHelper.GetVersionName(Path.Combine(thisBackupDir, versionName));
                    lbVersion.Text = versionSource;


                    var versionDest = string.Empty;


                    bk.ReportProgress(45, "开始差异备份程序包，请稍等...");
                    var diffBackDir = Path.Combine(backupDir, publishId + "_Bak");
                    if (!Directory.Exists(diffBackDir))
                    {
                        Directory.CreateDirectory(diffBackDir);
                    }
                    if (_isFptPublish)
                    {
                        var ftpHelper = new FTPHelper(txtFtpService.Text, txtFtpUserName.Text, txtFtpPwd.Text);
                        //   versionDest = SysHelper.GetFtpVersionName(Path.Combine(txtPackageDestDir.Text, versionName));

                        ftpHelper.Download(diffBackDir, versionName);
                        versionDest =
                            SysHelper.GetVersionName(Path.Combine(diffBackDir, versionName));
                        BackUpFtpPackage(thisBackupDir, diffBackDir, ftpHelper);
                    }
                    else
                    {
                        versionDest = SysHelper.GetVersionName(Path.Combine(txtPackageDestDir.Text, versionName));
                        DiffBackUp(new DirectoryInfo(thisBackupDir),
                            new DirectoryInfo(txtPackageDestDir.Text), diffBackDir);
                        // 备份版本文件
                        File.Copy(Path.Combine(txtPackageDestDir.Text, versionName),
                            Path.Combine(diffBackDir, versionName), true);
                    }


                    _publishInfoDal.InsertPublishInfo(new PublishInfo()
                    {
                        BackUpDirectory = diffBackDir,
                        BackUpType = BackUpType.Increment.ToString(),
                        Id = publishId,
                        OptionType = OptionType.BackUp.ToString(),
                        ProjectId = _projectInfoDal.GetProjectInfoByName(txtProjectName.Text.Trim()).Id,
                        PublishDate = DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss"),
                        Version = versionDest,
                    });
                    //SetVersionInfo();
                    bk.ReportProgress(100, "备份信息保存成功...");
                    MessageTip("程序包备份成功...");
                    BindGridView(_projectInfoDal.GetProjectInfoByName(txtProjectName.Text).Id);
                }
                else
                {
                    MessageTip("解压失败");
                }
            }
            else
            {
                //Directory.CreateDirectory(thisBackupDir);

                //SysHelper.CopyDir(txtPackageDestDir.Text, thisBackupDir);
                var versionDest = string.Empty;
                    
                if (!_isFptPublish)
                {
                    versionDest = SysHelper.GetVersionName(Path.Combine(txtPackageDestDir.Text, versionName));
                    DiffBackUp(new DirectoryInfo(txtPackageSourceDir.Text),
                        new DirectoryInfo(txtPackageDestDir.Text), thisBackupDir);
                }
                else
                {
                    var diffBackDir = Path.Combine(backupDir, publishId + "_Bak");
                    if (!Directory.Exists(diffBackDir))
                    {
                        Directory.CreateDirectory(diffBackDir);
                    }
                    var ftpHelper = new FTPHelper(txtFtpService.Text, txtFtpUserName.Text, txtFtpPwd.Text);
                      
                    ftpHelper.Download(diffBackDir, versionName);
                    versionDest =
                        SysHelper.GetVersionName(Path.Combine(diffBackDir, versionName));
                    BackUpFtpPackage(thisBackupDir, diffBackDir, ftpHelper);
                }
                bk.ReportProgress(80, "程序包备份成功");

                bk.ReportProgress(85, "开始保存备份信息,请稍等...");
                _publishInfoDal.InsertPublishInfo(new PublishInfo()
                {
                    Id = publishId,
                    BackUpDirectory = thisBackupDir,
                    ProjectId = _projectInfoDal.GetProjectInfoByName(txtProjectName.Text.Trim()).Id,
                    PublishDate = DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss"),
                    Version = versionDest,
                    OptionType = OptionType.BackUp.ToString(),
                    BackUpType = BackUpType.Increment.ToString()
                });
                bk.ReportProgress(100, "备份信息保存成功...");
                MessageTip("程序包备份成功...");
                BindGridView(_projectInfoDal.GetProjectInfoByName(txtProjectName.Text).Id);
            }
        }

        private void txtFtpService_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtProjectName.Text))
            {
                MessageTip("请先输入项目名称");
                txtFtpService.Text = String.Empty;
                return;
            }
            TextBox txtBox = sender as TextBox;
            if (!string.IsNullOrEmpty(txtBox.Text))
            {
                // ftp发布
                _isFptPublish = true;
                btnChoiceDestDir.Enabled = false;
                txtPackageDestDir.Text = string.Empty;
                txtFtpUserName.Enabled = true;
                txtFtpPwd.Enabled = true;

            }
            else
            {
                // 非ftp发布
                _isFptPublish = false;
                btnChoiceDestDir.Enabled = true;
                txtFtpService.Text = string.Empty;
                txtFtpUserName.Enabled = false;
                txtFtpPwd.Enabled = false;
            }
        }

    }
}

