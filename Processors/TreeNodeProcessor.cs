﻿using RRStringConverter.Extensions;
using RRStringConverter.Helpers;

namespace RRStringConverter.Processors;

/// <summary>
/// Given the nature of the string to process with nested parentheses, a tree-like structure seems fitting.
/// This algorithm assumes that the input string is well-formed and that the parentheses are balanced but
/// the string doesn't necessarily need to start with '('.
/// </summary>
internal class TreeNodeProcessor : ICodeChallengeProcessor
{
    public string Name => nameof(TreeNodeProcessor);

    public string ConvertString(string input)
    {
        bool suppressRoot = input.StartsWith('(');
        var treeNode = TreeNodeHelper.BuildTree(input);
        var treeOutput = treeNode.GetTreeString(suppressRoot);

        return treeOutput;
    }
}
