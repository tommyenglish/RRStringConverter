using RRStringConverter.Extensions;
using RRStringConverter.Helpers;

namespace RRStringConverter.Processors;

/// <summary>
/// For this one, we can use the same structure as TreeNodeProcessor (consolidated to a helper)
/// and sort using an extension method though it could be internal to this class. 
/// </summary>
internal class SortedTreeNodeProcessor : ICodeChallengeProcessor
{
    private readonly ICodeChallengeValidator _codeChallengeValidator;

    public string Name => nameof(SortedTreeNodeProcessor);

    public SortedTreeNodeProcessor(ICodeChallengeValidator codeChallengeValidator)
    {
        _codeChallengeValidator = codeChallengeValidator;
    }

    public string ConvertString(string input)
    {
        // Just return an informative string for now, but would likely be an exception in a real implementation
        if (!_codeChallengeValidator.IsValid(input))
        {
            return "Invalid input";
        }

        bool suppressRoot = input.StartsWith('(');
        var treeNode = TreeNodeHelper.BuildTree(input);
        treeNode.SortTree();
        var treeOutput = treeNode.GetTreeString(suppressRoot);

        return treeOutput;
    }
}
