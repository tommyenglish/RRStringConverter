using System.Text;
using RRStringConverter.Models;

namespace RRStringConverter.Extensions
{
    internal static class TreeNodeExtensions
    {
        const string SPACER = "  ";

        public static string GetTreeString<T>(this TreeNode<T> node, bool suppressRoot, string indent = "")
        {
            var sb = new StringBuilder();
            if (!suppressRoot)
            {
                sb.AppendLine($"{indent}- {node.Value}");
                indent += SPACER;
            }

            foreach (var child in node.Children)
            {
                sb.Append(child.GetTreeString(suppressRoot: false, indent));
            }

            return sb.ToString();
        }
    }
}
