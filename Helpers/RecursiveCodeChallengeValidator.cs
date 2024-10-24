namespace RRStringConverter.Helpers
{
    // For validity, this treats the input string like a function call that contains parameters or
    // other function calls. It's a recursive approach that will check for balanced parentheses
    // and proper comma separation.
    internal class RecursiveCodeChallengeValidator : ICodeChallengeValidator
    {
        private string? _inputToParse;
        private int _index;
        public bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;       
            }

            // for some simplicity, just remove whitespace, though we could account for it during recursion
            _inputToParse = input.Replace(" ", string.Empty);

            if (!_inputToParse.StartsWith('('))
            {
                return false;
            }
            _index = 1; // cause we know the first spot is '('

            if (!ParseParameters())
            {
                return false;
            }

            // We got through all the parameters, so expect ')' is at the
            // end of the string without any other surprises.
            return _inputToParse.EndsWith(')') && _index == _inputToParse.Length - 1;
        }

        private bool ParseParameters()
        {
            // Check the spot we're at is a proper parameter
            // If that's good check for a comma and if one is there, check the next parameter.
            // We assume here that there aren't empty parentheses, so we don't check for that.

            if (!ParseParameter())
            {
                return false;
            }

            while (IndexSpotIsGood && _inputToParse[_index] == ',')
            {
                _index++; // move past the comma to an expected parameter
                if (!ParseParameter())
                {
                    return false;
                }
            }

            // Nice, we made it through that block of parameters
            return true;
        }

        private bool ParseParameter()
        {
            // game over if we expect a parameter and we're at the end of the string
            if (!IndexSpotIsGood)
            {
                return false;
            }

            if (char.IsLetterOrDigit(_inputToParse[_index])) // could make this a letter only check to not start with numbers
            {
                _index++; // we just verified we at a letter or digit, so move on
                while (IndexSpotIsGood && char.IsLetterOrDigit(_inputToParse[_index]))
                {
                    _index++;
                }

                // now that we got through the parameter name, check if we have a nested scenario
                if (IndexSpotIsGood && _inputToParse[_index] == '(')
                {
                    _index++; // move past the '('

                    // recurse into the next batch of parameters
                    if (!ParseParameters())
                    {
                        return false;
                    }

                    // check for the closing ')' and move past it
                    if (!IndexSpotIsGood || _inputToParse[_index] != ')')
                    {
                        return false;
                    }
                    _index++;
                }

                return true;
            }
            
            return false;
        }

        private bool IndexSpotIsGood => _index < _inputToParse.Length;
    }
}
