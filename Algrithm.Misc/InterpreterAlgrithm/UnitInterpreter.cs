using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algrithm.InterpreterAlgrithm
{
    abstract class UnitInterpreter
    {
        private const string ZERO = "零";
        public static readonly Dictionary<string, int> MetaNumbers = new Dictionary<string, int>();

        static UnitInterpreter()
        {
            MetaNumbers.Add("一", 1);
            MetaNumbers.Add("二", 2);
            MetaNumbers.Add("两", 2);
            MetaNumbers.Add("三", 3);
            MetaNumbers.Add("四", 4);
            MetaNumbers.Add("五", 5);
            MetaNumbers.Add("六", 6);
            MetaNumbers.Add("七", 7);
            MetaNumbers.Add("八", 8);
            MetaNumbers.Add("九", 9);
        }

        protected abstract UnitInterpreter LeftSubUnitInterpreter
        {
            get;
        }

        protected abstract UnitInterpreter RightRestUnitInterpreter
        {
            get;
        }

        protected abstract int ByNumber
        {
            get;
        }

        protected abstract string Unit
        {
            get;
        }

        public virtual long Interprete(string chineseNumber)
        {
            chineseNumber = chineseNumber.Replace(ZERO, string.Empty);

            long digitNumber = 0;

            if (Unit.Trim().Length == 0) throw new Exception("Unit cannot be empty except Get Unit!");

            int unitIndex = chineseNumber.IndexOf(Unit);
            if (unitIndex == 0) throw new Exception("Invalid Unit in Chinese numbers: " + chineseNumber);

            if (unitIndex < 0)
            {
                Console.WriteLine(string.Format("Next Interpreter [{0}] on [{1}]", RightRestUnitInterpreter.GetType().Name, chineseNumber));
                digitNumber = RightRestUnitInterpreter.Interprete(chineseNumber);
            }
            else
            {
                string leftSubChineseNumber = chineseNumber.Substring(0, unitIndex);
                string rightRestChineseNumber = chineseNumber.Substring(unitIndex + 1);

                Console.WriteLine(string.Format("\r\nSeperate [{0}]: \r\n\t Left Sub Unit Interpreter [{1}] on [{2}] \r\n\t Right Rest Unit Interpreter [{3}] on [{4}]\r\n",
                    chineseNumber,
                    LeftSubUnitInterpreter.GetType().Name, leftSubChineseNumber,
                    RightRestUnitInterpreter.GetType().Name, rightRestChineseNumber));

                long leftSubDigitNumber = LeftSubUnitInterpreter.Interprete(leftSubChineseNumber);
                long rightRestDigitNumber = RightRestUnitInterpreter.Interprete(rightRestChineseNumber);

                digitNumber = leftSubDigitNumber * ByNumber + rightRestDigitNumber;
            }

            Console.WriteLine(string.Format("Interpreted digit number by [{0}] is [{1}]", this.GetType().Name, digitNumber));

            return digitNumber;
        }
    }
}
