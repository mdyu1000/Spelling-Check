﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    class Question
    {
        //Question初始化
        public void Initialize(RandomNumber random)
        {
            _random = random;
            _dictionary.SetDictionary();
            _dictionary.SetWord();
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

            for (int i = 0; i < Constant.TEN; i++)
            {
                for (int j = 0; j < Constant.FOUR; j++)
                {
                    if (j == _correctChoice)
                        _patternTwoChoice[i, j] = _dictionary.GetWord()[_questionNumber].GetChinese();
                    else
                        _patternTwoChoice[i, j] = _dictionary.GetWord()[_random.GetWrongQuestionNumber(i, temp++)].GetChinese();
                }

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
            return _patternTwoChoice[totalNumber, indexTwo];
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

        private string _patternOneQuestion;
        private string _patternTwoQuestion;
        private string[,] _patternTwoChoice = new string[Constant.TEN, Constant.FOUR];
        //一千題中的某一題的題號 並非totalNumber
        private int _questionNumber;
        //選擇題1-4中 正確的選項
        private int _correctChoice;
        private RandomNumber _random = new RandomNumber();
        private Dictionary _dictionary = new Dictionary();

    }
}
