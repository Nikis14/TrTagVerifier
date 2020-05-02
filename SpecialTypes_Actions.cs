using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programm
{
    public class MyTuple<T1, T2>
    {
        public T1 Item1;
        public T2 Item2;

        public MyTuple(T1 val1, T2 val2)
        {
            Item1 = val1;
            Item2 = val2;
        }
        public MyTuple()
        {

        }
    }

    public class SpecialActions
    {
        public static Dictionary<string, MyTuple<List<string>, int>> copy_dictionaries(ref Dictionary<string, MyTuple<List<string>, int>> d)
        {
            Dictionary<string, MyTuple<List<string>, int>> res = new Dictionary<string, MyTuple<List<string>, int>>();
            foreach (KeyValuePair<string, MyTuple<List<string>, int>> pair in d)
            {
                res.Add(pair.Key, new MyTuple<List<string>, int>(pair.Value.Item1, pair.Value.Item2));
            }
            return res;
        }
    }
}
