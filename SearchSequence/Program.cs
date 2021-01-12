using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using TextSequence;

namespace SearchSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            //goal is to get a sequence of text and search it for keywords
            var searchParms = new[] { "quick", "fox", "dog" };
            var filePath = "TestFile.txt";
            var data = GetStream(filePath);
            var result = new List<SearchResult>();
            foreach (var item in searchParms)
            {
                var indexes = data.AllIndexesOf(item);
                result.Add(new SearchResult { Term = item, Index = indexes.ToList() });
            }
            foreach (var item in result)
            {
                Console.WriteLine($"Term: {item.Term} - Index: {item.Index[item.Index.Count - 1]}");
            }
        }

        class SearchResult
        {
            public string Term { get; set; }
            public List<int> Index { get; set; }
        }

        private static string GetStream(string filePath)
        {
            using (var stream = new StreamReader(filePath))
            {
                return stream.ReadToEnd();
            }
        }
    }
}
