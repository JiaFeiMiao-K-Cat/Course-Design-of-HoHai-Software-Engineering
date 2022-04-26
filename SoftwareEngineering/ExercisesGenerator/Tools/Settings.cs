using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Settings
    {
        public int ThinkTime { get; set; } = 60;
        public int ProblemsNumber { get; set; } = 40;
        public int OperatorsNumber { get; set; } = 2;
        public bool AllowParentheses { get; set; }
        public bool AllowFraction { get; set; }

        public enum OperandType
        {
            [Description("整数")]
            Integer,
            [Description("真分数")]
            TrueFraction,
            [Description("假分数")]
            FalseFraction,
        }

        public class OperandSettings
        {
            public OperandType OperandType { get; set; }
            public int IntegerMinimize { get; set; }
            public int IntegerMaximum { get; set; }
            public int NumeratorMinimize { get; set; }
            public int NumeratorMaximum { get; set; }
            public int DenominationMinimize { get; set; }
            public int DenominationMaximum { get; set; }

            public OperandSettings()
            {
            }

            public OperandSettings(OperandType operandType, int integerMinimize,
                int integerMaximum, int numeratorMinimize, int numeratorMaximum,
                int denominationMinimize, int denominationMaximum)
            {
                OperandType = operandType;
                IntegerMinimize = integerMinimize;
                IntegerMaximum = integerMaximum;
                NumeratorMinimize = numeratorMinimize;
                NumeratorMaximum = numeratorMaximum;
                DenominationMinimize = denominationMinimize;
                DenominationMaximum = denominationMaximum;
            }
        }

        public class OperatorSettings
        {
            public bool AllowPlus { get; set; }
            public bool AllowSubscribe { get; set; }
            public bool AllowMultiply { get; set; }
            public bool AllowDivide { get; set; }

            public OperatorSettings()
            {
            }

            public OperatorSettings(bool allowPlus, bool allowSubscribe,
                bool allowMultiply, bool allowDivide)
            {
                AllowPlus = allowPlus;
                AllowSubscribe = allowSubscribe;
                AllowMultiply = allowMultiply;
                AllowDivide = allowDivide;
            }
        }

        public List<OperandSettings> Operands { get; set; }
        public List<OperatorSettings> Operators { get; set; }

        public Settings()
        {
            Operands = new() { new OperandSettings(), new OperandSettings(), new OperandSettings(), new OperandSettings(), };
            Operators = new() { new OperatorSettings(), new OperatorSettings() };
        }
    }
}
