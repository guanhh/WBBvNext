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
    public partial class StudentMajorTemplateVM : BaseTemplateVM
    {
        public ExcelPropety Major_Excel = ExcelPropety.CreateProperty<StudentMajor>(x => x.MajorId);
        public ExcelPropety Student_Excel = ExcelPropety.CreateProperty<StudentMajor>(x => x.StudentId);

	    protected override void InitVM()
        {
            Major_Excel.DataType = ColumnDataType.ComboBox;
            Major_Excel.ListItems = DC.Set<Major>().GetSelectListItems(Wtm, y => y.MajorName);
            Student_Excel.DataType = ColumnDataType.ComboBox;
            Student_Excel.ListItems = DC.Set<Student>().GetSelectListItems(Wtm, y => y.LoginName);
        }

    }

    public class StudentMajorImportVM : BaseImportVM<StudentMajorTemplateVM, StudentMajor>
    {

    }

}
