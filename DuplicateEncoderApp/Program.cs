using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateEncoderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string encode = "recede";
            Console.WriteLine( DuplicateEncode(encode) );
        }
        static string DuplicateEncode(string word)
        {
            List<int> duplicateLetterIndexes = new List<int>();
            bool foundDuplicate = false;
            for (int i = 0; i < word.Length; i++)
            {
                // grab a letter in the word
                string letter = word[i].ToString().ToLower();
                // loop throug the entire word and records index of letters 
                // which are repeating
                for (int j = 0; j < word.Length; j++)
                {
                    string letterToCheckAgainst = word[j].ToString().ToLower();
                    if (letter == letterToCheckAgainst && i != j)
                    {
                        // add the letter index to the list
                        if(!duplicateLetterIndexes.Contains(j))
                            duplicateLetterIndexes.Add(j);
                        foundDuplicate = true;
                    }
                }
                // Last add the letter which was being searched against
                if (!duplicateLetterIndexes.Contains(i) && foundDuplicate)
                    duplicateLetterIndexes.Add(i);
                // Remember to reset the found status
                foundDuplicate = false;
            }
            // Construct a new string
            string newString = "";
            for (int i = 0; i < word.Length; i++)
            {
                if (duplicateLetterIndexes.Contains(i))
                    newString += ")";
                else
                    newString += "(";
            }
            word = newString;
            return word;
        }
    }
}
