using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WBBvNext.Feedback.Model;


namespace WBBvNext.ViewModel._Feedback.SuggestionVMs
{
    public partial class SuggestionListVM : BasePagedListVM<Suggestion_View, SuggestionSearcher>
    {

        protected override IEnumerable<IGridColumn<Suggestion_View>> InitGridHeader()
        {
            return new List<GridColumn<Suggestion_View>>{
                this.MakeGridHeader(x => x.Title),
                this.MakeGridHeader(x => x.Detail),
                this.MakeGridHeader(x => x.QuestionType),
                this.MakeGridHeader(x => x.UserName),
                this.MakeGridHeader(x => x.Email),
                this.MakeGridHeader(x => x.IsSolved),
                this.MakeGridHeader(x => x.Remark),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Suggestion_View> GetSearchQuery()
        {
            var query = DC.Set<Suggestion>()
                .CheckEqual(Searcher.QuestionType, x=>x.QuestionType)
                .CheckEqual(Searcher.IsSolved, x=>x.IsSolved)
                .Select(x => new Suggestion_View
                {
				    ID = x.ID,
                    Title = x.Title,
                    Detail = x.Detail,
                    QuestionType = x.QuestionType,
                    UserName = x.UserName,
                    Email = x.Email,
                    IsSolved = x.IsSolved,
                    Remark = x.Remark,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Suggestion_View : Suggestion{

    }
}
