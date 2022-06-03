namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";
            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] inputLines = File.ReadAllLines(inputFilePath);
            int count = 0;
            List<string> outputFileTexts = new List<string>();
            foreach (var line in inputLines)
            {
                count++;
                int countLetters = line.Count(char.IsLetter);
                int countSymbols = line.Count(char.IsPunctuation);
                string newString = $"Line {count}: {line} ({countLetters})({countSymbols})";
                outputFileTexts.Add(newString);
            }
            File.WriteAllLines(outputFilePath, outputFileTexts);
        }
    }
}
