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
            _presentationModel = new PresentationModel(_model);
            _presentationModelToolStrip = new PresentationModelToolStrip(_model);
            _presentationModelProcessBar = new PresentationModelProcessBar(_model);
        }

        //開始!!!!!!!!!!
        private void ClickStart()
        {
            _presentationModel.ClickStart(Convert.ToInt32(_numericUpDown.Value), _comboBox.SelectedIndex, false);
            _presentationModelToolStrip.ClickStart();
            _presentationModelProcessBar.ClickStart();
            RefreshState();
            RefreshStatePartTwo();
            RefreshStatePartThree();
            _outputChinese.Text = _presentationModel.GetChinese();
            _outputEnglish.Text = _presentationModel.GetEnglish();
            GetChoiceQuestion();
            _presentationModelToolStrip.SetTotalNumber();
        }

        //按下next!!!!!!!!!!!!1
        private void ClickNext()
        {
            _presentationModel.ClickNext(_inputEnglish.Text, GetRadioBoxChecked());
            _presentationModelProcessBar.ClickNext();
            ClickNextPlus();
            RefreshState();
            RefreshStatePartTwo();
            RefreshStatePartThree();
            _inputEnglish.Clear();
        }

        //按下next Part2
        private void ClickNextPlus()
        {
            if (_presentationModelToolStrip.IsEndOfGame())
            {
                _presentationModel.SetIsEndOfGame();
                _presentationModelToolStrip.SetIsEndOfGame();
                RefreshState();
                RefreshStatePartTwo();
                MessageBox.Show(_presentationModelToolStrip.GetMessageBoxShow(), Constant.SPACE);
                Initial();
            }
            else
            {
                SetTextOutput();
                GetChoiceQuestion();
                SetTotalNumber();
            }
        }

        //click stop
        public void ClickStop()
        {
            _presentationModelProcessBar.ClickStop();
            _presentationModelProcessBar.ClickStop();
            RefreshStatePartThree();
            System.Windows.Forms.MessageBox.Show(_presentationModelToolStrip.GetMessageBoxShow(), Constant.SPACE);
            Initial();
        }

        //設定顯示文字
        private void SetTextOutput()
        {
            _statusBarText.Text = _presentationModel.GetConclusion();
            _outputChinese.Text = _presentationModel.GetChinese();
            _outputEnglish.Text = _presentationModel.GetEnglish();
        }

        //工具列 三個題型選項的狀態
        private void RefreshQuestionTypeState()
        {
            _allFillInBlankQuestionsToolStripMenuItem.Checked = _presentationModelToolStrip.IsQuestionTypeOne();
            _allToolStripMenuItem.Checked = _presentationModelToolStrip.IsQuestionTypeTwo();
            _pickUpQuestionsRandomToolStripMenuItem.Checked = _presentationModelToolStrip.IsQuestionTypeThree();
        }

        //重新設定狀態
        private void RefreshState()
        {
            _buttonStart.Enabled = _presentationModelToolStrip.IsStartEnabled();
            _buttonNext.Enabled = _presentationModelToolStrip.IsNextEnabled();
            _buttonStop.Enabled = _presentationModelToolStrip.IsStopEnabled();
            _outputChinese.Visible = _presentationModelToolStrip.IsOutChineseEnabled();
            _statusBarText.Visible = _presentationModel.IsStatusBarEnabled();
            _outputEnglish.Visible = _presentationModelToolStrip.IsOutEnglishEnable();
            _groupBoxOne.Visible = _presentationModel.IsGroupBoxOneEnabled();
            _groupBoxTwo.Visible = _presentationModel.IsGroupBoxTwoEnabled();
            _groupBoxThree.Visible = _presentationModel.IsGroupBoxThreeEnabled();
        }

        //重新設定狀態part 2
        private void RefreshStatePartTwo()
        {
            _radioButtonOne.Enabled = _presentationModel.IsRadioButtonEnable();
            _radioButtonTwo.Enabled = _presentationModel.IsRadioButtonEnable();
            _radioButtonThree.Enabled = _presentationModel.IsRadioButtonEnable();
            _radioButtonFour.Enabled = _presentationModel.IsRadioButtonEnable();
            _groupBoxOne.Text = _presentationModelToolStrip.GetGroupOneText();
            _groupBoxTwo.Text = _presentationModelToolStrip.GetGroupTwoText();
            //工具列 examination中的狀態
            _startToolStripMenuItem.Enabled = _presentationModelToolStrip.IsStartEnabled();
            _stopToolStripMenuItem.Enabled = _presentationModelToolStrip.IsStopEnabled();
            _nextToolStripMenuItem.Enabled = _presentationModelToolStrip.IsNextEnabled();
            _numberOfQuestionToolStripMenuItem.Enabled = _presentationModelToolStrip.IsNumberOfQuestionToolStripMenuItemEnabled();
            _questionTypeToolStripMenuItem.Enabled = _presentationModelToolStrip.IsQuestionTypeToolStripMenuItemEnabled();
        }

        //重新設定狀態part 3
        private void RefreshStatePartThree()
        {
            _timer.Enabled = _presentationModelProcessBar.IsTimerEnable();
            _timerLabel.Visible = _presentationModelProcessBar.IsTimerLabelVisible();
            _scoreLabel.Text = _presentationModelProcessBar.GetScore();
            _scoreLabel.Visible = _presentationModelProcessBar.IsScoreLabelVisible();
            _progressBar.Visible = _presentationModelProcessBar.IsProgressBarVisible();
            _radioButtonOne.Checked = _presentationModel.IsRadioButtonChecked();
            _radioButtonTwo.Checked = _presentationModel.IsRadioButtonChecked();
            _radioButtonThree.Checked = _presentationModel.IsRadioButtonChecked();
            _radioButtonFour.Checked = _presentationModel.IsRadioButtonChecked();
        }

        //取得選擇題的問題
        private void GetChoiceQuestion()
        {
            _radioButtonOne.Text = _presentationModelToolStrip.GetPatternTwoChoice(0);
            _radioButtonTwo.Text = _presentationModelToolStrip.GetPatternTwoChoice(1);
            _radioButtonThree.Text = _presentationModelToolStrip.GetPatternTwoChoice(Constant.TWO);
            _radioButtonFour.Text = _presentationModelToolStrip.GetPatternTwoChoice(Constant.THREE);
        }

        //取得哪一個按鈕被按下
        private int GetRadioBoxChecked()
        {
            if (_radioButtonOne.Checked)
                return 0;
            else if (_radioButtonTwo.Checked)
                return 1;
            else if (_radioButtonThree.Checked)
                return Constant.TWO;
            else if (_radioButtonFour.Checked)
                return Constant.THREE;
            else
                return -1;
        }

        //總題數+1
        private void SetTotalNumber()
        {
            _presentationModelToolStrip.SetTotalNumber();
        }

        //Timer 1
        private void TickTimer(object sender, EventArgs e)
        {
            _presentationModelProcessBar.TickTimer();
            _timerLabel.Text = _presentationModelProcessBar.GetTimerLabel();
            _progressBar.Value = _presentationModelProcessBar.GetProgressBarValue();

            if (_presentationModelProcessBar.IsTimeOver())
                ClickNext();
        }

        //For Progress Bar
        private void TickTimerTwo(object sender, EventArgs e)
        {
            _progressBar.Value = _presentationModelProcessBar.GetProgressBarValue();
        }

        //初始化
        private void Initial()
        {
            _presentationModel.Initial();
            _presentationModelToolStrip.Initial();
            _presentationModelProcessBar.Initial();
            RefreshState();
            RefreshStatePartTwo();
            RefreshStatePartThree();
        }

        private Model _model = new Model();
        private PresentationModel _presentationModel;
        private PresentationModelToolStrip _presentationModelToolStrip;
        private PresentationModelProcessBar _presentationModelProcessBar;
        private AboutUs _aboutUs = new AboutUs();

    }
}
