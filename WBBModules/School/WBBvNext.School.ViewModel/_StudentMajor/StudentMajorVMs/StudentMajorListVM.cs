using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WBBvNext.School.Model;


namespace WBBvNext.ViewModel._StudentMajor.StudentMajorVMs
{
    public partial class StudentMajorListVM : BasePagedListVM<StudentMajor_View, StudentMajorSearcher>
    {

        protected override IEnumerable<IGridColumn<StudentMajor_View>> InitGridHeader()
        {
            return new List<GridColumn<StudentMajor_View>>{
                this.MakeGridHeader(x => x.MajorName_view),
                this.MakeGridHeader(x => x.LoginName_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<StudentMajor_View> GetSearchQuery()
        {
            var query = DC.Set<StudentMajor>()
                .CheckEqual(Searcher.MajorId, x=>x.MajorId)
                .CheckEqual(Searcher.StudentId, x=>x.StudentId)
                .Select(x => new StudentMajor_View
                {
				    ID = x.ID,
                    MajorName_view = x.Major.MajorName,
                    LoginName_view = x.Student.LoginName,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class StudentMajor_View : StudentMajor{
        [Display(Name = "专业名称")]
        public String MajorName_view { get; set; }
        [Display(Name = "账号")]
        public String LoginName_view { get; set; }

    }
}
