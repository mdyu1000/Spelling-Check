using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework1
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }

        //當Next按下
        private void ButtonNextClick(object sender, EventArgs e)
        {
            _presentationModel.ClickNext(_inputEnglish.Text, GetRadioBoxChecked());

            if (_presentationModel.IsEndOfGame())
            {
                RefreshState();
                MessageBox.Show(_presentationModel.GetMessageBoxShow());
            }
            else
            {
                SetTextOutput();
                GetChoiceQuestion();
                _presentationModel.SetTotalNumber();
            }

            RefreshState();
            _inputEnglish.Clear();
        }

        //當Start按下
        private void ButtonStartClick(object sender, EventArgs e)
        {
            _presentationModel.ClickStart();
            RefreshState();
            _outputChinese.Text = _presentationModel.GetChinese();
            _outputEnglish.Text = _presentationModel.GetEnglish();
            GetChoiceQuestion();
            _presentationModel.SetTotalNumber();
        }

        //設定顯示文字
        private void SetTextOutput()
        {
            _statusBarText.Text = _presentationModel.GetConclusion();
            _outputChinese.Text = _presentationModel.GetChinese();
            _outputEnglish.Text = _presentationModel.GetEnglish();
        }

        //重新設定狀態
        private void RefreshState()
        {
            _buttonStart.Enabled = _presentationModel.IsStartEnabled();
            _buttonNext.Enabled = _presentationModel.IsNextEnabled();
            _outputChinese.Visible = _presentationModel.IsOutChineseEnabled();
            _statusBarText.Visible = _presentationModel.IsStatusBarEnabled();
            _outputEnglish.Visible = _presentationModel.IsOutEnglishEnable();
            _groupBoxOne.Visible = _presentationModel.IsGroupBoxOneEnabled();
            _groupBoxTwo.Visible = _presentationModel.IsGroupBoxTwoEnabled();
            _radioButtonOne.Enabled = _presentationModel.IsRadioButtonOneEnable();
            _radioButtonTwo.Enabled = _presentationModel.IsRadioButtonTwoEnable();
            _radioButtonThree.Enabled = _presentationModel.IsRadioButtonThreeEnable();
            _radioButtonFour.Enabled = _presentationModel.IsRadioButtonFourEnable();
            _groupBoxOne.Text = _presentationModel.GetGroupOneText();
            _groupBoxTwo.Text = _presentationModel.GetGroupTwoText();
        }

        //取得選擇題的問題
        private void GetChoiceQuestion()
        {
            const int TWO = 2;
            const int THREE = 3;
            _radioButtonOne.Text = _presentationModel.GetPatternTwoChoice(0);
            _radioButtonTwo.Text = _presentationModel.GetPatternTwoChoice(1);
            _radioButtonThree.Text = _presentationModel.GetPatternTwoChoice(TWO);
            _radioButtonFour.Text = _presentationModel.GetPatternTwoChoice(THREE);
        }

        //取得哪一個按鈕被按下
        private int GetRadioBoxChecked()
        {
            if (_radioButtonOne.Checked)
                return 0;
            else if (_radioButtonTwo.Checked)
                return 1;
            else if (_radioButtonThree.Checked)
                return 2;
            else if (_radioButtonFour.Checked)
                return 3;
            else
                return -1;
        }

        private PresentationModel _presentationModel = new PresentationModel();
    }
}
