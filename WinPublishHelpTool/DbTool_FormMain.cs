using System;
using WinPublishHelpTool.Tools;

namespace WinPublishHelpTool
{
    public partial class FormMain
    {
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
    }
}