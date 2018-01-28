using System;
using TextAnalyzer.Core;

namespace UserApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Реализовать программу анализа текста. Входной текст произвольный и может быть большим по объему. "
               + "Количество и содержание метрик определяется самостоятельно. Требования к алгоритму: Программа должна быть "
               + "расширяема к изменению списку метрик. Масштабируемость. Метрики можете предлагать самостоятельно, например "
               + "самый частый символ или количество восклицательных предложений. Процент существительных слов в тексте и т.д";
            
            TextProcessor myTextProcessor = new TextProcessor(text);

            Console.WriteLine("Text has " + 
                myTextProcessor.CountAllChars()
            + " letters");

            char searchChar = 'р';
            Console.WriteLine("Text contains " +
                myTextProcessor.CountChar(searchChar)
            + " letter(s) " + "\"" + searchChar + "\"");

            myTextProcessor.Text = "How you doing?";
            Console.WriteLine("Text changed. New text \"" + myTextProcessor.Text + "\"");

            Console.WriteLine("Text contains " +
                myTextProcessor.CountQuestionSentence()
            + " question sentence");

            Console.WriteLine("\"" +
                myTextProcessor.MostPopularChar()
            + "\" is the most popular letter");

            var words = myTextProcessor.CountEachWord();

            Console.WriteLine("Text contains:");
            foreach (var word in words)
            {
                Console.WriteLine(
                    word.Key + " - " + word.Value
                    );
            }

            Console.Read();
        }
    }
}