using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    //表示按鍵狀態
    class PresentationModel
    {
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

        //messageBox顯示
        public string GetMessageBoxShow()
        {
            return _model.GetMessageBoxShow();
        }

        //輸出題目總數
        public bool IsEndOfGame()
        {
            if (_model.GetTotalNumber() >= Constant.TEN)
            {
                _isNextEnabled = false;
                _isOutChineseEnabled = false;
                _isStatusBarEnabled = false;
                return true;
            }
            else
                return false;
        }

        //輸出結論
        public string GetConclusion()
        {
            return _model.GetConclusion();
        }

        //輸出中文題目
        public string GetChinese()
        {
            return _model.GetChinese();
        }

        //輸出英文題目
        public string GetEnglish()
        {
            return _model.GetEnglish();
        }

        //ClickNext狀況
        public void ClickNext(string inputEnglish, int radioButtonAnswer)
        {
            _model.ClickNext(inputEnglish, radioButtonAnswer);
            _isStatusBarEnabled = true;
            SetPatternShow();
        }

        //ClickStart狀況
        public void ClickStart()
        {
            _model.Initialize();
            _isNextEnabled = true;
            _isStartEnabled = false;
            _isOutChineseEnabled = true;
            _isOutEnglishEnabled = true;
            SetPatternShow();
        }

        //設定視窗顯示
        private void SetPatternShow()
        {
            if (_model.GetQuestionPattern() == 0)
                SetQuestionPatternOneDisplay();
            else
                SetQuestionPatternTwoDisplay();
        }

        //第一題的顯示
        private void SetQuestionPatternOneDisplay()
        {
            _isGroupBoxOneEnabled = true;
            _isGroupBoxTwoEnabled = false;
            _isRadioButtonOneEnable = false;
            _isRadioButtonTwoEnable = false;
            _isRadioButtonThreeEnable = false;
            _isRadioButtonFourEnable = false;
        }

        //第二題的顯示
        private void SetQuestionPatternTwoDisplay()
        {
            _isGroupBoxOneEnabled = false;
            _isGroupBoxTwoEnabled = true;
            _isRadioButtonOneEnable = true;
            _isRadioButtonTwoEnable = true;
            _isRadioButtonThreeEnable = true;
            _isRadioButtonFourEnable = true;
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

        //回傳statusBar顯示狀況
        public bool IsStatusBarEnabled()
        {
            return _isStatusBarEnabled;
        }

        //總數加一
        public void SetTotalNumber()
        {
            _model.SetTotalNumber();
        }

        //group1狀態
        public bool IsGroupBoxOneEnabled()
        {
            return _isGroupBoxOneEnabled;
        }

        //group2狀態
        public bool IsGroupBoxTwoEnabled()
        {
            return _isGroupBoxTwoEnabled;
        }

        //btn1狀態
        public bool IsRadioButtonOneEnable()
        {
            return _isRadioButtonOneEnable;
        }

        //btn2狀態
        public bool IsRadioButtonTwoEnable()
        {
            return _isRadioButtonTwoEnable;
        }

        //btn3狀態
        public bool IsRadioButtonThreeEnable()
        {
            return _isRadioButtonThreeEnable;
        }

        //btn3狀態
        public bool IsRadioButtonFourEnable()
        {
            return _isRadioButtonFourEnable;
        }

        private Model _model = new Model();
        private bool _isStartEnabled;
        private bool _isNextEnabled;
        private bool _isOutChineseEnabled;
        private bool _isOutEnglishEnabled;
        private bool _isStatusBarEnabled;
        private bool _isGroupBoxOneEnabled;
        private bool _isGroupBoxTwoEnabled;
        private bool _isRadioButtonOneEnable;
        private bool _isRadioButtonTwoEnable;
        private bool _isRadioButtonThreeEnable;
        private bool _isRadioButtonFourEnable;
    }
}
