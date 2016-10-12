using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algrithm.Chain
{
    class SingleChain
    {
        /*
           1 --> 2 --> 3 --> 4 --> 5 --> 6 --> 7
        */
        public static ChainItem BuildSingleChain(int count)
        {
            if (count < 1) return null;

            int itemIndex = 0;
            ChainItem head = new ChainItem(itemIndex);
            itemIndex++;
            ChainItem lastItem = head;
            while (itemIndex < count)
            {
                ChainItem item = new ChainItem(itemIndex);
                itemIndex++;

                lastItem.Next = item;
                lastItem = item;
            }

            return head;
        }

        public static ChainItem Revert(ChainItem headItem)
        {
            ChainItem lastItem = headItem;
            ChainItem currentItem = lastItem.Next;
            lastItem.Next = null;

            while (currentItem != null)
            {
                ChainItem futureItem = currentItem.Next;
                currentItem.Next = lastItem;
                lastItem = currentItem;
                currentItem = futureItem;
            }

            return lastItem;
        }

        public static ChainItem RecursiveRevert( ChainItem headItem)
        {
            ChainItem reversedHeadItem = null;
            RecursiveRevertNextItem(headItem, ref reversedHeadItem);
            return reversedHeadItem;
        }

        private static ChainItem RecursiveRevertNextItem(ChainItem item, ref ChainItem reversedHeadItem)
        {
            if (item == null)
            {
                return item;
            }

            ChainItem nextItem = RecursiveRevertNextItem(item.Next, ref reversedHeadItem);
            if (nextItem != null)
            {
                nextItem.Next = item;
            }
            else
            {
                reversedHeadItem = item;
            }

            item.Next = null;
            return item ;
        }

        public static void ShowChain(ChainItem headItem)
        {
            ChainItem currentItem = headItem;
            while (currentItem != null)
            {
                Console.WriteLine(currentItem.Value);
                currentItem = currentItem.Next;
            }
        }
    }
}
