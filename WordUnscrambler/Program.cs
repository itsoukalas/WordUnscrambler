using System;
using System.Collections.Generic;
using System.Linq;
using WordUnscrambler.Data;
using WordUnscrambler.Workers;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        private const string wordListFileName = "wordlist.txt";
        static void Main(string[] args)
        {
            try
            {
                bool continueWordUnscrable = true;
                do
                {
                    Console.WriteLine("Please enter the option -F for file and M for Manual");
                    var option = Console.ReadLine() ?? string.Empty;

                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.WriteLine("Enter scrabled words file name: ");
                            ExecuteScrabledWordsInFileScenario();
                            break;
                        case Constants.Manual:
                            Console.WriteLine("Enter scrabled words manually ");
                            ExecuteScrabledWordsManuallyEntryScenarion();
                            break;
                        default:
                            Console.WriteLine("Option was not regognized.");
                            break;
                    }
                    var continueDecision = string.Empty;
                    do
                    {
                        Console.WriteLine("Do you want to continue? Y/N");
                        continueDecision = (Console.ReadLine() ?? string.Empty);
                    } while
                    (
                    !continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase)
                    &&
                    !continueDecision.Equals("N", StringComparison.OrdinalIgnoreCase)
                    );

                    continueWordUnscrable = continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);

                } while (continueWordUnscrable);

            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorProgramWillBeTerminated + ex.Message);
            }
            
        }
        

        private static void ExecuteScrabledWordsManuallyEntryScenarion()
        {
            try
            {

                var manualInput = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = manualInput.Split(',');
                DisplayMathedUnscramledWords(scrambledWords);
            }
            catch (Exception ex)
            {

                Console.WriteLine(Constants.ErrorScrabledWordsCannotBeLoad + ex.Message);
            }

        }


        private static void ExecuteScrabledWordsInFileScenario()
        {
            var filename = Console.ReadLine() ?? string.Empty;
            string[] scrabledWords = _fileReader.Read(filename);
            DisplayMathedUnscramledWords(scrabledWords);
        }

        private static void DisplayMathedUnscramledWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(wordListFileName);
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords,wordList);
            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine("Match found for {0} : {1}", matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else 
            {
                Console.WriteLine(Constants.MatchNotFound);
            }
        }
    }
}
   