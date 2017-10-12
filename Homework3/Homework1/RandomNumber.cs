using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    class RandomNumber
    {
        //設置十個亂數陣列
        public void SetRandom()
        {
            //把wrongQuestionNumber[][]都設定為-1
            SetWrongQuestionNumberInitial();

            //生成10個亂數作為題號1-1000
            for (int i = 0; i < Constant.TEN; i++)
            {
                _number = _numberRandom.Next(0, Constant.THOUSAND);

                if (_randomNumber.Count == 0)
                    _randomNumber.Add(_number);
                else
                    SetRandomPatternOne(_randomNumber);
            }

            SetWrongQuestionThree();
        }

        //設三個錯誤的變數在每題的選擇題
        private void SetWrongQuestionThree()
        {
            for (int i = 0; i < Constant.TEN; i++)
            {
                for (int j = 0; j < Constant.THREE; j++)
                {
                    while (true)
                    {
                        _number = _numberRandom.Next(0, Constant.THOUSAND);

                        if (IsConflictPatternTwo(_number, i))
                            break;
                    }

                    _wrongQuestionNumber[i, j] = _number;
                }
            }
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

        //檢查重複
        private void CheckRepeatPatternOne(List<int> numberArray)
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
        private bool IsConflictPatternTwo(int randomNumber, int index)
        {
            if (randomNumber == _randomNumber[index])
                return false;

            for (int i = 0; i < Constant.THREE; i++)
            {
                if (randomNumber == _wrongQuestionNumber[index, i])
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
        public int GetWrongQuestionNumber(int index, int indexTwo)
        {
            return _wrongQuestionNumber[index, indexTwo];
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
            for (int i = 0; i < Constant.TEN; i++)
                for (int j = 0; j < Constant.THREE; j++)
                    _wrongQuestionNumber[i, j] = -1;
        }

        //這樣宣告比較不容易取得重複數字
        Random _numberRandom = new Random(Guid.NewGuid().GetHashCode());
        private List<int> _randomNumber = new List<int>();
        private int[,] _wrongQuestionNumber = new int[Constant.TEN, Constant.THREE];
        private int _number;
        private int _repeatCount;
    }
}
