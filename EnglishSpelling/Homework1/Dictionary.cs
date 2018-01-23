using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Homework1
{
    public class Dictionary
    {
        //結構子
        public Dictionary()
        {
            StreamReader file = new StreamReader(Constant.FILE, Encoding.Default);

            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                //正規表達式:"\\s+>>> "
                string[] resultString = Regex.Split(line, Constant.PATTERN);

                //將txt全丟入dictionary裡 偶數為英文 奇數為中文
                foreach (string element in resultString)
                    this._dictionary.Add(element);
            }

            SetWord();
        }

        //將中文寫入
        private void SetChinese(int index)
        {
            string[] resultString = Regex.Split(_dictionary[index], Constant.PATTERN_CHINESE);

            foreach (string element in resultString)
            {
                _chinese = element;
                //為了不要讓它存入空白字串
                break;
            }
        }

        //將英文寫入
        private void SetEnglish(int index)
        {
            this._english = _dictionary[index];
            this._englishHide = _dictionary[index];
        }

        //將英文馬掉
        private void SetEnglishHide(int index)
        {
            if (_englishHide.Length == 1)
                _englishHide = Constant.UNDERLINE;
            else if (_englishHide.Length == Constant.TWO)
                _englishHide = Constant.UNDERLINE_DOUBLE;
            else
                SetEnglishHidePlus();
        }

        //將英文馬掉Part2
        private void SetEnglishHidePlus()
        {
            Regex pattern = new Regex(Constant.ENGLISH_HIDE);
            string maskString = "";
            string underline = null;

            if (!string.IsNullOrEmpty(_englishHide))
            {
                maskString = _englishHide.Substring(1, _englishHide.Length - Constant.TWO);

                for (int j = 0; j < maskString.Length; j++)
                    if (pattern.IsMatch(maskString[j].ToString()))
                        underline += Constant.UNDERLINE;
                    else
                        underline += maskString[j];
            }

            _englishHide = _englishHide.Replace(maskString, underline);
        }

        //設定Word.cs
        private void SetWord()
        {
            for (int i = 0; i < _dictionary.Count; i += Constant.TWO)
            {
                SetChinese(i + 1);
                SetEnglish(i);
                SetEnglishHide(i);
                _word.Add(new Word(_chinese, _english, _englishHide));
            }
        }

        //回傳Word.cs內的內容
        public List<Word> GetWord()
        {
            return _word;
        }

        private List<string> _dictionary = new List<string>();
        private string _english;
        private string _chinese;
        private string _englishHide;
        private List<Word> _word = new List<Word>();
    }
}
