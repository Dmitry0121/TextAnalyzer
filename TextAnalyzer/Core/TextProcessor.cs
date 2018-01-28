using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalyzer.Core
{
    public class TextProcessor
    {
        private string _text;
        
        public string Text
        {
            get
            {
                return this._text;
            }
            set
            {
                this._text = value;
            }
        }

        public TextProcessor(string pText)
        {
            this._text = pText;
        }

        #region public methods of analysis
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
            try
            {
                return this._text
                    .ToLower()
                    .GroupBy(c => c)
                    .OrderByDescending(g => g.Count())
                    .First()
                    .Key;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
        #endregion

        #region private methods
        private string[] GetArrayWords(string pText)
        {
            return pText
                .ToLower()
                .Split(" ,.:;+-*?!\'()\"".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }
        #endregion
    }
}