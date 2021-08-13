using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace WBBvNext.School.Model
{
    public class Company: BasePoco
    {
        [Display(Name = "公司名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string CompanyName { get; set; }

        [Display(Name = "备注")]
        public string Remark { get; set; }
    }
}
