﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using ClassLibrary1;
using ClassLibrary2;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OnlyIn1()
        {
            //arrange
            var testOnlyIn1 = new Data() { Abbrv = "OnlyIn1", Date = new DateTime(2017, 1, 1), Desc = "From1" };
            var listTest1 = new List<Data> { testOnlyIn1 };
            var listTest2 = new List<Data>();

            //act
            var res = Class1.GetResults(listTest1, listTest2);

            //assert
            //If the abbrv from listTest1 doesn't exist in listTest2 I am adding the record from listTest1 to listTest3.
            var expected = new List<Data> {
                new Data{ Abbrv="OnlyIn1", Date = new DateTime(2017, 1, 1), Desc = "From1"  }
            };

            //https://stackoverflow.com/questions/11055632/how-to-compare-lists-in-unit-testing
            CollectionAssert.AreEqual(res, expected);
        }

        [TestMethod]
        public void FullTest()
        {
            //arrange
            var listTest1 = GetTest1Data();
            var listTest2 = GetTest2Data();

            //act
            var res = Class1.GetResults(listTest1, listTest2);

            //assert
            //If the abbrv and the date is the same I am adding the object from listTest2 to listTest3
            //If the abbrv is the same but the date is different I am adding the object from listTest2 to listTest3 and I am switching the completed property to true.In addition, I am adding the record from listTest1 to listTest3.
            //If the abbrv from listTest1 doesn't exist in listTest2 I am adding the record from listTest1 to listTest3.
            //If the abbrv from listTest2 doesnt exist in listTest2.I am adding the record from listTest2 to listTest2
            var expected = new List<Data> { new Data { Abbrv = "InBothSameDate", Date = new DateTime(2017, 11, 12), Desc = "From2" },
                new Data{ Abbrv="InBothDifferentDate", Date = new DateTime(2017, 12, 12), Desc = "From2" },
                new Data{ Abbrv="OnlyIn1", Date = new DateTime(2017, 1, 1), Desc = "From1"  },
                new Data{ Abbrv="OnlyIn2", Date = new DateTime(2017, 1, 31), Desc = "From2"  }
            };

            //https://stackoverflow.com/questions/11055632/how-to-compare-lists-in-unit-testing
            CollectionAssert.AreEqual(res, expected);
        }

        private static List<Data> GetTest1Data()
        {
            var test1 = new Data() { Abbrv = "InBothSameDate", Date = new DateTime(2017, 11, 12), Desc = "From1" };
            var test2 = new Data() { Abbrv = "InBothDifferentDate", Date = new DateTime(2017, 12, 17), Desc = "From1" };
            //var test5 = new Data() { Abbrv = "InBothDifferentDate", Date = new DateTime(2017, 12, 12), Desc = "From1" };
            var testOnlyIn1 = new Data() { Abbrv = "OnlyIn1", Date = new DateTime(2017, 1, 1), Desc = "From1" };

            var listTest1 = new List<Data> { test1, test2, testOnlyIn1 };
            return listTest1;
        }

        private static List<Data> GetTest2Data()
        {
            var test3 = new Data() { Abbrv = "InBothSameDate", Date = new DateTime(2017, 11, 12), Desc = "From2" };
            var test4 = new Data() { Abbrv = "InBothDifferentDate", Date = new DateTime(2017, 12, 12), Desc = "From2" };
            //var test7 = new Data() { Abbrv = "InBothDifferentDate", Date = new DateTime(2017, 12, 18), Desc = "From2" };
            //var test6 = new Data() { Abbrv = "Test6", Date = new DateTime(2017, 12, 18), Desc = "From2" };
            var testOnlyIn2 = new Data() { Abbrv = "OnlyIn2", Date = new DateTime(2017, 1, 31), Desc = "From2" };

            var listTest2 = new List<Data> { test3, test4, testOnlyIn2 };
            return listTest2;
        }
    }
}
