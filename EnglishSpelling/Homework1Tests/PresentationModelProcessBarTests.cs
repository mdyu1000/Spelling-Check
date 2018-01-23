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
    public class PresentationModelProcessBarTests
    {
        PresentationModelProcessBar _presentationModelProcessBar = new PresentationModelProcessBar();
        PresentationModelProcessBar _presentationModelProcessBarTwo;
        Model _model = new Model();
        //Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _presentationModelProcessBar.Initial();
            _presentationModelProcessBarTwo = new PresentationModelProcessBar(_model);
        }

        //PresentationModelProcessBarTest
        [TestMethod()]
        public void TestPresentationModelProcessBar()
        {
            Assert.Fail();
        }

        //InitialTest
        [TestMethod()]
        public void TestInitial()
        {
            Assert.Fail();
        }

        //IsTimerLabelVisibleTest
        [TestMethod()]
        public void IsTimerLabelVisibleTest()
        {
            Assert.AreEqual(_presentationModelProcessBar.IsTimerLabelVisible(), false);
            _presentationModelProcessBar.ClickStart();
            Assert.AreEqual(_presentationModelProcessBar.IsTimerLabelVisible(), true);
        }

        //IsTimerEnableTest
        [TestMethod()]
        public void IsTimerEnableTest()
        {
            Assert.AreEqual(_presentationModelProcessBar.IsTimerEnable(), false);
            _presentationModelProcessBar.ClickNext();
            Assert.AreEqual(_presentationModelProcessBar.IsTimerEnable(), true);
            _presentationModelProcessBar.ClickStop();
            Assert.AreEqual(_presentationModelProcessBar.IsTimerEnable(), false);
        }

        //IsProgressBarVisibleTest
        [TestMethod()]
        public void IsProgressBarVisibleTest()
        {
            Assert.AreEqual(_presentationModelProcessBar.IsProgressBarVisible(), false);
        }

        //IsScoreLabelVisibleTest
        [TestMethod()]
        public void IsScoreLabelVisibleTest()
        {
            Assert.AreEqual(_presentationModelProcessBar.IsScoreLabelVisible(), false);
        }

        //ClickStopTest
        [TestMethod()]
        public void ClickStopTest()
        {
            Assert.Fail();
        }

        //ClickStartTest
        [TestMethod()]
        public void ClickStartTest()
        {
            Assert.Fail();
        }

        //ClickNextTest
        [TestMethod()]
        public void ClickNextTest()
        {
            Assert.Fail();
        }

        //TickTimerTest
        [TestMethod()]
        public void TickTimerTest()
        {
            Assert.Fail();
        }

        //GetTimerLabelTest
        [TestMethod()]
        public void GetTimerLabelTest()
        {
            Assert.AreEqual(_presentationModelProcessBar.GetTimerLabel(), "00:00:20");
        }

        //IsTimeOverTest
        [TestMethod()]
        public void IsTimeOverTest()
        {
            Assert.AreEqual(_presentationModelProcessBar.IsTimeOver(), false);
        }

        //GetProgressBarValueTest
        [TestMethod()]
        public void GetProgressBarValueTest()
        {
            _presentationModelProcessBar.TickTimer();
            Assert.AreEqual(_presentationModelProcessBar.GetProgressBarValue(), 90);
        }

        //GetScoreTest
        [TestMethod()]
        public void GetScoreTest()
        {
            Assert.AreEqual(_presentationModelProcessBar.GetScore(), "Score:0");
        }
    }
}