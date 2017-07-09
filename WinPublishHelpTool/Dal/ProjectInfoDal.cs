using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using WinPublishHelpTool.Models;
using WinPublishHelpTool.Tools;

namespace WinPublishHelpTool.Dal
{
    public class ProjectInfoDal
    {
        private readonly XmlHelper _xmlHelper;
        private IList<ProjectInfo> _projectInfos;
      
        public ProjectInfoDal()
        {

            _xmlHelper = new XmlHelper(AppDomain.CurrentDomain.BaseDirectory + "./Datas/ProjectDatas.xml");
           // LoadDatas();
        }

        private void LoadDatas()
        {
           _projectInfos = new List<ProjectInfo>();
           var nodes = _xmlHelper.GetNode("/projects").ChildNodes;
            foreach (XmlNode node in nodes)
            {
                var projectInfo = new ProjectInfo()
                {
                    Id = node.SelectSingleNode("./Id").InnerText,
                    ProjectName = node.SelectSingleNode("./ProjectName").InnerText,
                    DestDirectory = node.SelectSingleNode("./DestDirectory").InnerText,
                    SourceDirectory = node.SelectSingleNode("./SourceDirectory").InnerText,
                };
                _projectInfos.Add(projectInfo);
               
            }
        }


        private int GetProjectIndexById(string projectId)
        {
            var index = 0;
            var nodes = _xmlHelper.GetNode("/projects").ChildNodes;

            for (var i = 0; i < nodes.Count; i++)
            {
                XmlNode node = nodes[i];
               
                var id = node.SelectSingleNode("./Id").InnerText;
                if (id == projectId)
                {
                    index = i + 1;
                    break;
                }
            }
            return index;

        }

        public IList<ProjectInfo> GetAllProjectInfos()
        {
            LoadDatas();
            return _projectInfos;
        }

        public bool IsExistProjectConfig(string projectName)
        {
            LoadDatas();
            return _projectInfos.FirstOrDefault(p => p.ProjectName == projectName) != null;
        }

        public bool InsertProjectInfoConfig(ProjectInfo projectInfo)
        {
            var xmlNode = _xmlHelper.SerializeXmlNode(projectInfo);
            _xmlHelper.AppendNode(xmlNode);
            _xmlHelper.Save();
            return true;
        }

        public ProjectInfo GetProjectInfoByName(string projectName)
        {
            LoadDatas();
            return _projectInfos.SingleOrDefault(p => p.ProjectName == projectName);
        }

        public ProjectInfo GetProjectInfoById(string projectId)
        {
            LoadDatas();
            return _projectInfos.SingleOrDefault(p => p.Id == projectId);
        }

        public void Remove(string projectId)
        {
            var index = GetProjectIndexById(projectId);

            _xmlHelper.RemoveNode(string.Format("/projects/ProjectInfo[{0}]", index));
            _xmlHelper.Save();
        }

        public bool IsNeedUpdate(ProjectInfo newProjectInfo, ProjectInfo existProjectInfo)
        {
            if (newProjectInfo.DestDirectory != existProjectInfo.DestDirectory || newProjectInfo.SourceDirectory != existProjectInfo.SourceDirectory)
            {
                return true;
            }
            return false;
        }

        public void UpdateProjectInfo(ProjectInfo newProjectInfo)
        {
            Remove(newProjectInfo.Id);
            InsertProjectInfoConfig(newProjectInfo);

        }
    }
}