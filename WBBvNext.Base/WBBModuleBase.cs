using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBBvNext.Base
{
    public abstract class WBBModuleBase : IWBBModule
    {
        public abstract string Name { get; }
        public abstract string DisplayName { get; }
        public abstract ModuleTypeEnum ModuleType { get; }
        public virtual string Author => "WBBvNext";
        public virtual Version Version => System.Reflection.Assembly.GetAssembly(GetType()).GetName().Version;
        public abstract string Desc { get; }
    }
}
