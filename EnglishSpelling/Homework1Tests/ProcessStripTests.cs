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
    public class ProcessStripTests
    {
        ProcessStrip _processStrip = new ProcessStrip();

        //Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _processStrip.ResetTimerLabel();
            _processStrip.ResetProgressBar();
            _processStrip.ResetScore();
        }

        //ProcessStripTest
        [TestMethod()]
        public void ProcessStripTest()
        {
            Assert.Fail();
        }

        //TickTimerTest
        [TestMethod()]
        public void TickTimerTest()
        {
            Assert.Fail();
        }

        //ResetTimerLabelTest
        [TestMethod()]
        public void ResetTimerLabelTest()
        {
            Assert.Fail();
        }

        //ResetProgressBarTest
        [TestMethod()]
        public void ResetProgressBarTest()
        {
            Assert.Fail();
        }

        //ResetScoreTest
        [TestMethod()]
        public void ResetScoreTest()
        {
            Assert.Fail();
        }

        //GetTimerLabelTest
        [TestMethod()]
        public void GetTimerLabelTest()
        {
            Assert.AreEqual(_processStrip.GetTimerLabel(), "00:00:20");
        }

        //SetMistakeCountTest
        [TestMethod()]
        public void SetMistakeCountTest()
        {
            _processStrip.SetMistakeCount();
            Assert.AreEqual(_processStrip.GetMistakeCountUnitTest(), 1);
        }

        //SetIsTimeOverTest
        [TestMethod()]
        public void SetIsTimeOverTest()
        {
            _processStrip.SetIsTimeOver();
            Assert.AreEqual(_processStrip.IsTimeOver(), false);
            _processStrip.SetTimerLabelUnitTest(0);
            _processStrip.SetIsTimeOver();
            Assert.AreEqual(_processStrip.IsTimeOver(), true);
        }

        //IsTimeOverTest
        [TestMethod()]
        public void IsTimeOverTest()
        {
            Assert.AreEqual(_processStrip.IsTimeOver(), false);
        }

        //GetProgressBarValueTest
        [TestMethod()]
        public void GetProgressBarValueTest()
        {
            Assert.AreEqual(_processStrip.GetProgressBarValue(), 100);
        }

        //SetProgressBarValueTest
        [TestMethod()]
        public void SetProgressBarValueTest()
        {
            _processStrip.SetProgressBarValue();
            _processStrip.TickTimer();
            Assert.AreEqual(_processStrip.GetProgressBarValue(), 80);
            _processStrip.SetProgressBarUnitTest(0);
            _processStrip.SetProgressBarValue();
            Assert.AreEqual(_processStrip.GetProgressBarValue(), 90);
        }

        //SetScoreTest
        [TestMethod()]
        public void SetScoreTest()
        {
            _processStrip.SetScore(10, 0);
            Assert.AreEqual(_processStrip.GetScore(), "Score:0");
        }

        //GetScoreTest
        [TestMethod()]
        public void GetScoreTest()
        {
            Assert.AreEqual(_processStrip.GetScore(), "Score:0");
        }

        //InitializeTest
        [TestMethod()]
        public void InitializeTest()
        {
            Assert.Fail();
        }
    }
}