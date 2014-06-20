using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RegularExpress
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("................................Find2........................");
            Find2();
            Console.WriteLine("................................Find1........................");
            Find1();
            Console.WriteLine("................................Find3........................");
            Find3();
            Console.ReadKey();
        }
        static void Find2()
        {
            const string text = "this is a good job, this is not a good job";
            const string pattern = @"\bth\S*";
            // pattern =@"\bn" 表示以n开头的字符串
            //pattern =@"icon\b" 表示以icon结尾的字符串
            MatchCollection m = Regex.Matches(text, pattern,RegexOptions.IgnoreCase);
            foreach (Match nextMatch in m)
            {
                Console.WriteLine(nextMatch.Index);
                Console.WriteLine(nextMatch.Value);
                Console.WriteLine(nextMatch.ToString());
            }
        }
        static void Find1()
        {
            const string text = @"XML has made a major impact in almost every aspect of 
            software development. Designed as an open, extensible, self-describing 
            language, it has become the standard for data and document delivery on 
            the web. The panoply of XML-related technologies continues to develop 
            at breakneck speed, to enable validation, navigation, transformation, 
            linking, querying, description, and messaging of data.";
            const string pattern = @"\bn\S*ion\b";
            //表示以n开头，以ion结尾.S表示任何不是空白字符的字符
            // \S* 表示不是空白的任意字符。
            MatchCollection matches = Regex.Matches(text, pattern,
               RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace |
               RegexOptions.ExplicitCapture);
            WriteMatches(text, matches);
        }
        static void Find3()
        {
            const string text = @"XML has made a major impact in almost every aspect of 
            software development. Designed as an open, extensible, self-describing 
            language, it has become the standard for data and document delivery on 
            the web. The panoply of XML-related technologies continues to develop 
            at breakneck speed, to enable validation, navigation, transformation, 
            linking, querying, description, and messaging of data.";
            const string pattern = @"\bn";
            MatchCollection matches = Regex.Matches(text, pattern,
              RegexOptions.IgnoreCase);
            WriteMatches(text, matches);
        }

        static void WriteMatches(string text, MatchCollection matches)
        {
            Console.WriteLine("Original text was: \n\n" + text + "\n");
            Console.WriteLine("No. of matches: " + matches.Count);
            foreach (Match nextMatch in matches)
            {
                int index = nextMatch.Index;
                string result = nextMatch.ToString();
                int charsBefore = (index < 5) ? index : 5;
                int fromEnd = text.Length - index - result.Length;
                int charsAfter = (fromEnd < 5) ? fromEnd : 5;
                int charsToDisplay = charsBefore + charsAfter + result.Length;

                Console.WriteLine("Index: {0}, \tString: {1}, \t{2}",
                   index, result,
                   text.Substring(index - charsBefore, charsToDisplay));

            }
        }
    }
}
