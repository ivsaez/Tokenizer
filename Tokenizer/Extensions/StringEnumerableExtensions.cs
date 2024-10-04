using Languager;

namespace Tokenizer.Extensions
{
    public static class StringEnumerableExtensions
    {
        private static readonly Dictionary<Language, HashSet<string>> languagedArticles = new Dictionary<Language, HashSet<string>>
        {
            [Language.ES] = new HashSet<string>
            {
                "el",
                "la",
                "los",
                "las",
                "un",
                "uno",
                "una",
                "unos",
                "unas",
                "lo",
                "al",
                "del",
            },
            [Language.EN] = new HashSet<string>
            {
                "a",
                "an",
                "the"
            },
            [Language.CAT] = new HashSet<string>
            {
                "el",
                "la",
                "els",
                "les",
                "un",
                "una",
                "uns",
                "unes",
                "en",
                "na"
            }
        };

        private static readonly Dictionary<Language, HashSet<string>> languagedPrepositions = new Dictionary<Language, HashSet<string>>
        {
            [Language.ES] = new HashSet<string>
            {
                "a",
                "ante",
                "bajo",
                "cabe",
                "con",
                "contra",
                "de",
                "desde",
                "durante",
                "en",
                "entre",
                "hacia",
                "hasta",
                "mediante",
                "para",
                "por",
                "segun",
                "sin",
                "so",
                "sobre",
                "tras",
                "versus",
                "via",
            },
            [Language.EN] = new HashSet<string>
            {
                "about",
                "above",
                "across",
                "after",
                "against",
                "along",
                "among",
                "around",
                "as",
                "at",
                "before",
                "behind",
                "below",
                "beneath",
                "beside",
                "between",
                "beyond",
                "by",
                "despite",
                "down",
                "during",
                "except",
                "for",
                "from",
                "in",
                "inside",
                "into",
                "near",
                "of",
                "off",
                "on",
                "onto",
                "opposite",
                "out",
                "outside",
                "over",
                "past",
                "round",
                "since",
                "than",
                "through",
                "to",
                "towards",
                "under",
                "underneath",
                "until",
                "up",
                "upon",
                "via",
                "with",
                "within",
                "without"
            },
            [Language.CAT] = new HashSet<string>
            {
                "a",
                "amb",
                "arran",
                "cap",
                "contra",
                "dalt",
                "damunt",
                "davall",
                "de",
                "deca",
                "della",
                "des",
                "devers",
                "devora",
                "dintre",
                "durant",
                "en",
                "entre",
                "envers",
                "excepte",
                "fins",
                "llevat",
                "malgrat",
                "mitjancant",
                "per",
                "pro",
                "salvant",
                "salvat",
                "segons",
                "sens",
                "sense",
                "sobre",
                "sota",
                "sots",
                "tret",
                "ultra",
                "via"
            }
        };

        public static IEnumerable<string> RemoveEmpty(this IEnumerable<string> list) =>
            list
                .Where(item => !string.IsNullOrWhiteSpace(item))
                .ToList();

        public static IEnumerable<string> RemoveNonImportantWords(this IEnumerable<string> words, Language language) =>
            words
                .Where(word => !languagedArticles[language].Contains(word) && !languagedPrepositions[language].Contains(word))
                .ToList();
    }
}

