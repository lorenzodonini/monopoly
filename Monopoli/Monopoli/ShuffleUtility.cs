using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli
{
    public class ShuffleUtility
    {
        public static void Shuffle(object[] obj, int max)
        {
            int r;
            Random random = new Random();
            for (int i = 0; i < obj.Length; i++)
            {
                r = random.Next(max);
                Swap(obj, i, r);
            }
        }

        public static void Shuffle(System.Collections.IList obj)
        {
            int r;
            int max = obj.Count;
            Random random = new Random();
            for (int i = 0; i < max; i++)
            {
                r = random.Next(max);
                Swap(obj, i, r);
            }
        }

        private static void Swap(System.Collections.IList obj, int i, int r)
        {
            object temp = obj[i];
            obj[i] = obj[r];
            obj[r] = temp;
        }

        private static void Swap(object[] obj, int i, int r)
        {
            object temp = obj[i];
            obj[i] = obj[r];
            obj[r] = temp;
        }
    }
}
