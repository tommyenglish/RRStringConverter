namespace RRStringConverter.Helpers
{
    // This validator seems very complex if the input string has nested parentheses.
    // If we were assured it only had one level of nesting, it might be more feasible.
    // Going to try another approach first.
    internal class RegExCodeChallengeValidator : ICodeChallengeValidator
    {
        public bool IsValid(string input)
        {
            throw new NotImplementedException("Try something else dude, this validator is a no-go.");
        }
    }
}
