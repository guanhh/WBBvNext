using System;
using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace WtmBlazorUtils
{
    public class CulturePage : ComponentBase
    {
        [Parameter]
        public Type MainPageType { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            Type componentTyype = null;
            CultureInfo cl = CultureInfo.CurrentUICulture;
            while (cl != null)
            {
                string typename = MainPageType.Namespace + "." + MainPageType.Name + "_" + cl.Name.ToLower();
                componentTyype = Type.GetType(typename);
                if(componentTyype != null)
                {
                    break;
                }
                cl = cl.Parent;
            }
            if (componentTyype != null)
            {
                builder.OpenComponent(0, componentTyype);
                builder.CloseComponent();

            }
            base.BuildRenderTree(builder);
        }
    }
}
