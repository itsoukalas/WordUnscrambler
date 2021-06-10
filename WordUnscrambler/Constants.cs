﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Constants
    {
        public const string OptionsOnHowToEnterScrambledWords = "Enter scrabled word(s) manually or as a file: F- file/M -manual";
        public const string OptionsOnContinuingTheProgram = "Would you like to continue? Y/N";

        public const string EnterScrabledWordsViaFile = "Enter full path including the file name: ";
        public const string EnterScrabledWordsManually = "Enter word(s) manually (separated by commas if multiple): ";
        public const string EnterScrabledWordsOptionNotRecognized = "The option was not recognized.";
        
        
        public const string ErrorScrabledWordsCannotBeLoad = "Scrambled words were not loaded becasue there was an error";
        public const string ErrorProgramWillBeTerminated = "The program will be terminated";

        
        public const string MatchFound = "MATCH FOUND FOR {0} : {1}";
        public const string MatchNotFound = "NO MATCHED HAVE BEEN FOUND";

        public const string Yes = "Y";
        public const string No = "N";
        public const string File = "F";
        public const string Manual = "M";

        private const string wordListFileName = "wordlist.txt";

    }
}
