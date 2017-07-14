using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using WinPublishHelpTool.Models;
using WinPublishHelpTool.Tools;

namespace WinPublishHelpTool.Dal
{
    public class DbConfigInfoDal
    {
        private readonly XmlHelper _xmlHelper;
        private IList<DbConfigInfo> _dbConfigInfos;

        public DbConfigInfoDal()
        {
            _xmlHelper = new XmlHelper(AppDomain.CurrentDomain.BaseDirectory + "./Datas/DbBackupDatas.xml");
        }

        private void LoadDatas()
        {
            _dbConfigInfos = new List<DbConfigInfo>();
            var nodes = _xmlHelper.GetNode("/databases").ChildNodes;
            foreach (XmlNode node in nodes)
            {
                var dbconfigInfo = new DbConfigInfo()
                {
                    Id = node.SelectSingleNode("./Id").InnerText,
                    DbSourceName = node.SelectSingleNode("./DbSourceName").InnerText,
                    DbConnectionString = node.SelectSingleNode("./DbConnectionString").InnerText,
                    DbSourceServicePwd = node.SelectSingleNode("./DbSourceServicePwd").InnerText,
                    DbSourceServiceName = node.SelectSingleNode("./DbSourceServiceName").InnerText,
                    DbSourceAddress = node.SelectSingleNode("./DbSourceAddress").InnerText,

                };
                _dbConfigInfos.Add(dbconfigInfo);

            }
        }

        public IList<DbConfigInfo> GetAllConfigInfos()
        {
            LoadDatas();
            return _dbConfigInfos;
        }

        public DbConfigInfo GetDbConfigInfo(string configName)
        {
            LoadDatas();
            return _dbConfigInfos.FirstOrDefault(p=>p.DbSourceName == configName);
        }

        public bool ExsitDbConfigInfo(string configName)
        {
            LoadDatas();
            return _dbConfigInfos.FirstOrDefault(p => p.DbSourceName == configName)  != null;
        }

        public bool InsertConfig(DbConfigInfo info)
        {
            var xmlNode = _xmlHelper.SerializeXmlNode(info);
            _xmlHelper.AppendNode(xmlNode);
            _xmlHelper.Save();
            return true;
        }
    }
}