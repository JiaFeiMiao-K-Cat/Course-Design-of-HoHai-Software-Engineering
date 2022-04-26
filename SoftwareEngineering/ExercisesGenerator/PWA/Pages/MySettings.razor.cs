using AntDesign;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using PWA.Shared.Models;

namespace PWA.Pages
{
    public partial class MySettings
    {
        List<CascaderNode> defaultNodes = GetDefaultNodes();

        private static List<CascaderNode> GetDefaultNodes()
        {
            List<CascaderNode> list = new List<CascaderNode>()
            {
                new CascaderNode()
                {
                    Value = "1",
                    Label = "一年级",
                    Children = new CascaderNode[]
                    {
                        new CascaderNode
                        {
                            Value = "11",
                            Label = "上册",
                            Children = new CascaderNode[]
                            {
                                new CascaderNode
                                {
                                    Value = "113",
                                    Label = "第三单元 5 以内的加减法",
                                },
                                new CascaderNode
                                {
                                    Value = "115",
                                    Label = "第五单元 10 以内的加减法",
                                },
                                new CascaderNode
                                {
                                    Value = "118",
                                    Label = "第八单元 20以内的加法",
                                },
                            }
                        },
                        new CascaderNode
                        {
                            Value = "12",
                            Label = "下册",
                            Children = new CascaderNode[]
                            {
                                new CascaderNode
                                {
                                    Value = "122",
                                    Label = "第二单元 20 以内的减法",
                                },
                                new CascaderNode
                                {
                                    Value = "126",
                                    Label = "第六单元 100 以内的加减法 1",
                                },
                            }
                        },
                    }
                },
                new CascaderNode()
                {
                    Value = "2",
                    Label = "二年级",
                    Children = new CascaderNode[]
                    {
                        new CascaderNode
                        {
                            Value = "21",
                            Label = "上册",
                            Children = new CascaderNode[]
                            {
                                new CascaderNode
                                {
                                    Value = "212",
                                    Label = "第二单元 100 以内的加减法 2",
                                },
                            }
                        },
                        new CascaderNode
                        {
                            Value = "22",
                            Label = "下册",
                            Children = new CascaderNode[]
                            {
                                new CascaderNode
                                {
                                    Value = "225",
                                    Label = "第五单元 加减乘除的混合运算",
                                },
                            }
                        },
                    }
                },
                new CascaderNode()
                {
                    Value = "3",
                    Label = "三年级",
                    Children = new CascaderNode[]
                    {
                        new CascaderNode
                        {
                            Value = "31",
                            Label = "上册",
                            Children = new CascaderNode[]
                            {
                                new CascaderNode
                                {
                                    Value = "311",
                                    Label = "第一单元 万以内加减法 1",
                                },
                                new CascaderNode
                                {
                                    Value = "314",
                                    Label = "第四单元 万以内加减法 2",
                                },
                                new CascaderNode
                                {
                                    Value = "316",
                                    Label = "第六单元 多位数乘一位数",
                                },
                                new CascaderNode
                                {
                                    Value = "318",
                                    Label = "第八单元 真分数简单运算",
                                },
                            }
                        },
                        new CascaderNode
                        {
                            Value = "32",
                            Label = "下册",
                            Children = new CascaderNode[]
                            {
                                new CascaderNode
                                {
                                    Value = "322",
                                    Label = "第二单元 除数是一位数的除法",
                                },
                                new CascaderNode
                                {
                                    Value = "324",
                                    Label = "第四单元 两位数乘两位数",
                                },
                            }
                        },
                    }
                },
                new CascaderNode()
                {
                    Value = "4",
                    Label = "四年级",
                    Children = new CascaderNode[]
                    {
                        new CascaderNode
                        {
                            Value = "41",
                            Label = "上册",
                            Children = new CascaderNode[]
                            {
                                new CascaderNode
                                {
                                    Value = "414",
                                    Label = "第四单元 三位数乘两位数",
                                },
                                /*new CascaderNode
                                {
                                    Value = "416",
                                    Label = "第六单元 除数是两位数的除法",
                                },*/
                            }
                        },
                        new CascaderNode
                        {
                            Value = "42",
                            Label = "下册",
                            Children = new CascaderNode[]
                            {
                                new CascaderNode
                                {
                                    Value = "421",
                                    Label = "第一单元 四则运算",
                                },
                                new CascaderNode
                                {
                                    Value = "424",
                                    Label = "第四单元 两位数乘两位数",
                                },
                            }
                        },
                    }
                },
                new CascaderNode()
                {
                    Value = "5",
                    Label = "五年级",
                    Children = new CascaderNode[]
                    {
                        new CascaderNode
                        {
                            Value = "52",
                            Label = "下册",
                            Children = new CascaderNode[]
                            {
                                new CascaderNode
                                {
                                    Value = "526",
                                    Label = "第六单元 分数的加减法",
                                },
                            }
                        },
                    }
                },
                new CascaderNode()
                {
                    Value = "6",
                    Label = "六年级",
                    Children = new CascaderNode[]
                    {
                        new CascaderNode
                        {
                            Value = "61",
                            Label = "上册",
                            Children = new CascaderNode[]
                            {
                                new CascaderNode
                                {
                                    Value = "611",
                                    Label = "第一单元 分数乘法",
                                },
                                new CascaderNode
                                {
                                    Value = "613",
                                    Label = "第三单元 分数除法",
                                },
                            }
                        },
                    }
                },
                new CascaderNode()
                {
                    Value = "0",
                    Label = "自定义",
                },
            };
            return list;
        }

