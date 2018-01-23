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
    public class PresentationModelToolStripTests
    {
        PresentationModelToolStrip _presentationModelToolStrip ;
        Model _model = new Model();
        //Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model.Initialize(10, 0, true);
            _presentationModelToolStrip = new PresentationModelToolStrip(_model);
        }

        //ClickStartStateTest
        [TestMethod()]
        public void ClickStartStateTest()
        {
        }

        //IsNumberOfQuestionToolStripMenuItemEnabledTest
        [TestMethod()]
        public void IsNumberOfQuestionToolStripMenuItemEnabledTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.IsNumberOfQuestionToolStripMenuItemEnabled(), false);
        }

        //IsQuestionTypeToolStripMenuItemEnabledTest
        [TestMethod()]
        public void IsQuestionTypeToolStripMenuItemEnabledTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.IsQuestionTypeToolStripMenuItemEnabled(), false);
        }

        //IsQuestionTypeOneTest
        [TestMethod()]
        public void IsQuestionTypeOneTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.IsQuestionTypeOne(), false);
        }

        //IsQuestionTypeTwoTest
        [TestMethod()]
        public void IsQuestionTypeTwoTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.IsQuestionTypeTwo(), false);
        }

        //IsQuestionTypeThreeTest
        [TestMethod()]
        public void IsQuestionTypeThreeTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.IsQuestionTypeThree(), false);
        }

        //GetQuestionTypeOneTest
        [TestMethod()]
        public void GetQuestionTypeOneTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.GetQuestionTypeOne(), 0);
        }

        //GetQuestionTypeTwoTest
        [TestMethod()]
        public void GetQuestionTypeTwoTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.GetQuestionTypeTwo(), 1);
        }

        //GetQuestionTypeThreeTest
        [TestMethod()]
        public void GetQuestionTypeThreeTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.GetQuestionTypeThree(), 2);
        }

        //GetTotalOfTwentyQuestionsTest
        [TestMethod()]
        public void GetTotalOfTwentyQuestionsTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.GetTotalOfTwentyQuestions(), 20);
        }

        //GetTotalOfTenQuestionsTest
        [TestMethod()]
        public void GetTotalOfTenQuestionsTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.GetTotalOfTenQuestions(), 10);
        }


        //GetTotalOfFiftyQuestionsTest
        [TestMethod()]
        public void GetTotalOfFiftyQuestionsTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.GetTotalOfFiftyQuestions(), 50);
        }

        //GetZeroOfTypeIndexTest
        [TestMethod()]
        public void GetZeroOfTypeIndexTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.GetZeroOfTypeIndex(), 0);
        }

        //GetOneOfTypeIndexTest
        [TestMethod()]
        public void GetOneOfTypeIndexTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.GetOneOfTypeIndex(), 1);
        }

        //GetTwoOfTypeIndexTest
        [TestMethod()]
        public void GetTwoOfTypeIndexTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.GetTwoOfTypeIndex(), 2);
        }

        [TestMethod()]
        public void GetGroupOneTextTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.GetGroupOneText(), "Q0: Fill in Blanks");
        }

        [TestMethod()]
        public void GetGroupTwoTextTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.GetGroupTwoText(), "Q0: Multiple Choice Question");
        }

        [TestMethod()]
        public void GetMessageBoxShowTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.GetMessageBoxShow(), "You pass 0 of 0 questions!!!" + "\n" + "\n" + "Error Answer：" + "\n" + "\n");
        }

        [TestMethod()]
        public void GetPatternTwoChoiceTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.GetPatternTwoChoice(0), "[動]笑");
            Assert.AreEqual(_presentationModelToolStrip.GetPatternTwoChoice(1), "[形]較少的");
            Assert.AreEqual(_presentationModelToolStrip.GetPatternTwoChoice(2), "[形]兩者之一;[副]也;[連]或者(和or連用)");
            Assert.AreEqual(_presentationModelToolStrip.GetPatternTwoChoice(3), "[名]門");
        }

        [TestMethod()]
        public void GetTotalNumberTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.GetTotalNumber(), 0);
        }

        [TestMethod()]
        public void IsEndOfGameTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.IsEndOfGame(), false);
            _presentationModelToolStrip.SetTotalNumber();
            Assert.AreEqual(_presentationModelToolStrip.IsEndOfGame(), false);
            _model.SetTotalNumberUnitTest(10);
            Assert.AreEqual(_presentationModelToolStrip.IsEndOfGame(), true);
        }

        [TestMethod()]
        public void IsNextEnabledTest()
        {
            _presentationModelToolStrip.ClickStart();
            Assert.AreEqual(_presentationModelToolStrip.IsNextEnabled(), true);
        }

        [TestMethod()]
        public void IsStartEnabledTest()
        {
            _presentationModelToolStrip.Initial();
            Assert.AreEqual(_presentationModelToolStrip.IsStartEnabled(), true);
        }

        [TestMethod()]
        public void IsStopEnabledTest()
        {
            _presentationModelToolStrip.SetIsEndOfGame();
            Assert.AreEqual(_presentationModelToolStrip.IsStopEnabled(), false);
        }

        [TestMethod()]
        public void IsOutChineseEnabledTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.IsOutChineseEnabled(), false);
        }

        [TestMethod()]
        public void IsOutEnglishEnableTest()
        {
            Assert.AreEqual(_presentationModelToolStrip.IsOutEnglishEnable(), false);
        }
    }
}