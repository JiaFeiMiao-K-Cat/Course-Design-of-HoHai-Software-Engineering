using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Operator
    {
        public char Value;

        public int Number;

        public int Propriety;

        public char HTMLValue;

        public Operator()
        {
        }

        public Operator(char value, int number, int propriety)
        {
            Value = value;
            Number = number;
            Propriety = propriety;
        }

        public Operator(char value, int number, int propriety, char hTMLValue) : this(value, number, propriety)
        {
            Value = value;
            Number = number;
            Propriety = propriety;
            HTMLValue = hTMLValue;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public string ToHTML()
        {
            return HTMLValue.ToString();
        }
    }
}
