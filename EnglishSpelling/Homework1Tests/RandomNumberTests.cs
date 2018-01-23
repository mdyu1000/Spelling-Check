using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.Tests
{
    //RandomNumberTests
    [TestClass()]
    public class RandomNumberTests
    {
        RandomNumber _randomNumber = new RandomNumber(10, true);
        RandomNumber _randomNumberPlus = new RandomNumber(10, false);

        //Initialize
        [TestInitialize()]
        public void Initialize()
        {
        }

        //RandomNumberTest
        [TestMethod()]
        public void RandomNumberTest()
        {
            Assert.Fail();
        }

        //SetWrongQuestionThreeTest
        [TestMethod()]
        public void SetWrongQuestionThreeTest()
        {
            Assert.Fail();
        }

        //SetWrongQuestionThreePartTwoTest
        [TestMethod()]
        public void SetWrongQuestionThreePartTwoTest()
        {
            _randomNumber.SetWrongQuestionThreePartTwo(0);
            Assert.AreEqual(_randomNumber.GetDashNumber(), 993);
        }

        //GetRandomTest
        [TestMethod()]
        public void GetRandomTest()
        {
            Assert.AreEqual(_randomNumber.GetRandom(0), 248);
            Assert.AreEqual(_randomNumber.GetRandom(1), 110);
            Assert.AreEqual(_randomNumber.GetRandom(2), 467);
            Assert.AreEqual(_randomNumber.GetRandom(3), 771);
            Assert.AreEqual(_randomNumber.GetRandom(4), 657);
            Assert.AreEqual(_randomNumber.GetRandom(5), 432);
            Assert.AreEqual(_randomNumber.GetRandom(6), 354);
            Assert.AreEqual(_randomNumber.GetRandom(7), 943);
            Assert.AreEqual(_randomNumber.GetRandom(8), 101);
            Assert.AreEqual(_randomNumber.GetRandom(9), 642);
        }

        //GetWrongQuestionNumberTest
        [TestMethod()]
        public void GetWrongQuestionNumberTest()
        {
            Assert.AreEqual(_randomNumber.GetWrongQuestionNumber(0), 514);
        }

        //GetQuestionPatternTest
        [TestMethod()]
        public void GetQuestionPatternTest()
        {
            Assert.AreEqual(_randomNumber.GetQuestionPattern(), 1);
        }

        //GetRealQuestionNumberTest
        [TestMethod()]
        public void GetRealQuestionNumberTest()
        {
            Assert.AreEqual(_randomNumber.GetRealQuestionNumber(), 3);
        }

        //IsConflictPatternTwoTest
        [TestMethod()]
        public void IsConflictPatternTwoTest()
        {
            Assert.AreEqual(_randomNumber.IsConflictPatternTwo(-1, 0), true);
            Assert.AreEqual(_randomNumber.IsConflictPatternTwo(514, 0), true);
        }

        //CheckRepeatPatternOneTest
        [TestMethod()]
        public void CheckRepeatPatternOneTest()
        {
            List<int> test = new List<int>();
            test.Add(248);
            test.Add(110);
            test.Add(467);
            test.Add(771);
            test.Add(657);
            test.Add(432);
            test.Add(354);
            test.Add(943);
            test.Add(101);
            test.Add(642);
            test.Add(6969);
            _randomNumber.CheckRepeatPatternOne(test);
            Assert.AreEqual(_randomNumber.GetRandom(0), 248);
        }

    }
}