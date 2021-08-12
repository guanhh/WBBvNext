using BootstrapBlazor.Components;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using WtmBlazorUtils;

namespace WBBvNext.School.Page.Pages._Chart.Chart
{
    public partial class Line : BasePage
    {
        [NotNull]
        private BootstrapBlazor.Components.Chart? LineChart { get; set; }
        private Random Randomer { get; } = new Random();
        private int LineDatasetCount = 2;
        private int LineDataCount = 7;

        private Task<ChartDataSource> OnInit(float tension, bool hasNull)
        {
            var ds = new ChartDataSource();
            ds.Options.Title = "Line 折线图";
            ds.Options.X.Title = "天数";
            ds.Options.Y.Title = "数值";
            ds.Labels = Enumerable.Range(1, LineDataCount).Select(i => i.ToString());
            for (var index = 0; index < LineDatasetCount; index++)
            {
                ds.Data.Add(new ChartDataset()
                {
                    Tension = tension,
                    Label = $"数据集 {index}",
                    Data = Enumerable.Range(1, LineDataCount).Select((i, index) => (index == 2 && hasNull) ? null! : (object)Randomer.Next(20, 37))
                });
            }
            return Task.FromResult(ds);
        }

        private Task OnAfterInit()
        {
            return Task.CompletedTask;
        }

        private Task OnAfterUpdate(ChartAction action)
        {
            return Task.CompletedTask;
        }

    }
}
