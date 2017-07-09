using WinPublishHelpTool.Commons;

namespace WinPublishHelpTool.Models
{
    public class ProjectInfo
    {
        public string Id { get; set; }

        public string ProjectName { get; set; }

        public string SourceDirectory { get; set; }

        public string DestDirectory { get; set; }
    }
}