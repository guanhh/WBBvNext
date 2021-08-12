using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBBvNext.Base;

namespace WBBvNext.Doc.Extension
{
    public class DocStaticFileProvider : IStaticFileProvider
    {
        public string GetRequestPath()
        {
            return "/images";
        }

        public IFileProvider GetFileProvider()
        {
            var assDir = typeof(DocStaticFileProvider).Assembly.Location;
            var dir = Directory.GetParent(assDir);

            return new PhysicalFileProvider($"{dir}/Doc/Images");
        }
    }
}
