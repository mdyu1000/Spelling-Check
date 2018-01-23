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
    public class QuestionTests
    {
        RandomNumber _random;
        Question _question;
        PrivateObject _target;
        const string QUESTION = "test";
        const int CORRECT_CHOICE = 100;
        readonly string[] QUESTION_CHOICE = { "test1", "test2", "test3", "test4", "test5" };

        //Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _random = new RandomNumber(10, true);
            _question = new Question(_random, 10);
            _target = new PrivateObject(_question);
            _question.SetForUnitTest(QUESTION, CORRECT_CHOICE);
        }

        //SetQuestionNumberTest
        [TestMethod()]
        public void SetQuestionNumberTest()
        {
            _question.SetQuestionNumber(0);
            Assert.AreEqual(_question.GetQuestionNumber(), 248);
        }

        //SetPatternOneQuestionChineseTest
        [TestMethod()]
        public void SetPatternOneQuestionChineseTest()
        {
            _question.SetQuestionNumber(0);
            _question.SetPatternOneQuestionChinese();
            Assert.AreEqual(_question.GetPatternOneQuestion(), "[名]門 d__r (4)");
        }

        //SetPatternTwoQuestionEnglishTest
        [TestMethod()]
        public void SetPatternTwoQuestionEnglishTest()
        {
            _question.SetQuestionNumber(0);
            _question.SetPatternTwoQuestionEnglish();
            Assert.AreEqual(_question.GetPatternTwoQuestion(), "door");
        }

        //SetPatternTwoChoiceTest
        [TestMethod()]
        public void SetPatternTwoChoiceTest()
        {
            _question.SetQuestionNumber(0);
            _question.SetPatternTwoChoice();
        }

        //SetCorrectChoiceTest
        [TestMethod()]
        public void SetCorrectChoiceTest()
        {
            _question.SetCorrectChoice();
            Assert.AreEqual(_question.GetCorrectChoice(), 0);
        }

        //GetCorrectChoiceTest
        [TestMethod()]
        public void GetCorrectChoiceTest()
        {
            Assert.AreEqual(_question.GetCorrectChoice(), CORRECT_CHOICE);
        }

        //GetPatternTwoChoiceTest
        [TestMethod()]
        public void GetPatternTwoChoiceTest()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(_question.GetPatternTwoChoice(i, j), "test");
                }
            }
        }

        //GetPatternOneQuestionTest
        [TestMethod()]
        public void GetPatternOneQuestionTest()
        {
            Assert.AreEqual(_question.GetPatternOneQuestion(), "test");
        }

        //GetPatternTwoQuestionTest
        [TestMethod()]
        public void GetPatternTwoQuestionTest()
        {
            Assert.AreEqual(_question.GetPatternTwoQuestion(), "test");
        }
    }
}