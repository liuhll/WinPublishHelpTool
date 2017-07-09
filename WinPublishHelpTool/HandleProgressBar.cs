using System.Drawing;
using System.Windows.Forms;

namespace WinPublishHelpTool
{
    public partial class HandleProgressBar : Form
    {
        private static HandleProgressBar _progressBar;

        private HandleProgressBar()
        {
            InitializeComponent();
            this.ControlBox = false;   // 设置不出现关闭按钮
            lbInfo.Text = "开始处理任务...";
            lbInfo.AutoSize = true;
            this.StartPosition = FormStartPosition.CenterParent;
           
        }

        public static HandleProgressBar ProgressBar
        {
            get { return _progressBar ?? (_progressBar = new HandleProgressBar()); }

        }

   

        public void SetNotifyInfo(int percent, string message)
        {
            this.lbInfo.Text = string.Format("当前进度:{0}%;   当前:{1}",percent,message);
            this.progressBar1.Value = percent;
        }  
    }
}
