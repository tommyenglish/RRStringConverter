using System.Text;

namespace RRStringConverter.Processors;

/// <summary>
/// Just brute force the conversion from front to back, keying off parentheses to determine dashes and indents.
/// This algorithm assumes that the input string is well-formed and that the parentheses are balanced.
/// Assuming every string begins and ends with (), strip that and split the input string by commas (and space), 
/// then iterate over each item checking for parentheses to adjust the indent level for dash placement and
/// output the current item without parentheses.
/// Im thinking we'll have three cases when splitting if we remove outer parentheses initially: 
/// 1. normal item without parentheses -> item
/// 2. '(' inside the item denoting two items 
/// 3. One or more ')' at the end of the item
/// </summary>
internal class FrontToBackProcessor : ICodeChallengeProcessor
{
    // We'll add and remove spaces to this string to adjust the indent level
    private string _indent = string.Empty;
    const string SPACER = "  ";

    public string Name => nameof(FrontToBackProcessor);

    public string ConvertString(string input)
    {
        var sb = new StringBuilder();
        string truncatedInput = input[1..^1];
        var items = truncatedInput.Split(", ");

        foreach (var item in items)
        {
            if (item.Contains('(')) // '(' indicates two items needing to be split and adding to indent
            {
                int index = item.IndexOf('(');
                sb.AppendLine($"{_indent}- {item[..index]}");
                _indent += SPACER;
                sb.AppendLine($"{_indent}- {item[(index + 1)..]}");
            }
            else if (item.Contains(')')) // ')' indicates removing from indent for number of ')'
            {
                int index = item.IndexOf(')');
                sb.AppendLine($"{_indent}- {item[..index]}");

                int spacesToChop = item.Count(c => c == ')') * SPACER.Length;
                _indent = _indent[..^spacesToChop];
            }
            else
            {
                sb.AppendLine($"{_indent}- {item}");
            }
        }

        return sb.ToString();
    }
}
