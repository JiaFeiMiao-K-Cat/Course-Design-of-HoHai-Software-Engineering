using AntDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using PWA.Shared.Models;

namespace PWA.Pages
{
    public partial class SettingEdit
    {
        List<CascaderNode> defaultNodes = GetDefaultNodes();

        private static List<CascaderNode> GetDefaultNodes()
        {
            List<CascaderNode> list = new List<CascaderNode>()
            {
                new CascaderNode()
                {
                    Value = "0",
                    Label = "自定义",
                },
            };
            return list;
        }

        private SettingModel.Model model = SettingModel.model;

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
        }
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

        string JSON;//设置项的json形式, 在页面文本框中显示
        void SaveSetting()
        {
            JSON = JsonSerializer.Serialize<Tools.Settings>(model.settings);
        }
    }
}
