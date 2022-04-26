using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;
using PWA.Shared.Models;

namespace PWA.Pages
{
    public partial class Exercise
    {
        public class InputModel
        {
            //整数
            public int Integer { get; set; } = 0;

            //分子
            public int Numerator { get; set; } = 0;

            //分母
            public int Denomination { get; set; } = 0;

            /// <summary>
            /// 重置输入框数据
            /// </summary>
            public void Refresh()
            {
                Integer = 0;
                Numerator = 0;
                Denomination = 0;
            }
        }

        private InputModel inputModel = new() { };//输入

        private SettingModel.Model model = SettingModel.model;//设置

        List<Unit> Problem;//习题

        Unit Answer;//答案

        string CheckStyle = @"oi oi-question-mark";//状态

        bool IsFraction = false;
        bool IsInteger = false;
        bool IsFirstProblem = true;

        private static System.Timers.Timer timer;//计时器
        private int counter = 0;//剩余时间
        public void Dispose()
        {
            timer?.Dispose();
        }

        int ExerciseCount = 0;//已做题目数量

        private bool IsLoading = false;

        /// <summary>
        /// 生成新题目
        /// </summary>
        public async void NewProblem()
        {
            inputModel.Refresh();
            if (ExerciseCount == model.settings.ProblemsNumber)
            {
                counter = 0;
                timer?.Dispose();
                ExerciseCount = 0;
                CheckStyle = @"oi oi-question-mark";
                IsFirstProblem = true;
                Problem = new List<Unit>();
                Answer = new Unit();
                IsFraction = false;
                IsInteger = false;
                StateHasChanged();
                await _message.Success("恭喜你又完成了一组练习");
                return;
            }//完成一组, 重置状态
            while (true)
            {
                try
                {
                    Problem = Expression.GetRandomExpression();
                    Answer = Expression.CalculatePostfix(Expression.InfixToPostfix(Problem));
                    if (Answer.InRange(model.settings.Operands.Last()))
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (Exception)
                {
                    continue;
                }//出现异常说明题目不合法或不合设置
            }
            Answer.ChangeType();
            if (Answer.UnitType == UnitType.Integer)
            {
                IsInteger = true;
                IsFraction = false;
            }//整数
            else
            {
                IsInteger = false;
                IsFraction = true;
            }//分数

            //刷新UI
            counter = model.settings.ThinkTime;
            timer?.Dispose();
            CheckStyle = @"oi oi-question-mark";
            ExerciseCount++;
            IsFirstProblem = false;
            StartTimer();
        }

        public async void SkipProblem()
        {
            if (Problem == null || Problem.Count == 0)
            {
                return;
            }

            IsLoading = true;
            StateHasChanged();
            //刷新UI, 防止多次点击出现问题

            await DataBaseTools.AddErrorProblem(Problem, false);
            NewProblem();

            IsLoading = false;
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            DataBaseTools.DbFactory = DbFactory;
            await DataBaseTools.Refresh();
            //优先处理数据库, 顺序不要调换
            SettingModel.JS = JS;
            await SettingModel.Init();
            await base.OnInitializedAsync();
        }

        public async void Check()
        {
            IsLoading = true;
            StateHasChanged();
            //刷新UI, 防止多次点击出现问题

            Unit unit = new Unit();
            if (IsInteger)
            {
                unit = new Unit(UnitType.Integer,
                    new Fraction(inputModel.Integer, 1),
                    null);
            }
            if (IsFraction)
            {
                unit = new Unit(UnitType.Fraction,
                    new Fraction(inputModel.Numerator, inputModel.Denomination),
                    null);
            }
            if (Answer.CompareTo(unit) == 0)
            {
                CheckStyle = @"oi oi-check";
                await DataBaseTools.AddErrorProblem(Problem, true);
                await Task.Delay(1000);
                NewProblem();
            }
            else
            {
                CheckStyle = @"oi oi-x";
                if (counter == 0)
                {
                    await DataBaseTools.AddErrorProblem(Problem, false);
                }
            }
            IsLoading = false;
            StateHasChanged();
        }

        public void StartTimer()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += CountDownTimer;
            timer.Enabled = true;
        }

        public void CountDownTimer(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (counter > 0)
            {
                counter -= 1;
            }
            else
            {
                timer.Enabled = false;
                Check();
            }
            StateHasChanged();
        }
    }
}
