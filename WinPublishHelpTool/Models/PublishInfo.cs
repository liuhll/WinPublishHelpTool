using WinPublishHelpTool.Commons;
using WinPublishHelpTool.Dal;

namespace WinPublishHelpTool.Models
{
    public class PublishInfo
    {

        public string Id { get; set; }

        public string ProjectId { get; set; }

        [CustomeNoSerialize]
        public ProjectInfo ProjectInfo {
            get
            {
                return  new ProjectInfoDal().GetProjectInfoById(ProjectId);                
            }
        }

        [CustomeNoSerialize]
        public string ProjectName
        {
            get { return ProjectInfo.ProjectName; }
        }

        public string OptionType { get; set; }

        public string Version { get; set; }

        public string PublishDate { get; set; }

        public string BackUpDirectory { get; set; }

    }
}