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
    public partial class StudentMajorBatchVM : BaseBatchVM<StudentMajor, StudentMajor_BatchEdit>
    {
        public StudentMajorBatchVM()
        {
            ListVM = new StudentMajorListVM();
            LinkedVM = new StudentMajor_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class StudentMajor_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
