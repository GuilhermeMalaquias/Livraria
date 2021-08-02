using System;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Library.App.Extension
{
    public static class DocumentTypeFormat
    {
        public static string FormatDocument(this RazorPage page, int pessoaTipo, string documento)
        {
            return pessoaTipo == 1
                ? Convert.ToUInt64(documento).ToString(@"000\.000\.000\-00")
                : Convert.ToUInt64(documento).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}
