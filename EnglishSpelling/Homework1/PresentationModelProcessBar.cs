using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    public class PresentationModelProcessBar
    {
        public PresentationModelProcessBar()
        {
            _model = new Model();
        }

        public PresentationModelProcessBar(Model model) : this()
        {
            _model = model;
        }

        //初始化
        public void Initial()
        {
            _isTimerEnable = false;
            _isTimerLabelVisible = false;
            _isProgressBarVisible = false;
            _isScoreLabelVisible = false;
        }

        //回傳 timerLabel狀態
        public bool IsTimerLabelVisible()
        {
            return _isTimerLabelVisible;
        }

        //回傳 Timer狀態
        public bool IsTimerEnable()
        {
            return _isTimerEnable;
        }

        //IsProgressBarVisible
        public bool IsProgressBarVisible()
        {
            return _isProgressBarVisible;
        }

        //IsScoreLabelVisible
        public bool IsScoreLabelVisible()
        {
            return _isScoreLabelVisible;
        }

        //click stop
        public void ClickStop()
        {
            _isTimerEnable = false;
        }

        //ClickStart
        public void ClickStart()
        {
            _isTimerLabelVisible = true;
            _isTimerEnable = true;
            _isScoreLabelVisible = true;
            _isProgressBarVisible = true;
        }

        //ClickNext
        public void ClickNext()
        {
            _isTimerEnable = true;
        }

        //Timer計數
        public void TickTimer()
        {
            _model.TickTimer();
        }

        //取得TimerLabel
        public string GetTimerLabel()
        {
            return _model.GetTimerLabel();
        }

        //取得計數是否結束
        public bool IsTimeOver()
        {
            return _model.IsTimeOver();
        }

        //取得ProgressBarValue
        public int GetProgressBarValue()
        {
            return _model.GetProgressBarValue();
        }

        //Get Score
        public string GetScore()
        {
            return _model.GetScore();
        }

        private bool _isTimerLabelVisible;
        private bool _isTimerEnable;
        private bool _isScoreLabelVisible;
        private bool _isProgressBarVisible;
        private Model _model;
    }
}
