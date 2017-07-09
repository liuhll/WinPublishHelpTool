using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using WinPublishHelpTool.Models;
using WinPublishHelpTool.Tools;

namespace WinPublishHelpTool.Dal
{
    public class PublishInfoDal
    {
        private readonly XmlHelper _xmlHelper;

        private IList<PublishInfo> _publishInfos;

        public PublishInfoDal()
        {
            _xmlHelper = new XmlHelper(AppDomain.CurrentDomain.BaseDirectory + "./Datas/PublishDatas.xml");
            LoadDatas();
        }

        private void LoadDatas()
        {
            _publishInfos = new List<PublishInfo>();
            using (var nodes = _xmlHelper.GetNode("/publish").ChildNodes)
            {
                foreach (XmlNode node in nodes)
                {
                    var projectInfo = new PublishInfo()
                    {
                        Id = node.SelectSingleNode("./Id").InnerText,
                        ProjectId = node.SelectSingleNode("./ProjectId").InnerText,
                        PublishDate = node.SelectSingleNode("./PublishDate").InnerText,
                        BackUpDirectory = node.SelectSingleNode("./BackUpDirectory").InnerText,
                        Version = node.SelectSingleNode("./Version").InnerText,
                        OptionType = node.SelectSingleNode("./OptionType").InnerText,
                    };
                    _publishInfos.Add(projectInfo);

                }
            }
        }


        public void InsertPublishInfo(PublishInfo publishInfo)
        {
            var xmlNode = _xmlHelper.SerializeXmlNode(publishInfo);
            _xmlHelper.AppendNode(xmlNode);
            _xmlHelper.Save();
           
        }

        public PublishInfo GetPublishInfoById(string id)
        {
            LoadDatas();
            return _publishInfos.FirstOrDefault(p => p.Id == id);
        }

        public IList<PublishInfo> GetPublishInfosByProjectId(string projectInfoId)
        {
            LoadDatas();
            return _publishInfos.Where(p => p.ProjectId == projectInfoId).OrderByDescending(p=>p.PublishDate).ToList();
        }

        public PublishInfo GetLatestPublish(string projectInfoId)
        {
            var publishList =  GetPublishInfosByProjectId(projectInfoId);
            if (publishList == null || publishList.Count <=0)
            {
                return null;
            }
            return publishList.First();
        }

        public void Remove(string publishId)
        {
            var index = GetPublishIndexById(publishId);

            _xmlHelper.RemoveNode(string.Format("/publish/PublishInfo[{0}]", index));
            _xmlHelper.Save();
        }

        private int GetPublishIndexById(string publishId)
        {
            var index = 0;
            var nodes = _xmlHelper.GetNode("/publish").ChildNodes;

            for (var i = 0; i < nodes.Count; i++)
            {
                XmlNode node = nodes[i];

                var id = node.SelectSingleNode("./Id").InnerText;
                if (id == publishId)
                {
                    index = i + 1;
                    break;
                }
            }
            return index;
        }
    }
}