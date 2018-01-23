using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.Tests
{
    [TestClass()]
    public class WordTests
    {
        Word _word = new Word("test1", "test2", "test3");
        PrivateObject _target;

        //Initialize
        [TestInitialize()]
        //[DeploymentItem("Bank.exe")]
        public void Initialize()
        {
            _target = new PrivateObject(_word);
        }

        //WordTest
        [TestMethod()]
        public void WordTest()
        {
            Assert.Fail();
        }

        //GetChineseTest
        [TestMethod()]
        public void GetChineseTest()
        {
            Assert.AreEqual(_word.GetChinese(), "test1");
        }

        //GetEnglishTest
        [TestMethod()]
        public void GetEnglishTest()
        {
            Assert.AreEqual(_word.GetEnglish(), "test2");
        }

        //GetEnglishHideTest
        [TestMethod()]
        public void GetEnglishHideTest()
        {
            Assert.AreEqual(_word.GetEnglishHide(), "test3");
        }
    }
}