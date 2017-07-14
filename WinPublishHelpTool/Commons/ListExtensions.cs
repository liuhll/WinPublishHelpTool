using System.Collections.Generic;
using System.Text;

namespace WinPublishHelpTool.Commons
{
    public static class ListExtensions
    {
        public static string ToSplitString<T>(this IList<T> list, string split)
        {
            var sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.Append(item + split);
            }
            return sb.Remove(sb.Length - split.Length, split.Length).ToString();
        }
    }
}