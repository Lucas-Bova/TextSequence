using System;
using System.Collections.Generic;
using System.Text;

namespace SearchSequence
{
    static class AllIndexes
    {
        public static IEnumerable<int> AllIndexesOf(this string str, string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("The string to find must not be empty", "value");
            }
            for (int index = 0; ; index += 1)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                {
                    break;
                }
                yield return index;
            }
        }
    }
}
