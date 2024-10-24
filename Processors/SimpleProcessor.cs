using System.Text;

namespace RRStringConverter.Processors;

/// <summary>
/// Had a thought for this processor when musing on a stack validator and all the popping and pushing.
/// When can simply go through the string and keep a counter for the indent level by adding to it when we see '('
/// and removing from it when we see ')'. When we come across a parameter name, we can add it to a list with
/// whatever indent level we're at. This is a pretty simple solution that doesn't require any stack or recursion 
/// and is O(n), but will have sorting challenges.
/// </summary>
internal class SimpleProcessor : ICodeChallengeProcessor
{
    const string SPACER = "  ";

    public string Name => nameof(SimpleProcessor);

    public string ConvertString(string input)
    {
        int _indentLevel = 0;
        var sb = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            var character = input[i];

            if (character == '(')
            {
                _indentLevel++;
            }
            else if (character == ')')
            {
                _indentLevel--;
            }
            else if (char.IsLetterOrDigit(character))
            {
                var sbParam = new StringBuilder();
                // get the whole name of the parameter
                while (char.IsLetterOrDigit(character))
                {
                    sbParam.Append(character);
                    i++;
                    character = input[i];
                }
                // we're at the end of the name, so back up one
                i--;

                // add it to the results
                sb.AppendLine($"{GetIndent(_indentLevel)}- {sbParam.ToString()}");
            }
            // ignore anything else like commas and spaces
        }

        return sb.ToString();
    }

    private static string GetIndent(int numIndents)
    {
        var sb = new StringBuilder();
        for (int i = 1; i < numIndents; i++)
        {
            sb.Append(SPACER);
        }

        return sb.ToString();
    }
}
