using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using PWA.Shared.Models;
using Tools;

namespace PWA.Pages
{
    public partial class Generator
    {
        Tools.Settings settings = SettingModel.model.settings;
        TableData tableData = new TableData();
        bool Hidden = false;
        protected override async Task OnInitializedAsync()
        {
            DataBaseTools.DbFactory = DbFactory;
            SettingModel.JS = JS;
            await SettingModel.Init();
        }
        void Print()
        {
            JS.InvokeVoidAsync("PrintDiv", "PrintDiv");
        }
        void Generate()
        {
            tableData.Exercises = new List<TableData.Exercise>();
            tableData.Expressions = new HashSet<string>();
            for (int i = 0; i < settings.ProblemsNumber; i++)
            {
                List<Unit> Problem = Expression.GetRandomExpression();
                List<Unit> Postfix = Expression.InfixToPostfix(Problem);
                Unit Answer;
                try
                {
                    Answer = Expression.CalculatePostfix(Postfix);
                }
                catch (Exception)
                {
                    i--;
                    continue;
                }
                if (!Answer.InRange(settings.Operands.Last()))
                {
                    i--;
                    continue;
                }
                string tree = Expression.PostfixToTree(Postfix).ToString();
                if (tableData.Expressions.Add(tree))
                {
                    tableData.Exercises.Add(new TableData.Exercise(i + 1, Problem, Answer));
                }
                else
                {
                    i--;
                    continue;
                }
            }
        }
    }
}
