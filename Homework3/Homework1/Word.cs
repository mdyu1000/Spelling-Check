using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Homework1
{
    class Word
    {
        //初始化Word
        public Word(string chinese, string english, string englishHide)
        {
            _chinese = chinese;
            _english = english;
            _englishHide = englishHide;
        }

        //取得中文
        public string GetChinese()
        {
            return _chinese;
        }

        //取得英文
        public string GetEnglish()
        {
            return _english;
        }

        //取得英文遮罩版
        public string GetEnglishHide()
        {
            return _englishHide;
        }

        private string _english;
        private string _chinese;
        private string _englishHide;
    }
}
