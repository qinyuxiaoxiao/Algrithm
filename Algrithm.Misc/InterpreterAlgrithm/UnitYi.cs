using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algrithm.InterpreterAlgrithm
{
    class UnitYi : UnitInterpreter
    {
        private const int BY_NUMBER = 100000000;
        private const string UNIT = "亿";
        
        protected override UnitInterpreter LeftSubUnitInterpreter
        {
            get
            {
                return new UnitWan();
            }
        }

        protected override UnitInterpreter RightRestUnitInterpreter
        {
            get
            {
                return new UnitWan();
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
