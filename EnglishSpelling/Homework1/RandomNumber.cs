using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    public class RandomNumber
    {
        //結構子
        public RandomNumber(int numericUpDownValue, bool isUnitTest)
        {
            if (isUnitTest)
                _numberRandom = new Random(1);
            else
                _numberRandom = new Random(Guid.NewGuid().GetHashCode());

            //把wrongQuestionNumber[][]都設定為-1
            _numericUpDownValue = numericUpDownValue;
            SetWrongQuestionNumberInitial();

            //生成10個亂數作為題號1-1000
            for (int i = 0; i < numericUpDownValue; i++)
            {
                _number = _numberRandom.Next(0, Constant.THOUSAND);

                if (_randomNumber.Count == 0)
                    _randomNumber.Add(_number);
                else
                    SetRandomPatternOne(_randomNumber);
            }

            SetWrongQuestionThree();
        }

        //SetRandom Part2
        private void SetRandomPatternOne(List<int> numberArray)
        {
            while (true)
            {
                CheckRepeatPatternOne(numberArray);

                //若未重複count=隨機數目陣列的數量
                if (_repeatCount == numberArray.Count)
                {
                    numberArray.Add(_number);
                    break;
                }

                _repeatCount = 0;
            }
        }

        //設三個錯誤的變數在每題的選擇題   !!!每次都要執行一次!!!
        public void SetWrongQuestionThree()
        {
            for (int i = 0; i < _numericUpDownValue; i++)
            {
                SetWrongQuestionNumberInitial();

                for (int j = 0; j < Constant.THREE; j++)
                {
                    SetWrongQuestionThreePartTwo(i);
                    _wrongQuestionNumber[j] = _number;
                }
            }
        }

        //SetWrongQuestionThree  Part2
        public void SetWrongQuestionThreePartTwo(int index)
        {
            while (true)
            {
                _number = _numberRandom.Next(0, Constant.THOUSAND);

                if (IsConflictPatternTwo(_number, index))
                    break;
            }
        }

        //檢查重複
        public void CheckRepeatPatternOne(List<int> numberArray)
        {
            //檢查現有陣列裡的數字 若為重複就++ 重複則跳出重新生成
            for (int j = 0; j < numberArray.Count; j++)
            {
                if (_number != numberArray[j])
                    _repeatCount++;
                else
                {
                    _number = _numberRandom.Next(0, Constant.THOUSAND);
                    break;
                }
            }
        }

        //檢查Pattern2的陣列是否衝突到該題號的題目編號(randomNumber index)  跟 wrongNumber各自是否重複
        public bool IsConflictPatternTwo(int randomNumber, int index)
        {
            if (randomNumber == _randomNumber[index])
                return false;

            for (int i = 0; i < Constant.THREE; i++)
            {
                if (randomNumber == _wrongQuestionNumber[i])
                    return false;
            }

            return true;
        }

        //取得亂數陣列
        public int GetRandom(int index)
        {
            return _randomNumber[index];
        }

        //取得另外三個錯誤題目的編號
        public int GetWrongQuestionNumber(int index)
        {
            return _wrongQuestionNumber[index];
        }

        //取得題型  0為填充  1為選擇
        public int GetQuestionPattern()
        {
            return _numberRandom.Next(0, Constant.TWO);
        }

        //取得選擇題 正確的選項
        public int GetRealQuestionNumber()
        {
            return _numberRandom.Next(0, Constant.FOUR);
        }

        //將_wrongQuestionNumber全部設為初始值-1
        private void SetWrongQuestionNumberInitial()
        {
            for (int j = 0; j < Constant.THREE; j++)
                _wrongQuestionNumber[j] = -1;
        }

        //----------For Unit Test-------------

        //取得_number
        public int GetDashNumber()
        {
            return _number;
        }

        Random _numberRandom;
        private List<int> _randomNumber = new List<int>();
        private int[] _wrongQuestionNumber = new int[Constant.THREE];
        private int _number;
        private int _repeatCount;
        private int _numericUpDownValue;

    }
}
