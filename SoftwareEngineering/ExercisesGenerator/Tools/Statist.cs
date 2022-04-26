using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Statist
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }
        public DateTime Date { get; set; }
        //日期
        public int WrongTimes { get; set; }
        //错误次数
        public int TotalTimes { get; set; }
        //总次数
        public int RedoWrongTimes { get; set; }
        //错题重做错误次数
        public int RedoTotalTimes { get; set; }
        //错题重做总次数
    }
}
