using AntDesign.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PWA.Shared.Models;
using Tools;

namespace PWA.Pages
{
    public partial class MyStatist
    {
        IChartComponent chart;

        List<Tools.Statist> statists = DataBaseTools.Statists;

        DataItem[] ExerciseData;//练习情况

        DataItem[] RedoData;//重做情况
        protected override async Task OnInitializedAsync()
        {
            SettingModel.JS = JS;
            DataBaseTools.DbFactory = DbFactory;
            await SettingModel.Init();
            await base.OnInitializedAsync();
            OnTabChanged("1");
        }

        private async void OnTabChanged(string activeKey)
        {
            if (activeKey == "1")
            {
                await DataBaseTools.Refresh();
                statists = DataBaseTools.Statists;
                ConvertToExerciseData(statists);
                ConvertToRedoData(statists);
                await chart.ChangeData(ExerciseData);
            }
            else
            {
                await DataBaseTools.Refresh();
                statists = DataBaseTools.Statists;
                ConvertToExerciseData(statists);
                ConvertToRedoData(statists);
                await chart.ChangeData(RedoData);
            }
        }

        public class DataItem
        {
            public string date { get; set; }
            public int count { get; set; }
            public string type { get; set; }

            public DataItem(string date, int count, string type)
            {
                this.date = date;
                this.count = count;
                this.type = type;
            }
        }

        /// <summary>
        /// 获得做题情况
        /// </summary>
        /// <param name="Statists">统计表</param>
        void ConvertToExerciseData(List<Tools.Statist> Statists)
        {
            ExerciseData = new DataItem[2 * Statists.Count];
            for (int i = 0; i < Statists.Count; i++)
            {
                ExerciseData[i] = new DataItem(
                    Statists[i].Date.ToString("yyyy/MM/dd"),
                    Statists[i].TotalTimes, "做题总数");
                ExerciseData[i + Statists.Count] = new DataItem(
                    Statists[i].Date.ToString("yyyy/MM/dd"),
                    Statists[i].WrongTimes, "错误数量");
            }
        }

        /// <summary>
        /// 获得重做情况
        /// </summary>
        /// <param name="Statists">统计表</param>
        void ConvertToRedoData(List<Tools.Statist> Statists)
        {
            RedoData = new DataItem[2 * Statists.Count];
            for (int i = 0; i < Statists.Count; i++)
            {
                RedoData[i] = new DataItem(
                    Statists[i].Date.ToString("yyyy/MM/dd"),
                    Statists[i].RedoTotalTimes, "重做总数");
                RedoData[i + Statists.Count] = new DataItem(
                    Statists[i].Date.ToString("yyyy/MM/dd"),
                    Statists[i].RedoWrongTimes, "再次错误数量");
            }
        }

        bool IsLoading = false;
        async Task ChangeData()
        {
            IsLoading = true;
            StateHasChanged();
            //刷新UI, 防止多次点击出现问题

            //更新数据
            await DataBaseTools.Refresh();
            statists = DataBaseTools.Statists;
            ConvertToExerciseData(statists);
            ConvertToRedoData(statists);
            //更新数据

            IsLoading = false;
            StateHasChanged();
        }

        #region 做题情况

        readonly LineConfig configExercise = new LineConfig
        {
            Title = new Title
            {
                Visible = true,
                Text = "做题情况统计"
            },

            Description = new Description
            {
                Visible = true,
                Text = "每日做题总数与错误数量"
            },

            ForceFit = true,
            Padding = "auto",
            XField = "date",
            YField = "count",
            YAxis = new ValueAxis
            {
                Label = new BaseAxisLabel()
            },
            Interactions = new[]
            {
                new Interaction
                {
                    Type = "slider",
                    Cfg = new
                    {
                        start = 0,
                        end = 1,
                    }
                }
            },
            Point = new LineViewConfigPoint
            {
                Visible = true,
                Size = 5,
                Shape = "diamond",
                Style = new GraphicStyle
                {
                    Fill = "white",
                    Stroke = "#FAA219",
                    LineWidth = 2
                }
            },
            SeriesField = "type",
            Color = new string[] { "#1979C9", "#D62A0D" },
        };

        #endregion 做题情况

        #region 错题重做情况

        readonly LineConfig configRedo = new LineConfig
        {
            Title = new Title
            {
                Visible = true,
                Text = "错题重做情况统计"
            },

            Description = new Description
            {
                Visible = true,
                Text = "每日重做错题总数与再次错误数量"
            },

            ForceFit = true,
            Padding = "auto",
            XField = "date",
            YField = "count",
            YAxis = new ValueAxis
            {
                Label = new BaseAxisLabel()
            },
            Interactions = new[]
            {
                new Interaction
                {
                    Type = "slider",
                    Cfg = new
                    {
                        start = 0,
                        end = 1,
                    }
                }
            },
            Point = new LineViewConfigPoint
            {
                Visible = true,
                Size = 5,
                Shape = "diamond",
                Style = new GraphicStyle
                {
                    Fill = "white",
                    Stroke = "#FAA219",
                    LineWidth = 2
                }
            },
            SeriesField = "type",
            Color = new string[] { "#1979C9", "#D62A0D" },
        };

        #endregion 错题重做情况
    }
}
