using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Algrithm.InterpreterAlgrithm
{
    class NumberInterpreter
    {
        //                                  "(九千八百八十七万五千六百零一亿)(八千四百二十一万)(六千)(四百)(五十)(二)";
        public const string ChineseNumber = "九千八百八十七万五千六百零一亿八千四百二十一万六千四百五十二";
        //public const string ChineseNumber = "两千四百三十万五千六百七十九";
        //public const string ChineseNumber = "三十万六百";


        public static long Execute()
        {
            /* 在该程序中，目前所知道的最大单位是“亿”，即UnitYi.
               将来如果需要识别更大的单位如“兆”，那么只需要扩展增加新的类UnitZhao。
               外界只需要知道当前所知的最大单位，而不需要知道其他单位
            */
            UnitInterpreter currentKnownMaxUnit = new UnitYi();
            long digitNumber = currentKnownMaxUnit.Interprete(ChineseNumber);
            Console.WriteLine(digitNumber);
            return digitNumber;
        }

    }
}
