using RRStringConverter.Extensions;
using RRStringConverter.Helpers;

namespace RRStringConverter.Processors;

/// <summary>
/// For this one, we can use the same structure as TreeNodeProcessor (consolidated to a helper)
/// and sort using an extension method though it could be internal to this class. 
/// </summary>
internal class SortedTreeNodeProcessor : ICodeChallengeProcessor
{
    public string Name => nameof(SortedTreeNodeProcessor);

    public string ConvertString(string input)
    {
        bool suppressRoot = input.StartsWith('(');
        var treeNode = TreeNodeHelper.BuildTree(input);
        treeNode.SortTree();
        var treeOutput = treeNode.GetTreeString(suppressRoot);

        return treeOutput;
    }
}
