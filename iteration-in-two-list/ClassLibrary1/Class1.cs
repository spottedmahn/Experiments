using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1
{
    public class Class1
    {
        public static List<Data> GetResults(List<Data> listTest1, List<Data> listTest2)
        {
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
