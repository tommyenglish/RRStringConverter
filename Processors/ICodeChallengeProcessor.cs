namespace RRStringConverter.Processors;

internal interface ICodeChallengeProcessor
{
    string Name { get; }
    string ConvertString(string input);
}
