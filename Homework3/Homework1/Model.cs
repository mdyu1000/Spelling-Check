using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Homework1
{
    class Model
    {
        //設定GetGroupOne的Text
        public string GetGroupOneText()
        {
            const string WORD_ONE = "Q";
            const string WORD_TWO = ": Fill in Blanks";
            return WORD_ONE + _totalNumber + WORD_TWO;
        }

        //設定GetGroupTwo的Text
        public string GetGroupTwoText()
        {
            const string WORD_ONE = "Q";
            const string WORD_TWO = ": Multiple Choice Question";
            return WORD_ONE + _totalNumber + WORD_TWO;
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
            const string CORRECT = "Correct!!!";
            const string DISPLAY = "It should be ";

            if (GetCompareInput(_totalNumber - 1))
                return CORRECT;
            else
                return DISPLAY + _dictionary.GetWord()[_random.GetRandom(_totalNumber - 1)].GetEnglish();
        }

        //比較輸入的結果與題目是否正確
        public void SetCompareInput(string inputEnglish, int radioButtonAnswer)
        {
            if (string.Equals(inputEnglish, _dictionary.GetWord()[_random.GetRandom(_totalNumber - 1)].GetEnglish()) || radioButtonAnswer == _question.GetCorrectChoice())
                _compareInput.Add(true);
            else
                _compareInput.Add(false);
        }

        //取得比較後的true and false
        public bool GetCompareInput(int index)
        {
            return _compareInput[index];
        }

        //取得GetMessageBox的資料
        public string GetMessageBoxShow()
        {
            const string STRING_1 = "You pass ";
            const string STRING_2 = " of ";
            const string STRING_3 = " questions!!!";
            return STRING_1 + GetCorrectNumber() + STRING_2 + GetTotalNumber() + STRING_3;
        }

        //當Next按下時
        public void ClickNext(string inputEnglish, int radioButtonAnswer)
        {
            SetCompareInput(inputEnglish, radioButtonAnswer);

            if (GetCompareInput(_totalNumber - 1))
                SetCorrectNumber();

            if (GetTotalNumber() != Constant.TEN)
            {
                _question.SetQuestionNumber(_totalNumber);
                _question.SetPatternOneQuestionChinese();
                _question.SetPatternTwoQuestionEnglish();
                _question.SetCorrectChoice();
                _question.SetPatternTwoChoice();
                //SetTotalNumber();
            }
        }

        public void SetTotalNumber(int totalNumber)
        {
            _totalNumber = totalNumber;
        }

        //初始化(Start)
        public void Initialize()
        {
            //設定dictionary的字典黨
            _dictionary.SetDictionary();
            //設定中英文 與英文遮罩
            _dictionary.SetWord();
            //設定亂數
            _random.SetRandom();
            _question.Initialize(_random);
            _question.SetQuestionNumber(_totalNumber);
            _question.SetPatternOneQuestionChinese();
            _question.SetPatternTwoQuestionEnglish();
            _question.SetCorrectChoice();
            _question.SetPatternTwoChoice();
            //SetTotalNumber();
        }

        private RandomNumber _random = new RandomNumber();
        private Question _question = new Question();
        private Dictionary _dictionary = new Dictionary();
        private int _correctNumber;
        private int _totalNumber;
        private List<bool> _compareInput = new List<bool>();
    }
}
