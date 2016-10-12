using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algrithm.InterpreterAlgrithm
{
    class UnitGe : UnitInterpreter
    {
        private const int BY_NUMBER = 1;

        protected override UnitInterpreter LeftSubUnitInterpreter
        {
            get
            {
                return null;
            }
        }

        protected override UnitInterpreter RightRestUnitInterpreter
        {
            get
            {
                return null;
            }
        }

        protected override int ByNumber
        {
            get
            {
                return BY_NUMBER;
            }
        }

        protected override string Unit
        {
            get
            {
                return string.Empty;
            }
        }

        public override long Interprete(string chineseNumber)
        {
            long digitNumber = 0;

            if (chineseNumber.Trim().Length > 0)
            {
                if (chineseNumber.Trim().Length != 1) throw new Exception("The number cannot be recoginized for Ge Unit: " + chineseNumber);

                digitNumber = MetaNumbers[chineseNumber];
            }

            return digitNumber;
        }
    }
}
