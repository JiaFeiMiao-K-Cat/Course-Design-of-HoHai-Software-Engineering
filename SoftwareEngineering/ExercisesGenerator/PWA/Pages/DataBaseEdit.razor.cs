using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PWA.Shared.Models;

namespace PWA.Pages
{
    public partial class DataBaseEdit
    {
        Tools.Statist statist = new Tools.Statist();
        protected override async Task OnInitializedAsync()
        {
            statist.Date = DateTime.Today;
            await base.OnInitializedAsync();
        }

        /// <summary>
        /// 添加统计数据
        /// </summary>
        /// <returns></returns>
        async Task AddStatist()
        {
            using var db = await DbFactory.Create<MyDataBase>();
            try
            {
                var Element = db.Statists.Single(x => x.Id == statist.Id);
                Element.TotalTimes = statist.TotalTimes;
                Element.WrongTimes = statist.WrongTimes;
                Element.RedoTotalTimes = statist.RedoTotalTimes;
                Element.RedoWrongTimes = statist.RedoWrongTimes;
            }
            catch
            {
                db.Statists.Add(statist);
            }
            await db.SaveChanges();
        }
    }
}
