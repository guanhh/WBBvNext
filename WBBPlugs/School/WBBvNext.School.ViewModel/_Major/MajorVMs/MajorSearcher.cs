using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WBBvNext.School.Model;


namespace WBBvNext.ViewModel._Major.MajorVMs
{
    public partial class MajorSearcher : BaseSearcher
    {
        [Display(Name = "专业编码")]
        public String MajorCode { get; set; }
        [Display(Name = "专业名称")]
        public String MajorName { get; set; }
        public Guid? SchoolId { get; set; }
        [Display(Name = "学生")]
        public List<Guid> SelectedStudentMajorsIDs { get; set; }

        protected override void InitVM()
        {
        }

    }
}
