﻿using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBBvNext.Base
{
    public interface IStaticFileProvider
    {
        string GetRequestPath();

        IFileProvider GetFileProvider();
    }
}
