using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algrithm.Chain
{
    class ChainItem
    {
        public ChainItem(int value)
        {
            this.Value = value;
        }

        public int Value
        {
            get;
            set;
        }

        public ChainItem Next
        {
            get;
            set;
        }

        public ChainItem Prev
        {
            get;
            set;
        }
    }
}
