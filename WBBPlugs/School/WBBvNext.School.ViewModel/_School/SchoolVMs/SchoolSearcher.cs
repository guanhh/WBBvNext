using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WBBvNext.School.Model;


namespace WBBvNext.ViewModel._School.SchoolVMs
{
    public partial class SchoolSearcher : BaseSearcher
    {
        [Display(Name = "School.SchoolCode")]
        public String SchoolCode { get; set; }
        [Display(Name = "School.SchoolName")]
        public String SchoolName { get; set; }
        [Display(Name = "School.SchoolType")]
        public SchoolTypeEnum? SchoolType { get; set; }

        protected override void InitVM()
        {
        }

    }
}
