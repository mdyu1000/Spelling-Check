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
    public class ModelTests
    {
        Model _model = new Model();

        //Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model.Initialize(10, 0, true);
        }

        //InitializeTest
        [TestMethod()]
        public void InitializeTest()
        {
            Assert.Fail();
        }

        //GetGroupOneTextTest
        [TestMethod()]
        public void GetGroupOneTextTest()
        {
            Assert.AreEqual(_model.GetGroupOneText(), "Q0: Fill in Blanks");
        }

        //GetGroupTwoTextTest
        [TestMethod()]
        public void GetGroupTwoTextTest()
        {
            Assert.AreEqual(_model.GetGroupTwoText(), "Q0: Multiple Choice Question");
        }

        //GetQuestionPatternTest
        [TestMethod()]
        public void GetQuestionPatternTest()
        {
            Assert.AreEqual(_model.GetQuestionPattern(), 1);
        }

        //GetRealQuestionNumberTest
        [TestMethod()]
        public void GetRealQuestionNumberTest()
        {
            Assert.AreEqual(_model.GetRealQuestionNumber(), 2);
        }

        //SetCorrectNumberTest
        [TestMethod()]
        public void SetCorrectNumberTest()
        {
            _model.SetCorrectNumber();
            Assert.AreEqual(_model.GetCorrectNumber(), 1);
        }

        //GetCorrectNumberTest
        [TestMethod()]
        public void GetCorrectNumberTest()
        {
            Assert.AreEqual(_model.GetCorrectNumber(), 0);
        }

        //SetTotalNumberTest
        [TestMethod()]
        public void SetTotalNumberTest()
        {
            _model.SetTotalNumber();
            Assert.AreEqual(_model.GetTotalNumber(), 1);
        }

        //GetTotalNumberTest
        [TestMethod()]
        public void GetTotalNumberTest()
        {
            Assert.AreEqual(_model.GetTotalNumber(), 0);
        }

        //GetChineseTest
        [TestMethod()]
        public void GetChineseTest()
        {
            Assert.AreEqual(_model.GetChinese(), "[名]門 d__r (4)");
        }

        //GetEnglishTest
        [TestMethod()]
        public void GetEnglishTest()
        {
            Assert.AreEqual(_model.GetEnglish(), "door");
        }

        //GetPatternTwoChoiceTest
        [TestMethod()]
        public void GetPatternTwoChoiceTest()
        {
            Assert.AreEqual(_model.GetPatternTwoChoice(0), "[動]笑");
        }

        //GetConclusionTest
        [TestMethod()]
        public void GetConclusionTest()
        {
            _model.SetTotalNumber();
            _model.SetCompareInput("door", 2);
            Assert.AreEqual(_model.GetConclusion(), "Correct!!!");
            _model.SetTotalNumber();
            _model.SetCompareInput("door", 2);
            Assert.AreEqual(_model.GetConclusion(), "It should be both");
        }

        //SetCompareInputTest
        [TestMethod()]
        public void SetCompareInputTest()
        {
            _model.SetTotalNumber();
            _model.SetCompareInput("door", 2);
            Assert.AreEqual(_model.GetCompareInput(0), true);
            _model.SetCompareInput("test", 0);
            Assert.AreNotEqual(_model.GetCompareInput(0), false);
        }

        //GetCompareInputTest
        [TestMethod()]
        public void GetCompareInputTest()
        {
            _model.SetTotalNumber();
            _model.ClickNext("door", 2);
            Assert.AreEqual(_model.GetCompareInput(0), true);
        }

        //SetNumericUpDownNumberTest
        [TestMethod()]
        public void SetNumericUpDownNumberTest()
        {
            Assert.Fail();
        }

        //GetNumericUpDownNumberTest
        [TestMethod()]
        public void GetNumericUpDownNumberTest()
        {
            Assert.AreEqual(_model.GetNumericUpDownNumber(), 10);
        }

        //GetSelectedIndexTest
        [TestMethod()]
        public void GetSelectedIndexTest()
        {
            Assert.AreEqual(_model.GetSelectedIndex(), 0);
            _model.Initialize(10, 2, true);
            Assert.AreEqual(_model.GetSelectedIndex(), 1);
        }

        //GetMessageBoxShowTest
        [TestMethod()]
        public void GetMessageBoxShowTest()
        {
            string temp = "You pass 0 of 0 questions!!!" + "\n" + "\n" + "Error Answer：" + "\n" + "\n";
            Assert.AreEqual(_model.GetMessageBoxShow(), temp);
            _model.SetErrorAnswerUnitTest();
            Assert.AreEqual(_model.GetMessageBoxShow(), temp + "a [冠]一個;一種" + "\n" );
        }

        //ClickNextTest
        [TestMethod()]
        public void ClickNextTest()
        {
            _model.SetTotalNumber();
            _model.ClickNext("door", 2);
        }

        //IsEndOfGameTest
        [TestMethod()]
        public void IsEndOfGameTest()
        {
            Assert.AreEqual(_model.IsEndOfGame(), false);
            _model.SetTotalNumberUnitTest(10);
            Assert.AreEqual(_model.IsEndOfGame(), true);
        }

        //ModelTest
        [TestMethod()]
        public void ModelTest()
        {
            Assert.Fail();
        }

        //SetTotalNumberUnitTestTest
        [TestMethod()]
        public void SetTotalNumberUnitTestTest()
        {
            Assert.Fail();
        }

        //GetProgressBarValueTest
        [TestMethod()]
        public void GetProgressBarValueTest()
        {
            Assert.AreEqual(_model.GetProgressBarValue(), 100);
        }

        //GetScoreTest
        [TestMethod()]
        public void GetScoreTest()
        {
            Assert.AreEqual(_model.GetScore(), "Score:0");
        }

        //GetTimerLabel
        [TestMethod()]
        public void GetTimerLabel()
        {
            _model.TickTimer();
            Assert.AreEqual(_model.GetTimerLabel(), "00:00:19");
        }

        //IsTimeOverTest
        [TestMethod()]
        public void IsTimeOverTest()
        {
            Assert.AreEqual(_model.IsTimeOver(), false);
        }
    }
}