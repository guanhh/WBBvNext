using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBBvNext.Base
{
    public interface IWBBModule
    {
        string Name { get; }

        string DisplayName { get; }

        ModuleTypeEnum ModuleType { get; }

        string Author { get; }

        Version Version { get; }

        string Desc { get; }
    }
}