        private SettingModel.Model model = SettingModel.model;

        bool showAdvanceSetting = false;

        protected override async Task OnInitializedAsync()
        {
            SettingModel.JS = JS;
            await SettingModel.Init();
            await base.OnInitializedAsync();
        }

        void OnChange(CascaderNode[] selectedNodes)
        {
            model.settings = JsonSerializer.Deserialize<Tools.Settings>
                (DefaultSettings.Default[model.value]);
            if (model.value == "0")
            {
                showAdvanceSetting = true;
            }
            StateHasChanged();
        }

        int Invoke
        {
            get
            {
                return model.settings.OperatorsNumber;
            }
            set
            {
                model.settings.OperatorsNumber = value;
                OnChangeOperatorsNumber(value);
            }
        }//运算符数量的封装, 用于动态调整List大小

        /// <summary>
        /// 调整Liast的大小
        /// </summary>
        /// <param name="number">List大小</param>
        void OnChangeOperatorsNumber(int number)
        {
            Tools.Settings.OperatorSettings[] Operators
                = new Tools.Settings.OperatorSettings[number];
            for (int i = 0; i < number; i++)
            {
                Operators[i] = new Tools.Settings.OperatorSettings();
            }
            Tools.Settings.OperandSettings[] Operands
                = new Tools.Settings.OperandSettings[number + 2];
            for (int i = 0; i < number + 2; i++)
            {
                Operands[i] = new Tools.Settings.OperandSettings();
            }
            model.settings.Operators = new List<Tools.Settings.OperatorSettings>(Operators);
            model.settings.Operands = new List<Tools.Settings.OperandSettings>
                (Operands);
        }

        class MyType
        {
            public string Name;
            public Tools.Settings.OperandType Value;

            public MyType(string Name, Tools.Settings.OperandType Value)
            {
                this.Name = Name;
                this.Value = Value;
            }
        }

        List<MyType> types = new()
        {
            new("整数", Tools.Settings.OperandType.Integer),
            new("真分数", Tools.Settings.OperandType.TrueFraction),
            new("假分数", Tools.Settings.OperandType.FalseFraction),
        };

        bool IsLoading = false;
        async void SaveSetting()
        {
            IsLoading = true;
            StateHasChanged();
            //刷新UI, 防止多次点击出现问题
            await SettingModel.SaveSetting();
            IsLoading = false;
            StateHasChanged();
            await _message.Success("保存成功");
        }
    }
}
