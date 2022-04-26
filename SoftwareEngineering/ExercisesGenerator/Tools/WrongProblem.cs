using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class WrongProblem
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DisplayName("编号")]
        public long Id { get; set; }
        [DisplayName("日期")]
        public DateTime FirstDate { get; set; }
        //首次错误日期
        public string Problem { get; set; }
        //错题
        [DisplayName("错题")]
        public string ProblemHTML { get; set; }
        //错题的HTML形式
        public string ProblemHash { get; set; }
        //错题生成的表达式树的括号表示法
        public int WrongTimes { get; set; }
        //错误次数
        public int TotalTimes { get; set; }
        //总次数
        public double WrongRate
        {
            get
            {
                return (double) WrongTimes / TotalTimes;
            }
            set
            {
                
            }
        }//错误率
    }
}
