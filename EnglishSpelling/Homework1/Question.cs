using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    public class Question
    {
        //結構子
        public Question(RandomNumber random, int numericUpDownValue)
        {
            _random = random;
            _numericUpDownValue = numericUpDownValue;
        }

        //設定題號1-1000
        public void SetQuestionNumber(int index)
        {
            _questionNumber = _random.GetRandom(index);
        }

        //設定中文題目
        public void SetPatternOneQuestionChinese()
        {
            _patternOneQuestion = _dictionary.GetWord()[_questionNumber].GetChinese() + Constant.SPACE + _dictionary.GetWord()[_questionNumber].GetEnglishHide() + Constant.SPACE + Constant.LEFT + _dictionary.GetWord()[_questionNumber].GetEnglish().Length + Constant.RIGHT;
        }

        //設定第二題的中文題目
        public void SetPatternTwoQuestionEnglish()
        {
            _patternTwoQuestion = _dictionary.GetWord()[_questionNumber].GetEnglish();
        }

        //設定第二題的選擇題題目
        public void SetPatternTwoChoice()
        {
            int temp = 0;

            for (int i = 0; i < _numericUpDownValue; i++)
            {
                for (int j = 0; j < Constant.FOUR; j++)
                {
                    if (j == _correctChoice)
                        _patternTwoChoice[j] = _dictionary.GetWord()[_questionNumber].GetChinese();
                    else
                        _patternTwoChoice[j] = _dictionary.GetWord()[_random.GetWrongQuestionNumber(temp++)].GetChinese();
                }

                _patternTwoChoiceDynamic.Add(_patternTwoChoice);
                temp = 0;
            }
        }

        //設置正確的選項
        public void SetCorrectChoice()
        {
            _correctChoice = _random.GetRealQuestionNumber();
        }

        //取得正確的選項
        public int GetCorrectChoice()
        {
            return _correctChoice;
        }

        //取得選擇題的題目
        public string GetPatternTwoChoice(int totalNumber, int indexTwo)
        {
            //return _patternTwoChoice[totalNumber, indexTwo];
            return _patternTwoChoiceDynamic[totalNumber][indexTwo];
        }

        //取得填充題的中文題目
        public string GetPatternOneQuestion()
        {
            return _patternOneQuestion;
        }

        //取得選擇題的英文題目
        public string GetPatternTwoQuestion()
        {
            return _patternTwoQuestion;
        }
        //------------For Unit Test-----------------

        //For Unit Test return系列
        public void SetForUnitTest(string question, int correctChoice)
        {
            _patternOneQuestion = question;
            _patternTwoQuestion = question;
            _correctChoice = correctChoice;

            for (int i = 0; i < Constant.TEN; i++)
            {
                for (int j = 0; j < Constant.FOUR; j++)
                    _patternTwoChoice[j] = question;

                _patternTwoChoiceDynamic.Add(_patternTwoChoice);
            }
        }

        //For Unit Test 回傳題號
        public int GetQuestionNumber()
        {
            return _questionNumber;
        }

        private string _patternOneQuestion;
        private string _patternTwoQuestion;
        private string[] _patternTwoChoice = new string[Constant.FOUR];
        private List<string[]> _patternTwoChoiceDynamic = new List<string[]>();
        //一千題中的某一題的題號 並非totalNumber
        private int _questionNumber;
        //選擇題1-4中 正確的選項
        private int _correctChoice;
        private int _numericUpDownValue;
        private RandomNumber _random;
        private Dictionary _dictionary = new Dictionary();

    }
}
