using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algrithm.InterpreterAlgrithm
{
    class UnitQian : UnitInterpreter
    {
        private const int BY_NUMBER = 1000;
        private const string UNIT = "千";

        protected override UnitInterpreter LeftSubUnitInterpreter
        {
            get
            {
                return new UnitGe();
            }
        }

        protected override UnitInterpreter RightRestUnitInterpreter
        {
            get
            {
                return new UnitBai();
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
                return UNIT;
            }
        }
    }
}
