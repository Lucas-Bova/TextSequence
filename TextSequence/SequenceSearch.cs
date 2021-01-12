using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace TextSequence
{
    public static class SequenceSearch
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public static string FindSequences(this string data, int floor, int ceiling, int limit = 100)
        {
            var list = GetNGram(data, floor, ceiling);

            list.Sort();

            Sequences seq = GetSequences(list);

            seq.Groups.Sort((s, y) => y.OccuranceCount.CompareTo(s.OccuranceCount));


            seq.Groups = seq.Groups.Take(limit).ToList();


            var json = JsonConvert.SerializeObject(seq, Formatting.Indented);

            return json;

        }

        private static List<string> GetNGram(string vs, int floor, int ceiling)
        {
            //break the operation up into two sections
            var list = new List<string>();
            for (var i = floor; i <= ceiling; ++i)
            {
                for (var y = 0; y <= vs.Length - i; ++y)
                {
                    list.Add(vs.Substring(y, i));
                }
            }
            return list;
        }

        private static Sequences GetSequences(List<string> list)
        {
            Sequences sequences = new Sequences();
            while (list.Count() > 0)
            {
                var take = list.TakeWhile(x => x == list.FirstOrDefault());
                var sequence = new Sequence { Text = take.FirstOrDefault(), OccuranceCount = take.Count() };
                sequences.Groups.Add(sequence);
                list.RemoveRange(0, take.Count());
            }
            return sequences;
        }
    }
}
