using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.Tests
{
    //PresentationModelTests
    [TestClass()]
    public class PresentationModelTests
    {
        PresentationModel _presentationModel;
        Model _model = new Model();
        const string QUESTION = "test";
        const int CORRECT_CHOICE = 100;

        //Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model.Initialize(10, 0, true);
            _presentationModel = new PresentationModel(_model);
            _presentationModel.Initial();
        }

        //利用conclusion會比較的關係 藉機把所有副程式全部run一次
        [TestMethod()]
        public void GetConclusionTest()
        {
            _presentationModel.ClickStart(10, 1, true);
            _presentationModel.SetTotalNumberUnitTest(1);
            _presentationModel.ClickNext("door", 3);
            Assert.AreEqual(_presentationModel.GetConclusion(), "Correct!!!");
        }

        //GetChineseTest
        [TestMethod()]
        public void GetChineseTest()
        {
            _presentationModel.ClickStart(10, 0, true);
            Assert.AreEqual(_presentationModel.GetChinese(), "[名]門 d__r (4)");
        }

        //GetEnglishTest
        [TestMethod()]
        public void GetEnglishTest()
        {
            _presentationModel.ClickStart(10, 0, true);
            Assert.AreEqual(_presentationModel.GetEnglish(), "door");
        }

        //ClickNextTest
        [TestMethod()]
        public void ClickNextTest()
        {
            Assert.Fail();
        }

        //ClickStartTest
        [TestMethod()]
        public void ClickStartTest()
        {
            Assert.Fail();
        }


        //IsStatusBarEnabledTest
        [TestMethod()]
        public void IsStatusBarEnabledTest()
        {
            _presentationModel.SetIsEndOfGame();
            Assert.AreEqual(_presentationModel.IsStatusBarEnabled(), false);
        }

        //SetTotalNumberTest
        [TestMethod()]
        public void SetTotalNumberTest()
        {
            Assert.Fail();
        }

        //IsGroupBoxOneEnabledTest
        [TestMethod()]
        public void IsGroupBoxOneEnabledTest()
        {
            Assert.AreEqual(_presentationModel.IsGroupBoxOneEnabled(), false);
        }

        //IsGroupBoxTwoEnabledTest
        [TestMethod()]
        public void IsGroupBoxTwoEnabledTest()
        {
            Assert.AreEqual(_presentationModel.IsGroupBoxTwoEnabled(), false);
        }

        //IsGroupBoxThreeEnabledTest
        [TestMethod()]
        public void IsGroupBoxThreeEnabledTest()
        {
            Assert.AreEqual(_presentationModel.IsGroupBoxThreeEnabled(), false);
        }

        //IsRadioButtonEnableTest
        [TestMethod()]
        public void IsRadioButtonEnableTest()
        {
            Assert.AreEqual(_presentationModel.IsRadioButtonEnable(), false);
        }

        [TestMethod()]
        public void IsRadioButtonCheckedTest()
        {
            Assert.AreEqual(_presentationModel.IsRadioButtonChecked(), false);
        }

    }
}