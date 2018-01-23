using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    //表示按鍵狀態
    public class PresentationModel
    {
        //建構子
        public PresentationModel()
        {
            _model = new Model();
        }

        public PresentationModel(Model model) : this()
        {
            this._model = model;
        }

        //遊戲結束的狀態
        public void SetIsEndOfGame()
        {
            _isStatusBarEnabled = false;
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
            _isRadioButtonChecked = false;
            SetPatternShow();
        }

        //ClickStart狀況
        public void ClickStart(int numericUpDownValue, int selectedIndex, bool isUnitTest)
        {
            _model.Initialize(numericUpDownValue, selectedIndex, isUnitTest);
            _isGroupBoxThreeEnabled = false;
            SetPatternShow();
        }

        //取得model的questionType
        private void SetModelSelectIndex()
        {
            _modelSelectIndex = _model.GetSelectedIndex();
        }

        //回傳statusBar顯示狀況
        public bool IsStatusBarEnabled()
        {
            return _isStatusBarEnabled;
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

        //group3狀態
        public bool IsGroupBoxThreeEnabled()
        {
            return _isGroupBoxThreeEnabled;
        }

        //設定視窗顯示
        private void SetPatternShow()
        {
            SetModelSelectIndex();

            if (_modelSelectIndex == 0)
                SetQuestionPatternOneDisplay();
            else if (_modelSelectIndex == 1)
                SetQuestionPatternTwoDisplay();
        }

        //第一題的顯示
        private void SetQuestionPatternOneDisplay()
        {
            _isGroupBoxOneEnabled = true;
            _isGroupBoxTwoEnabled = false;
            _isRadioButtonEnable = false;
        }

        //第二題的顯示
        private void SetQuestionPatternTwoDisplay()
        {
            _isGroupBoxOneEnabled = false;
            _isGroupBoxTwoEnabled = true;
            _isRadioButtonEnable = true;
        }

        //統整button的狀態
        public bool IsRadioButtonEnable()
        {
            return _isRadioButtonEnable;
        }

        //統整button的"勾選"狀態
        public bool IsRadioButtonChecked()
        {
            return _isRadioButtonChecked;
        }

        //Initial
        public void Initial()
        {
            _isGroupBoxOneEnabled = false;
            _isGroupBoxTwoEnabled = false;
            _isGroupBoxThreeEnabled = true;
            _isStatusBarEnabled = false;
        }

        //------------------For Unit Test--------------------------

        //SetTotalNumber For Unit Test
        public void SetTotalNumberUnitTest(int index)
        {
            _model.SetTotalNumberUnitTest(index);
        }

        private Model _model;
        private bool _isRadioButtonEnable;
        private bool _isRadioButtonChecked;
        private int _modelSelectIndex;
        private bool _isGroupBoxOneEnabled;
        private bool _isGroupBoxTwoEnabled;
        private bool _isGroupBoxThreeEnabled;
        private bool _isStatusBarEnabled;
    }
}
