﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WBBvNext.School.Model;


namespace WBBvNext.ViewModel._Major.MajorVMs
{
    public partial class MajorBatchVM : BaseBatchVM<Major, Major_BatchEdit>
    {
        public MajorBatchVM()
        {
            ListVM = new MajorListVM();
            LinkedVM = new Major_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Major_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
