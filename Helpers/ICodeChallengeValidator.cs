namespace RRStringConverter.Helpers
{
    // Creating an interface to play around with different validation options
    internal interface ICodeChallengeValidator
    {
        bool IsValid(string input);
    }
}
