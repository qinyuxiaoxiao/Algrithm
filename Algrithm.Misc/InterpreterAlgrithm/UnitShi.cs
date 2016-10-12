using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algrithm.InterpreterAlgrithm
{
    class UnitShi : UnitInterpreter
    {
        private const int BY_NUMBER = 10;
        private const string UNIT = "十";

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
                return new UnitGe();
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
