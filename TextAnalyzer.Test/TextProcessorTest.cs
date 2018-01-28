using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextAnalyzer.Core;
using System.Collections.Generic;

namespace TextAnalyzer.Test
{
    [TestClass]
    public class TextProcessorTest
    {
        private const string TEST_TEXT = "test";
        private TextProcessor _textProcessor;

        [TestInitialize]
        public void Initialize()
        {
            this._textProcessor = new TextProcessor(TEST_TEXT);
        }

        [TestMethod]
        public void CountAllChars_Valid_TheSameCount()
        {
            //arrange
            int count = TEST_TEXT.Length;

            //act
            var result = this._textProcessor.CountAllChars();

            //assert
            Assert.AreEqual(count, result);
        }

        [TestMethod]
        public void CountChar_Valid_TheSameCountChar()
        {
            //arrange
            char searchChar = 't';
            int count = 2;

            //act
            var result = this._textProcessor.CountChar(searchChar);

            //assert
            Assert.AreEqual(count, result);
        }

        [TestMethod]
        public void CountQuestionSentence_Valid_TheSameCountQuestionSentence()
        {
            //arrange
            int count = 0;

            //actCountQuestionSentence
            var result = this._textProcessor.CountQuestionSentence();

            //assert
            Assert.AreEqual(count, result);
        }

        [TestMethod]
        public void MostPopularChar_Valid_TheSameCountMostPopularChar()
        {
            //arrange
            char MostPopularChar = 't';

            //act
            var result = this._textProcessor.MostPopularChar();

            //assert
            Assert.AreEqual(MostPopularChar, result);
        }

        [TestMethod]
        public void CountEachWord_Valid_TheSameCountEachWord()
        {
            //arrange
            var dictionary = new Dictionary<string, int>();
            dictionary.Add(TEST_TEXT, 1);

            //act
            var result = this._textProcessor.CountEachWord();

            //assert
            Assert.IsTrue(dictionary.Count == result.Count);

            foreach (KeyValuePair<string, int> keyValue in result)
            {
                Assert.IsTrue(keyValue.Value == dictionary[keyValue.Key]);
            }
        }    
    }
}