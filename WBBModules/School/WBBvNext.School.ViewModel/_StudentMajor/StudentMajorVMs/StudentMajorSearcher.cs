using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WBBvNext.School.Model;


namespace WBBvNext.ViewModel._StudentMajor.StudentMajorVMs
{
    public partial class StudentMajorSearcher : BaseSearcher
    {
        public Guid? MajorId { get; set; }
        public Guid? StudentId { get; set; }

        protected override void InitVM()
        {
        }

    }
}
