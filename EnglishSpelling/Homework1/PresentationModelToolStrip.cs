using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    public class PresentationModelToolStrip
    {
        public PresentationModelToolStrip()
        {
            _model = new Model();
        }

        public PresentationModelToolStrip(Model model) : this()
        {
            _model = model;
        }

        //按下start
        public void ClickStart()
        {
            _isStartEnabled = false;
            _isNextEnabled = true;
            _isStopEnabled = true;
            _numberOfQuestionToolStripMenuItem = false;
            _questionTypeToolStripMenuItem = false;
            _isOutChineseEnabled = true;
            _isOutEnglishEnabled = true;
        }

        //得知 工具列-num of question按鈕 狀態
        public bool IsNumberOfQuestionToolStripMenuItemEnabled()
        {
            return _numberOfQuestionToolStripMenuItem;
        }

        //得知 工具列-question type按鈕 狀態
        public bool IsQuestionTypeToolStripMenuItemEnabled()
        {
            return _questionTypeToolStripMenuItem;
        }

        //回傳 questionTypeOne狀態
        public bool IsQuestionTypeOne()
        {
            return _questionTypeOne;
        }

        //回傳 questionTypeTwo狀態
        public bool IsQuestionTypeTwo()
        {
            return _questionTypeTwo;
        }

        //回傳 questionTypeThree狀態
        public bool IsQuestionTypeThree()
        {
            return _questionTypeThree;
        }

        //回傳中文題目顯示狀況
        public bool IsOutChineseEnabled()
        {
            return _isOutChineseEnabled;
        }

        //回傳英文輸出顯示狀態
        public bool IsOutEnglishEnable()
        {
            return _isOutEnglishEnabled;
        }

        //回傳 combox第一種狀態
        public int GetQuestionTypeOne()
        {
            _questionTypeOne = true;
            _questionTypeTwo = false;
            _questionTypeThree = false;
            return 0;
        }

        //回傳 combox第二種狀態
        public int GetQuestionTypeTwo()
        {
            _questionTypeOne = false;
            _questionTypeTwo = true;
            _questionTypeThree = false;
            return 1;
        }

        //回傳 combox第三種狀態
        public int GetQuestionTypeThree()
        {
            _questionTypeOne = false;
            _questionTypeTwo = false;
            _questionTypeThree = true;
            return Constant.TWO;
        }

        //回傳 總數共10個題目
        public int GetTotalOfTenQuestions()
        {
            return Constant.TEN;
        }

        //回傳 總數共20個題目
        public int GetTotalOfTwentyQuestions()
        {
            return Constant.TWENTY;
        }

        //回傳 總數共50個題目
        public int GetTotalOfFiftyQuestions()
        {
            return Constant.FIFTY;
        }

        //回傳 第0種題型
        public int GetZeroOfTypeIndex()
        {
            return 0;
        }

        //回傳 第1種題型
        public int GetOneOfTypeIndex()
        {
            return 1;
        }

        //回傳 第2種題型
        public int GetTwoOfTypeIndex()
        {
            return Constant.TWO;
        }

        //回傳start按鈕狀況
        public bool IsStartEnabled()
        {
            return _isStartEnabled;
        }

        //回傳next按鈕狀況
        public bool IsNextEnabled()
        {
            return _isNextEnabled;
        }

        //回傳stop按鈕的狀況
        public bool IsStopEnabled()
        {
            return _isStopEnabled;
        }

        //這裡PM的判定 傳回原本的PM
        public void SetIsEndOfGame()
        {
            _isNextEnabled = false;
            _isStopEnabled = false;
            _isOutChineseEnabled = false;
        }

        //Initial
        public void Initial()
        {
            _isStartEnabled = true;
            _isNextEnabled = false;
            _isStopEnabled = false;
        }

        //messageBox顯示
        public string GetMessageBoxShow()
        {
            return _model.GetMessageBoxShow();
        }

        //設定GetGroupTwo的Text
        public string GetGroupTwoText()
        {
            return _model.GetGroupTwoText();
        }

        //設定GetGroupOne的Text
        public string GetGroupOneText()
        {
            return _model.GetGroupOneText();
        }

        //取得答題總數
        public int GetTotalNumber()
        {
            return _model.GetTotalNumber();
        }

        //取得pattern2的選擇題題目
        public string GetPatternTwoChoice(int index)
        {
            return _model.GetPatternTwoChoice(index);
        }

        //輸出題目總數
        public bool IsEndOfGame()
        {
            return _model.IsEndOfGame() ? true : false;
        }

        //總數加一
        public void SetTotalNumber()
        {
            _model.SetTotalNumber();
        }

        private Model _model;
        private bool _isStartEnabled;
        private bool _isNextEnabled;
        private bool _isStopEnabled;
        private bool _numberOfQuestionToolStripMenuItem;
        private bool _questionTypeToolStripMenuItem;
        private bool _questionTypeOne;
        private bool _questionTypeTwo;
        private bool _questionTypeThree;
        private bool _isOutChineseEnabled;
        private bool _isOutEnglishEnabled;
    }
}
