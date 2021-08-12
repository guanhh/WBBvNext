using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Attributes;

namespace WBBvNext.School.Model
{
    [MiddleTable]
    public class StudentMajor : BasePoco
    {
        public Major Major { get; set; }
        public Student Student { get; set; }

        [Display(Name = "专业ID")]
        public Guid MajorId { get; set; }

        [Display(Name = "学生ID")]
        public Guid StudentId { get; set; }
    }
}
