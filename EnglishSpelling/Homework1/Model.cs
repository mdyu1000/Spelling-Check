using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Homework1
{
    public class Model
    {
        //初始化(Start)
        public void Initialize(int numericUpDownValue, int selectedIndex, bool isUnitTest)
        {
            _totalNumber = 0;
            _correctNumber = 0;
            _errorAnswer.Clear();
            _compareInput.Clear();
            _selectedIndex = selectedIndex;
            _processStrip.Initialize();
            SetNumericUpDownNumber(numericUpDownValue);
            _random = new RandomNumber(numericUpDownValue, isUnitTest);
            _question = new Question(_random, numericUpDownValue);
            _question.SetQuestionNumber(_totalNumber);
            _question.SetPatternOneQuestionChinese();
            _question.SetPatternTwoQuestionEnglish();
            _question.SetCorrectChoice();
            _question.SetPatternTwoChoice();
        }

        //設定GetGroupOne的Text
        public string GetGroupOneText()
        {
            return Constant.WORD_1 + _totalNumber + Constant.WORD_2;
        }

        //設定GetGroupTwo的Text
        public string GetGroupTwoText()
        {
            return Constant.WORD_1 + _totalNumber + Constant.WORD_3;
        }

        //取得為何種題型
        public int GetQuestionPattern()
        {
            return _random.GetQuestionPattern();
        }

        //取得正確選項中的確切位置
        public int GetRealQuestionNumber()
        {
            return _random.GetRealQuestionNumber();
        }

        //正確數量加一
        public void SetCorrectNumber()
        {
            _correctNumber++;
        }

        //取得正確答題數
        public int GetCorrectNumber()
        {
            return _correctNumber;
        }

        //總答題數加一
        public void SetTotalNumber()
        {
            _totalNumber++;
        }

        //取得答題總數
        public int GetTotalNumber()
        {
            return _totalNumber;
        }

        //輸出中文題目
        public string GetChinese()
        {
            return _question.GetPatternOneQuestion();
        }

        //取得英文題目
        public string GetEnglish()
        {
            return _question.GetPatternTwoQuestion();
        }

        //取得pattern2的選擇題題目 4題
        public string GetPatternTwoChoice(int index)
        {
            return _question.GetPatternTwoChoice(_totalNumber, index);
        }

        //輸出最下面那行的結論
        public string GetConclusion()
        {
            if (GetCompareInput(_totalNumber - 1))
                return Constant.CORRECT;
            else
                return Constant.WORD_4 + _dictionary.GetWord()[_random.GetRandom(_totalNumber - 1)].GetEnglish();
        }

        //比較輸入的結果與題目是否正確
        public void SetCompareInput(string inputEnglish, int radioButtonAnswer)
        {
            if (string.Equals(inputEnglish, _dictionary.GetWord()[_random.GetRandom(_totalNumber - 1)].GetEnglish()) || radioButtonAnswer == _question.GetCorrectChoice())
                _compareInput.Add(true);
            else
            {
                _compareInput.Add(false);
                _errorAnswer.Add(_random.GetRandom(_totalNumber - 1));
            }
        }

        //取得比較後的true and false
        public bool GetCompareInput(int index)
        {
            return _compareInput[index];
        }

        //設定題號總數
        public void SetNumericUpDownNumber(int numericUpDownNumber)
        {
            _numericUpDownNumber = numericUpDownNumber;
        }

        //回傳題號總數
        public int GetNumericUpDownNumber()
        {
            return _numericUpDownNumber;
        }

        //回傳選擇題型
        public int GetSelectedIndex()
        {
            return _selectedIndex == Constant.TWO ? _random.GetQuestionPattern() : _selectedIndex;
        }

        //取得GetMessageBox的資料
        public string GetMessageBoxShow()
        {
            string temp = null;

            for (int i = 0; i < _errorAnswer.Count(); i++)
            {
                temp += _dictionary.GetWord()[_errorAnswer[i]].GetEnglish() + Constant.SPACE + _dictionary.GetWord()[_errorAnswer[i]].GetChinese() + Constant.NEW_ROW;
            }

            return Constant.STRING_1 + GetCorrectNumber() + Constant.STRING_2 + GetTotalNumber() + Constant.STRING_3 + Constant.NEW_ROW + Constant.NEW_ROW + Constant.ERROR_ANSWER + Constant.NEW_ROW + Constant.NEW_ROW + temp;
        }

        //當Next按下時
        public void ClickNext(string inputEnglish, int radioButtonAnswer)
        {
            SetCompareInput(inputEnglish, radioButtonAnswer);

            if (GetCompareInput(_totalNumber - 1))
                SetCorrectNumber();

            if (GetTotalNumber() != _numericUpDownNumber)
            {
                _random.SetWrongQuestionThree();
                _question.SetQuestionNumber(_totalNumber);
                _question.SetPatternOneQuestionChinese();
                _question.SetPatternTwoQuestionEnglish();
                _question.SetCorrectChoice();
                _question.SetPatternTwoChoice();
                _processStrip.ResetTimerLabel();
                _processStrip.ResetProgressBar();
                _processStrip.SetScore(_numericUpDownNumber, _correctNumber);
            }
        }

        //是否符合結束條件
        public bool IsEndOfGame()
        {
            return GetTotalNumber() >= GetNumericUpDownNumber() ? true : false;
        }

        //Timer計數
        public void TickTimer()
        {
            _processStrip.TickTimer();
        }

        //取得TimerLabel
        public string GetTimerLabel()
        {
            return _processStrip.GetTimerLabel();
        }

        //取得計數是否結束
        public bool IsTimeOver()
        {
            return _processStrip.IsTimeOver() ;
        }

        //取得ProgressBarValue
        public int GetProgressBarValue()
        {
            return _processStrip.GetProgressBarValue();
        }

        //Get Score
        public string GetScore()
        {
            return _processStrip.GetScore();
        }

        //-----------For Unit Test----------

        //SetTotalNumber For Unit Test
        public void SetTotalNumberUnitTest(int number)
        {
            _totalNumber = number;
        }

        public void SetErrorAnswerUnitTest()
        {
            _errorAnswer.Add(0);
        }

        private RandomNumber _random;
        private Question _question;
        private Dictionary _dictionary = new Dictionary();
        private ProcessStrip _processStrip = new ProcessStrip();
        private int _correctNumber;
        private int _totalNumber;
        private int _numericUpDownNumber;
        private int _selectedIndex;
        private List<bool> _compareInput = new List<bool>();
        private List<int> _errorAnswer = new List<int>();
    }
}
