namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int counter = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (counter % 2 == 0)
                    {
                        Console.WriteLine(ProcessLines(line));
                        counter++;
                        line = reader.ReadLine();
                    }
                    else
                    {
                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
        public static string ProcessLines(string line)
        {
            line = line.Replace("-", "@").Replace(",", "@").Replace(".", "@").Replace("!", "@").Replace("?", "@").ToString();
            line = String.Join(" ", line.Split().Reverse());
            return line;
        }
    }
}
