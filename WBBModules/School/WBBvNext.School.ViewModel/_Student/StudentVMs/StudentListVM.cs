using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WBBvNext.School.Model;


namespace WBBvNext.ViewModel._Student.StudentVMs
{
    public partial class StudentListVM : BasePagedListVM<Student_View, StudentSearcher>
    {

        protected override IEnumerable<IGridColumn<Student_View>> InitGridHeader()
        {
            return new List<GridColumn<Student_View>>{
                this.MakeGridHeader(x => x.LoginName),
                this.MakeGridHeader(x => x.Password),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.CellPhone),
                this.MakeGridHeader(x => x.ZipCode),
                this.MakeGridHeader(x => x.EnRollDate),
                this.MakeGridHeader(x => x.PhotoId).SetFormat(PhotoIdFormat),
                this.MakeGridHeader(x => x.MajorName_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }
        private List<ColumnFormatInfo> PhotoIdFormat(Student_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.PhotoId),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.PhotoId,640,480),
            };
        }


        public override IOrderedQueryable<Student_View> GetSearchQuery()
        {
            var query = DC.Set<Student>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckWhere(Searcher.SelectedStudentMajorIDs,x=>DC.Set<StudentMajor>().Where(y=>Searcher.SelectedStudentMajorIDs.Contains(y.MajorId)).Select(z=>z.StudentId).Contains(x.ID))
                .Select(x => new Student_View
                {
				    ID = x.ID,
                    LoginName = x.LoginName,
                    Password = x.Password,
                    Name = x.Name,
                    CellPhone = x.CellPhone,
                    ZipCode = x.ZipCode,
                    EnRollDate = x.EnRollDate,
                    PhotoId = x.PhotoId,
                    MajorName_view = x.StudentMajor.Select(y=>y.Major.MajorName).ToSepratedString(null,","), 
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Student_View : Student{
        [Display(Name = "专业名称")]
        public String MajorName_view { get; set; }

    }
}
