using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordUnscrambler.Data;

namespace WordUnscrambler.Workers
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrabledWords, string[] wordList)
        {
            var matchedWords = new List<MatchedWord>();
            foreach (var scrabledWord in scrabledWords)
            {
                foreach (var word in wordList)
                {
                    if (scrabledWord.Equals(word, StringComparison.OrdinalIgnoreCase)) 
                    {
                        matchedWords.Add(BuildMatchedWord(scrabledWord, word));
                    }
                    else 
                    {
                        var scrambledWordArray = scrabledWord.ToCharArray();
                        var wordArray = word.ToCharArray();

                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                        var sortedScrambledWord = new string(scrambledWordArray);
                        var sortedWord = new string(wordArray);

                        if (sortedScrambledWord.Equals(sortedWord,StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWord(scrabledWord, word));
                        }
                    }
                }
            }
            return matchedWords;
        }

        private MatchedWord BuildMatchedWord(string scrabledWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord
            { 
            ScrambledWord=scrabledWord,
            Word=word
            };

            return matchedWord;
        }
    }
}
