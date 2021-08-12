using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using WBBvNext.Base;

namespace WBBvNext.PDF.Extension
{
    public class PDFStaticFileProvider: IStaticFileProvider
    {
        public string GetRequestPath()
        {
            return "/pdf";
        }

        public IFileProvider GetFileProvider()
        {
            var assDir = typeof(PDFStaticFileProvider).Assembly.Location;
            var dir = Directory.GetParent(assDir);

            return new PhysicalFileProvider($"{dir}/pdfjs-dist");
        }
    }
}
