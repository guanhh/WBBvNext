using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBBvNext.Base;

namespace WBBvNext.WBB.Extension
{
    public class DocModule : WBBModuleBase, IWBBModule
    {
        public override string Name => "Doc";

        public override string DisplayName => "WBBvNext文档模块";

        public override ModuleTypeEnum ModuleType => ModuleTypeEnum.Document;

        public override string Desc => "WBBvNext使用说明";
    }
}
