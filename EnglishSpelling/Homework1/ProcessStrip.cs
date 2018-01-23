using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    public class ProcessStrip
    {
        public ProcessStrip()
        {
            _timerLabel = Constant.TWENTY;
            _progressBarValue = Constant.ONE_HUNDRED;
        }

        //Timer計數 -1
        public void TickTimer()
        {
            if (_timerLabel != 0)
                _timerLabel--;

            SetMistakeCount();
            SetProgressBarValue();
            SetIsTimeOver();
        }

        //ResetTimer
        public void ResetTimerLabel()
        {
            _timerLabel = Constant.TWENTY;
        }

        //ResetProgressBar
        public void ResetProgressBar()
        {
            _progressBarValue = Constant.ONE_HUNDRED;
        }

        //Reset Score
        public void ResetScore()
        {
            _score = 0;
        }

        //取得timerLabel的狀態
        public string GetTimerLabel()
        {
            string temp = _timerLabel.ToString().PadLeft(Constant.TWO, Constant.ZERO);//個位數補0
            return Constant.TIMER + temp;
        }

        //統計10秒的扣分次數
        public void SetMistakeCount()
        {
            if (_timerLabel % Constant.TEN == 0)
                _mistakeCount ++;
        }

        //設定計數是否結束
        public void SetIsTimeOver()
        {
            _isTimeOver = (_timerLabel == 0) ? true : false;
        }

        //取得計數結果
        public bool IsTimeOver()
        {
            return _isTimeOver;
        }

        //取得ProgressBarValue
        public int GetProgressBarValue()
        {
            return _progressBarValue;
        }

        //Set progressBarValue
        public void SetProgressBarValue()
        {
            if (_progressBarValue == 0)
                _progressBarValue = Constant.NINETY;
            else
                _progressBarValue -= PROGRESS_BAR_STEP;
        }

        //SetScore
        public void SetScore(int numericNumber, int correctNumber)
        {
            _score = (correctNumber * Constant.ONE_HUNDRED / numericNumber) - _mistakeCount;
        }

        //GetScore
        public string GetScore()
        {
            return Constant.SCORE + _score.ToString();
        }

        //Initial
        public void Initialize()
        {
            ResetTimerLabel();
            ResetProgressBar();
            ResetScore();
        }

        //-----For Unit Test---------

        public void SetTimerLabelUnitTest(int number)
        {
            _timerLabel = number;
        }

        public void SetProgressBarUnitTest(int number)
        {
            _progressBarValue = number;
        }

        public int GetMistakeCountUnitTest()
        {
            return _mistakeCount;
        }

        private int _timerLabel;
        private int _mistakeCount;
        private bool _isTimeOver;
        private int _progressBarValue;
        private int _score;
        private const int PROGRESS_BAR_STEP = Constant.TEN;

    }
}
