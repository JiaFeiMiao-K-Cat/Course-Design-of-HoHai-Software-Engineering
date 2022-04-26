using AntDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Tools;
using PWA.Shared.Models;

namespace PWA.Pages
{
    public partial class Wrongs
    {
        //部分代码同Exercise.razor.cs

        List<WrongProblem> wrongs = DataBaseTools.Wrongs;
        //错题

        protected override async Task OnInitializedAsync()
        {
            DataBaseTools.DbFactory = DbFactory;
            await DataBaseTools.Refresh();
            //优先更新数据库
            SettingModel.JS = JS;
            await SettingModel.Init();
            wrongs = DataBaseTools.Wrongs;
            CloneList();
            Shuffle(redoWrongs);
            await base.OnInitializedAsync();
        }

        /// <summary>
        /// 删除错题
        /// </summary>
        /// <param name="Id">错题ID</param>
        public async void Delete(long Id)
        {
            IsLoading = true;
            StateHasChanged();
            await DataBaseTools.RemoveErrorProblem(Id);
            wrongs = DataBaseTools.Wrongs;
            CloneList();
            Shuffle(redoWrongs);
            IsLoading = false;
            StateHasChanged();
        }

        private int pageSize { get; set; } = 10;
        private int pageIndex { get; set; } = 1;
        private void HandlePageChange(PaginationEventArgs args)
        {
            if (pageIndex != args.Page)
            {
                pageIndex = args.Page;
            }

            if (pageSize != args.PageSize)
            {
                pageSize = args.PageSize;
            }
        }

        bool RedoMode = false;

        public class InputModel
        {
            public int Integer { get; set; } = 0;
            public int Numerator { get; set; } = 0;
            public int Denomination { get; set; } = 0;
            public void Refresh()
            {
                Integer = 0;
                Numerator = 0;
                Denomination = 0;
            }
        }
        private InputModel inputModel = new() { };

        private SettingModel.Model model = SettingModel.model;

        List<WrongProblem> redoWrongs; //用于重做的错题集, 乱序

        List<Unit> Problem;

        Unit Answer;

        string CheckStyle = @"oi oi-question-mark";

        bool IsFraction = false;
        bool IsInteger = false;

        private static System.Timers.Timer timer;
        private int counter = 0;
        public void Dispose()
        {
            timer?.Dispose();
        }

        int RedoCount = 0;

        bool IsFirstProblem = true;

        private bool IsLoading = false;
        public async void NextProblem()
        {
            inputModel.Refresh();
            if (RedoCount == redoWrongs.Count)
            {
                counter = 0;
                timer?.Dispose();
                RedoCount = 0;
                wrongs = DataBaseTools.Wrongs;
                CloneList();
                Shuffle(redoWrongs);
                IsFirstProblem = true;
                CheckStyle = @"oi oi-question-mark";
                Problem = new List<Unit>();
                Answer = new Unit();
                IsFraction = false;
                IsInteger = false;
                StateHasChanged();
                await _message.Success("恭喜你又重做了一遍错题");
                return;
            }
            Problem = Expression.StringToExpression(redoWrongs[RedoCount].Problem);
            Answer = Expression.CalculatePostfix(Expression.InfixToPostfix(Problem));
            RedoCount++;
            if (Answer.UnitType == UnitType.Integer)
            {
                IsInteger = true;
                IsFraction = false;
            }
            else
            {
                IsInteger = false;
                IsFraction = true;
            }
            IsFirstProblem = false;
            counter = model.settings.ThinkTime;
            timer?.Dispose();
            CheckStyle = @"oi oi-question-mark";
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
            await DataBaseTools.AddErrorProblem(Problem, false);
            await DataBaseTools.AddRedoStatist(false);
            NextProblem();
            IsLoading = false;
            StateHasChanged();
        }
        public async void Check()
        {
            IsLoading = true;
            StateHasChanged();
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
                await DataBaseTools.AddRedoStatist(true);
                await Task.Delay(1000);
                NextProblem();
            }
            else
            {
                CheckStyle = @"oi oi-x";
                if (counter == 0)
                {
                    await DataBaseTools.AddErrorProblem(Problem, false);
                    await DataBaseTools.AddRedoStatist(false);
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

        private static Random rng = new Random();

        /// <summary>
        /// 生成乱序版错题集
        /// </summary>
        /// <param name="list">需要打乱顺序的错题集</param>
        public static void Shuffle(List<WrongProblem> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                WrongProblem value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// 复制wrongs到redoWrongs
        /// </summary>
        private void CloneList()
        {
            redoWrongs = new List<WrongProblem>(wrongs.Count);
            for (int i = 0; i < wrongs.Count; i++)
            {
                redoWrongs.Add(wrongs[i]);
            }
        }
    }
}
