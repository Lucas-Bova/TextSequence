using System;
using System.Collections.Generic;
using System.Text;

namespace TextSequence
{
    class Sequences
    {
        private List<Sequence> groups;
        public List<Sequence> Groups
        {
            get
            {
                Count = groups.Count;
                return groups;
            }
            set
            {
                groups = value;
            }
        }
        public int Count { get; private set; }

        public Sequences()
        {
            Groups = new List<Sequence>();
        }
    }
}
