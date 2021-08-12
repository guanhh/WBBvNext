using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingTec.Mvvm.Mvc
{
    public interface ICSService
    {
        string GetCunrrentCS(IBaseController controller);
    }

    public class DefaultCSService : ICSService
    {
        public string GetCunrrentCS(IBaseController controller)
        {
            return null;
        }
    }
}
