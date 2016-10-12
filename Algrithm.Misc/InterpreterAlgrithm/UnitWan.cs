using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algrithm.InterpreterAlgrithm
{
    class UnitWan : UnitInterpreter
    {
        private const int BY_NUMBER = 10000;
        private const string UNIT = "万";
        
        protected override UnitInterpreter LeftSubUnitInterpreter
        {
            get
            {
                return new UnitQian();
            }
        }

        protected override UnitInterpreter RightRestUnitInterpreter
        {
            get
            {
                return new UnitQian();
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
