using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalyzer
{
    public class TextProcessor
    {
        private string _text;
        
        public TextProcessor(string pText)
        {
            if (String.IsNullOrEmpty(pText))
            {
                throw new Exception("Text can not be empty or null");
            }
            
            this._text = pText;
        }

        public string GetText()
        {
            return this._text;
        }

        public void ChangeText(string pText)
        {
            this._text = pText;
        }

        //methods of analysis
        public int CountAllChars()
        {
            return this._text.Length;
        }

        public int CountChar(char pChar)
        {
            string upperText = this._text.ToUpper();
            int counter = 0;

            for (int i = 0; i < upperText.Length; i++)
            {
                if (upperText[i] == Char.ToUpper(pChar))
                {
                    counter++;
                }
            }

            return counter;
        }

        public int CountQuestionSentence()
        {
            char question = '?';
            return CountChar(question);
        }

        public char MostPopularChar()
        {
            return this._text
                .ToLower()
                .GroupBy(c => c)
                .OrderByDescending(g => g.Count())
                .First()
                .Key;
        }

        public Dictionary<string, int> CountEachWord()
        {
            string[] arrayWords = GetArrayWords(this._text);
            var dictionary = new Dictionary<string, int>();

            foreach (var word in arrayWords)
            {
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, 1);
                }
                else
                {
                    dictionary[word]++;
                }
            }

            return dictionary;
        }

        private string[] GetArrayWords(string pText)
        {
            return pText
                .ToLower()
                .Split(" ,.:;+-*?!\'()\"".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }
    }
}