using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PWA.Shared.Models
{
    public class JavaScriptInvoke
    {
        public static IJSRuntime JS;

        /// <summary>
        /// 打印div
        /// </summary>
        /// <param name="DivID">需要打印的div的id</param>
        public static async Task Print(string DivID)
        {
            await JS.InvokeVoidAsync("PrintDiv", DivID);
        }

        /// <summary>
        /// 隐藏或显示答案
        /// </summary>
        /// <param name="ShowAnswer">是否显示答案, true => 显示, false => 隐藏</param>
        public static async Task ChangeAnswersDisplay(bool ShowAnswer)
        {
            await JS.InvokeVoidAsync("ChangeDisplay", "showexercises", 2,
                (ShowAnswer ? "" : "none"));
        }

        /// <summary>
        /// 保存到文件
        /// </summary>
        /// <param name="Text">文件内容</param>
        /// <param name="FileName">文件名</param>
        public static async Task SaveToFile(string Text, string FileName)
        {
            await JS.InvokeVoidAsync("Save", Text, FileName);
        }

        /// <summary>
        /// 弹窗显示消息
        /// </summary>
        /// <param name="text">需要显示的消息</param>
        public static async void ShowMessage(string text)
        {
            await JS.InvokeVoidAsync("ShowMessage", text);
        }

        /// <summary>
        /// 获取 Local Storage
        /// </summary>
        /// <returns>JSON字符串形式的设置项</returns>
        public static async Task<string> GetLocalSettings()
        {
            string json = await JS.InvokeAsync<string>(
                "BlazorGetLocalStorage", "LocalSettings");
            return json;
        }

        /// <summary>
        /// 保存设置到 Local Storage
        /// </summary>
        /// <param name="json">设置项的JSON字符串</param>
        public static async Task SaveLocalSettings(string json)
        {
            await JS.InvokeVoidAsync("BlazorSetLocalStorage", "LocalSettings", json);
        }
    }
}
