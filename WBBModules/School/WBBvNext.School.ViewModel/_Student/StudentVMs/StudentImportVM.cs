using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WBBvNext.School.Model;


namespace WBBvNext.ViewModel._Student.StudentVMs
{
    public partial class StudentTemplateVM : BaseTemplateVM
    {
        [Display(Name = "账号")]
        public ExcelPropety LoginName_Excel = ExcelPropety.CreateProperty<Student>(x => x.LoginName);
        [Display(Name = "密码")]
        public ExcelPropety Password_Excel = ExcelPropety.CreateProperty<Student>(x => x.Password);
        [Display(Name = "姓名")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Student>(x => x.Name);
        [Display(Name = "手机")]
        public ExcelPropety CellPhone_Excel = ExcelPropety.CreateProperty<Student>(x => x.CellPhone);
        [Display(Name = "邮编")]
        public ExcelPropety ZipCode_Excel = ExcelPropety.CreateProperty<Student>(x => x.ZipCode);
        [Display(Name = "日期")]
        public ExcelPropety EnRollDate_Excel = ExcelPropety.CreateProperty<Student>(x => x.EnRollDate);

	    protected override void InitVM()
        {
        }

    }

    public class StudentImportVM : BaseImportVM<StudentTemplateVM, Student>
    {

    }

}
