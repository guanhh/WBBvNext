using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WBBvNext.School.Model;


namespace WBBvNext.ViewModel._School.SchoolVMs
{
    public partial class SchoolListVM : BasePagedListVM<School_View, SchoolSearcher>
    {

        protected override IEnumerable<IGridColumn<School_View>> InitGridHeader()
        {
            return new List<GridColumn<School_View>>{
                this.MakeGridHeader(x => x.SchoolCode),
                this.MakeGridHeader(x => x.SchoolName),
                this.MakeGridHeader(x => x.SchoolType),
                this.MakeGridHeader(x => x.PdfFileId).SetFormat(PdfFileIdFormat),
                this.MakeGridHeader(x => x.Remark),
                this.MakeGridHeaderAction(width: 200)
            };
        }
        private List<ColumnFormatInfo> PdfFileIdFormat(School_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.PdfFileId),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.PdfFileId,640,480),
            };
        }


        public override IOrderedQueryable<School_View> GetSearchQuery()
        {
            var query = DC.Set<WBBvNext.School.Model.School>()
                .CheckContain(Searcher.SchoolCode, x=>x.SchoolCode)
                .CheckContain(Searcher.SchoolName, x=>x.SchoolName)
                .CheckEqual(Searcher.SchoolType, x=>x.SchoolType)
                .Select(x => new School_View
                {
				    ID = x.ID,
                    SchoolCode = x.SchoolCode,
                    SchoolName = x.SchoolName,
                    SchoolType = x.SchoolType,
                    PdfFileId = x.PdfFileId,
                    Remark = x.Remark,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class School_View : WBBvNext.School.Model.School
    {

    }
}
