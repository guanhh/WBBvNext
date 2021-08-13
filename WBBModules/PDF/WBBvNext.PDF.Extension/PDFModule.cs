using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBBvNext.Base;

namespace WBBvNext.WBB.Extension
{
    public class PDFModule : WBBModuleBase, IWBBModule
    {
        public override string Name => "PDF";

        public override string DisplayName => "PDF在线预览服务";

        public override ModuleTypeEnum ModuleType => ModuleTypeEnum.Service;

        public override string Desc => "基于pdf.js提供pdf文件在线预览的能力";
    }
}
