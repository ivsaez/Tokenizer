using Tokenizer.Extensions;
using Languager;

namespace Tokenizer
{
    public class Tokens
    {
        private readonly ISet<string> tokens;

        public Tokens(string sentence, Language language)
        {
            tokens = new HashSet<string>(sentence
                .Simplify()
                .Split(' ')
                .RemoveEmpty()
                .RemoveNonImportantWords(language));
        }

        public bool HasIncluded(Tokens other)
        {
            if (!other.tokens.Any())
                return false;

            return other.tokens
                .All(inputToken => tokens
                    .Any(sentenceToken =>
                    {
                        if (inputToken.Length < 2)
                            return false;
                        else if (inputToken.Length == 2)
                            return sentenceToken == inputToken;
                        else
                            return sentenceToken == inputToken || sentenceToken.Contains(inputToken);
                    }));
        }


        public override string ToString() =>
            $"[{string.Join(" ", tokens)}]";
    }
}
