using RRStringConverter.Extensions;
using RRStringConverter.Helpers;

namespace RRStringConverter.Processors;

/// <summary>
/// Given the nature of the string to process with nested parentheses, a tree-like structure seems fitting.
/// This algorithm assumes that the input string is well-formed and that the parentheses are balanced but
/// the string doesn't necessarily need to start with '('.
/// </summary>
internal class TreeNodeProcessor : ICodeChallengeProcessor
{
    private readonly ICodeChallengeValidator _codeChallengeValidator;

    public string Name => nameof(TreeNodeProcessor);

    public TreeNodeProcessor(ICodeChallengeValidator codeChallengeValidator)
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
        var treeOutput = treeNode.GetTreeString(suppressRoot);

        return treeOutput;
    }
}
