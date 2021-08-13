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
    public partial class SchoolTemplateVM : BaseTemplateVM
    {
        [Display(Name = "School.SchoolCode")]
        public ExcelPropety SchoolCode_Excel = ExcelPropety.CreateProperty<WBBvNext.School.Model.School>(x => x.SchoolCode);
        [Display(Name = "School.SchoolName")]
        public ExcelPropety SchoolName_Excel = ExcelPropety.CreateProperty<WBBvNext.School.Model.School>(x => x.SchoolName);
        [Display(Name = "School.SchoolType")]
        public ExcelPropety SchoolType_Excel = ExcelPropety.CreateProperty<WBBvNext.School.Model.School>(x => x.SchoolType);
        [Display(Name = "School.Remark")]
        public ExcelPropety Remark_Excel = ExcelPropety.CreateProperty<WBBvNext.School.Model.School>(x => x.Remark);

	    protected override void InitVM()
        {
        }

    }

    public class SchoolImportVM : BaseImportVM<SchoolTemplateVM, WBBvNext.School.Model.School>
    {

    }

}
