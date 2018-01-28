using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

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
            int expected = TEST_TEXT.Length;

            //act
            var actual = this._textProcessor.CountAllChars();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountChar_Valid_TheSameCount()
        {
            //arrange
            char searchChar = 't';
            int expected = 2;

            //act
            var actual = this._textProcessor.CountChar(searchChar);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountQuestionSentence_Valid_TheSameCount()
        {
            //arrange
            int expected = 0;

            //act
            var actual = this._textProcessor.CountQuestionSentence();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MostPopularChar_Valid_TheSameChar()
        {
            //arrange
            char expected = 't';

            //act
            var actual = this._textProcessor.MostPopularChar();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountEachWord_Valid_TheSameCount()
        {
            //arrange
            var expected = new Dictionary<string, int>();
            expected.Add(TEST_TEXT, 1);

            //act
            var actual = this._textProcessor.CountEachWord();

            //assert
            Assert.IsTrue(expected.Count == actual.Count);

            foreach (KeyValuePair<string, int> item in actual)
            {
                Assert.IsTrue(item.Value == expected[item.Key]);
            }
        }

        [TestMethod]
        public void ChangeText_Valid_TheSameText()
        {
            //arrange
            string expected = "new";

            //act
            this._textProcessor.ChangeText(expected);

            //assert
            string actual = this._textProcessor.GetText();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateObjectWithTextNullOrEmpty_Valid_Exception()
        {
            TextProcessor actual = new TextProcessor(null);
        }
    }
}