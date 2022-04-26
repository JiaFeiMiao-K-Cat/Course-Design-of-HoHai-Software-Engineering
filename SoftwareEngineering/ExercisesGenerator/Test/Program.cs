using System;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace Test
{
    class Program
    {
        public class Exercise
        {
            public int Number;
            //题号
            public List<Unit> Problem;
            //题目
            public Unit Answer;
            //答案

            public Exercise()
            {
            }

            public Exercise(int number, List<Unit> problem, Unit answer)
            {
                Number = number;
                Problem = problem;
                Answer = answer;
            }
        }
        static void Main(string[] args)
        {
            /*Console.WriteLine("题目数量: ");
            Settings.ProblemsNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("运算符数量: ");
            Settings.OperatorsNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("整数最小值: ");
            Settings.IntegerMinimize = int.Parse(Console.ReadLine());
            Console.WriteLine("整数最大值: ");
            Settings.IntegerMaximum = int.Parse(Console.ReadLine());
            Console.WriteLine("分母最大值: ");
            Settings.DenominationMaximum = int.Parse(Console.ReadLine());
            Console.WriteLine("括号: ");
            Settings.AllowParentheses = (int.Parse(Console.ReadLine()) & 1) == 1;
            Console.WriteLine("加: ");
            Settings.AllowPlus = (int.Parse(Console.ReadLine()) & 1) == 1;
            Console.WriteLine("减: ");
            Settings.AllowSubscribe = (int.Parse(Console.ReadLine()) & 1) == 1;
            Console.WriteLine("乘: ");
            Settings.AllowMultiply = (int.Parse(Console.ReadLine()) & 1) == 1;
            Console.WriteLine("除: ");
            Settings.AllowDivide = (int.Parse(Console.ReadLine()) & 1) == 1;
            Console.WriteLine("分数: ");
            Settings.AllowFraction = (int.Parse(Console.ReadLine()) & 1) == 1;*/
            
            Settings Settings = new Settings();
            Settings.ProblemsNumber = 10000;
            Settings.OperatorsNumber = 3;
            Settings.AllowParentheses = true;
            Settings.AllowFraction = true;
            Settings.Operands = new()
            {
                new(Settings.OperandType.FalseFraction,
                    0, 1000, 0, 2000, 2, 1000),
                new(Settings.OperandType.FalseFraction,
                    0, 1000, 0, 2000, 2, 1000),
                new(Settings.OperandType.FalseFraction,
                    0, 1000, 0, 2000, 2, 1000),
                new(Settings.OperandType.FalseFraction,
                    0, 1000, 0, 2000, 2, 1000),
                new(Settings.OperandType.FalseFraction,
                    0, 1000, 0, 2000, 2, 1000),
            };
            Settings.Operators = new()
            {
                new(true, true, true, true),
                new(true, true, true, true),
                new(true, true, true, true),
            };

            Expression.Settings = Settings;
            Fraction.Settings = Settings;
            Unit.Settings = Settings;

            DateTime time1 = DateTime.Now;

            List<Exercise> exercises = new List<Exercise>(Settings.ProblemsNumber + 2);
            //习题
            HashSet<String> expressions = new HashSet<string>(Settings.ProblemsNumber + 2);
            //用于去重的HashSet

            for (int i = 1; i <= Settings.ProblemsNumber; i++)
            {
                List<Unit> infix = Expression.GetRandomExpression();
                List<Unit> postfix = Expression.InfixToPostfix(infix);

                Unit answer;
                try
                {
                    answer = Expression.CalculatePostfix(postfix);
                    if (answer.InRange(Settings.Operands.Last())){
                        throw new Exception();
                    }
                }
                catch
                {
                    i--;
                    continue;
                }

                Node root = Expression.PostfixToTree(postfix);
                String tree = root.ToString();
                if (expressions.Add(tree))
                {
                    exercises.Add(new Exercise(i, infix, answer));
                }//没有重复
                else
                {
                    i--;
                }//存在重复
            }

            DateTime time2 = DateTime.Now;

            Console.WriteLine((time2 - time1).TotalMilliseconds + "ms");
        }
    }
}
