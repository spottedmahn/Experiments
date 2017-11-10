using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary2
{
    /// <summary>
    /// https://stackoverflow.com/questions/47222499/iteration-in-two-list
    /// </summary>
    public class Class1
    {
        /// <summary>
        /// If the abbrv and the date is the same I am adding the object from listTest2 to listTest3
        /// If the abbrv is the same but the date is different I am adding the object from listTest2 to listTest3 and I am switching the completed property to true.  In addition, I am adding the record from listTest1 to listTest3.
        /// If the abbrv from listTest1 doesn't exist in listTest2, I am adding the record from listTest1 to listTest3
        /// If the abbrv from listTest2 doesn't exist in listTest1, I am adding the record from listTest2 to listTest3
        /// </summary>
        /// <param name="listTest1"></param>
        /// <param name="listTest2"></param>
        /// <returns></returns>
        public static List<Data> GetResults(List<Data> listTest1, List<Data> listTest2)
        {
            //https://stackoverflow.com/questions/5489987/linq-full-outer-join
            var joined = listTest1.FullJoin(listTest2, key1 => key1.Abbrv,
                firstSelector => new Data
                {
                    Abbrv = firstSelector.Abbrv,
                    Date = firstSelector.Date,
                    Desc = firstSelector.Desc
                },
            secondSelector => new Data
            {
                Abbrv = secondSelector.Abbrv,
                Date = secondSelector.Date,
                Desc = secondSelector.Desc
            },
            (first, second) => new Data
            {
                Abbrv = second.Abbrv,
                Date = second.Date,
                Desc = second.Desc
            });

            var mem = joined.ToList();

            return mem;
        }
    }
}
