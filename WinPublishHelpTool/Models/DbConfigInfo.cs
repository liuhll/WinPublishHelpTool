using System;

namespace WinPublishHelpTool.Models
{
    public class DbConfigInfo
    {
        public DbConfigInfo()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string DbSourceName { get; set; }

        public string DbConnectionString { get; set; }

        public string DbSourceAddress { get; set; }

        public string DbSourceServiceName { get; set; }

        public string DbSourceServicePwd { get; set; }
    }
}


