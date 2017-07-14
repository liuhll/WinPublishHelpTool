using System;
using WinPublishHelpTool.Commons;

namespace WinPublishHelpTool.Models
{
    public class ProjectInfo
    {
        public ProjectInfo()
        {
            Id = Guid.NewGuid().ToString();
            IsFtp = false;
            FtpServiceAddress = string.Empty;
            FtpUserName = string.Empty;
            FtpPwd = string.Empty;
            DestDirectory = string.Empty;
        }

        public string Id { get; set; }

        public string ProjectName { get; set; }

        public string SourceDirectory { get; set; }

        public string DestDirectory { get; set; }

        public string FtpServiceAddress { get; set; }

        public string FtpUserName { get; set; }

        public string FtpPwd { get; set; }

        public bool IsFtp { get; set; }
    }
}