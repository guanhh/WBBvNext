using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WBBvNext.School.Model;


namespace WBBvNext.ViewModel._StudentMajor.StudentMajorVMs
{
    public partial class StudentMajorVM : BaseCRUDVM<StudentMajor>
    {

        public StudentMajorVM()
        {
            SetInclude(x => x.Major);
            SetInclude(x => x.Student);
        }

        protected override void InitVM()
        {
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
