using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public enum UnitType
    {
        [Description("整数")]
        Integer,
        [Description("分数")]
        Fraction,
        [Description("运算符")]
        Operator,
    }

    public class Unit
    {
        public UnitType UnitType;

        public Fraction Fraction;

        public Operator Operator;

        private static readonly Random random = new Random();

        public static Settings Settings;

        public Unit()
        {
            UnitType = UnitType.Integer;
            Fraction = new Fraction();
            Operator = new Operator();
        }

        public Unit(UnitType unitType, Fraction fraction, Operator @operator)
        {
            UnitType = unitType;
            Fraction = fraction;
            Operator = @operator;
        }

        public override string ToString()
        {
            if (UnitType == UnitType.Fraction)
            {
                ChangeType();
            }

            switch (UnitType)
            {
                case UnitType.Integer:
                    return Fraction.Numerator.ToString();
                case UnitType.Fraction:
                    return Fraction.ToString();
                case UnitType.Operator:
                    return Operator.ToString();
                default:
                    return null;
            }
        }

        /// <summary>
        /// 输出Unit的HTML形式
        /// </summary>
        /// <returns>Unit的HTML形式</returns>
        public string ToHTML()
        {
            if (UnitType == UnitType.Fraction)
            {
                ChangeType();
            }

            switch (UnitType)
            {
                case UnitType.Integer:
                    return Fraction.Numerator.ToString();
                case UnitType.Fraction:
                    return Fraction.ToHTML();
                case UnitType.Operator:
                    return Operator.ToHTML();
                default:
                    return null;
            }
        }

        /// <summary>
        /// 判断Unit是否在范围内
        /// </summary>
        /// <returns>true=>在范围内; false=>不在范围内或Unit是运算符</returns>
        public bool InRange(Settings.OperandSettings operand)
        {
            switch (UnitType)
            {
                case UnitType.Integer:
                    return (Fraction.Numerator <= operand.IntegerMaximum)
                        && (Fraction.Numerator >= operand.IntegerMinimize);
                case UnitType.Fraction:
                    Fraction.Reduce();
                    if (operand.OperandType == Settings.OperandType.TrueFraction)
                    {
                        return (Fraction.Numerator < Fraction.Denomination)
                            && (Fraction.Numerator <= operand.NumeratorMaximum)
                            && (Fraction.Numerator >= operand.NumeratorMinimize)
                            && (Fraction.Denomination <= operand.DenominationMaximum)
                            && (Fraction.Denomination >= operand.DenominationMinimize);
                    }
                    else
                    {
                        return (Fraction.Numerator <= operand.NumeratorMaximum)
                        && (Fraction.Numerator >= operand.NumeratorMinimize)
                        && (Fraction.Denomination <= operand.DenominationMaximum)
                        && (Fraction.Denomination >= operand.DenominationMinimize);
                    }
                default:
                    return false;
            }
        }

        /// <summary>
        /// 获取随机操作数
        /// </summary>
        /// <returns></returns>
        public static Unit GetRandomOperand(Settings.OperandSettings operand)
        {
            Unit unit = new Unit();
            if (Settings.AllowFraction)
            {
                unit.UnitType = ((operand.OperandType == Settings.OperandType.Integer)
                    ? UnitType.Integer : UnitType.Fraction);
            }
            else
            {
                unit.UnitType = UnitType.Integer;
            }

            if (unit.UnitType == UnitType.Integer)
            {
                unit.Fraction = new Fraction(
                    random.Next(operand.IntegerMinimize, operand.IntegerMaximum + 1), 1);
            }
            else
            {
                unit.Fraction = Fraction.GetRandomFraction(operand);
            }

            return unit;
        }

        /// <summary>
        /// 检查Unit的类型, 若应当为整数, 则将类型改为整数; 否则不变
        /// </summary>
        public void ChangeType()
        {
            if (UnitType == UnitType.Operator)
            {
                return;
            }

            if (UnitType == UnitType.Integer)
            {
                Fraction.Denomination = 1;

                return;
            }

            Fraction.Reduce();

            if (Fraction.Denomination == 1)
            {
                UnitType = UnitType.Integer;
            }
            if (Fraction.Numerator == 0)
            {
                UnitType = UnitType.Integer;
            }
        }
        public static Unit operator +(Unit unit1, Unit unit2)
        {
            unit1.ChangeType();
            unit2.ChangeType();
            Unit unit = new Unit(UnitType.Fraction, unit1.Fraction + unit2.Fraction, new Operator());
            unit.ChangeType();

            return unit;
        }
        public static Unit operator -(Unit unit1, Unit unit2)
        {
            unit1.ChangeType();
            unit2.ChangeType();
            Unit unit = new Unit(UnitType.Fraction, unit1.Fraction - unit2.Fraction, new Operator());
            unit.ChangeType();

            return unit;
        }
        public static Unit operator *(Unit unit1, Unit unit2)
        {
            unit1.ChangeType();
            unit2.ChangeType();
            Unit unit = new Unit(UnitType.Fraction, unit1.Fraction * unit2.Fraction, new Operator());
            unit.ChangeType();

            return unit;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit1"></param>
        /// <param name="unit2"></param>
        /// <returns></returns>
        /// <exception cref="DivideByZeroException"></exception>
        public static Unit operator /(Unit unit1, Unit unit2)
        {
            Unit unit;
            unit1.ChangeType();
            unit2.ChangeType();
            try
            {
                unit = new Unit(UnitType.Fraction, unit1.Fraction / unit2.Fraction, new Operator());
            }
            catch
            {
                throw;
            }

            unit.ChangeType();

            return unit;
        }
        /// <summary>
        /// 与Unit2比较
        /// </summary>
        /// <param name="unit2">若为null, 将返回正值</param>
        /// <returns>负值 => 小于; 0 => 等于; 正值 => 大于</returns>
        public int CompareTo(Unit unit2)
        {
            if (unit2 == null)
            {
                return 1;
            }
            if (UnitType < unit2.UnitType)
            {
                return -1;
            }//类型小于unit2
            else if (UnitType > unit2.UnitType)
            {
                return 1;
            }//类型大于unit2
            else
            {
                switch (UnitType)
                {
                    case UnitType.Integer:
                        return Fraction.Numerator.CompareTo(unit2.Fraction.Numerator);
                    case UnitType.Fraction:
                        if (Fraction.Denomination.CompareTo(unit2.Fraction.Denomination) != 0)
                        {
                            return Fraction.Denomination.CompareTo(unit2.Fraction.Denomination);
                        }//分母不相等
                        else
                        {
                            return Fraction.Numerator.CompareTo(unit2.Fraction.Numerator);
                        }//分母相等
                    default:
                        return Operator.Number.CompareTo(unit2.Operator.Number);
                }
            }//类型等于unit2
        }
    }
}
