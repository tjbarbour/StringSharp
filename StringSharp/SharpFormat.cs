using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringSharp
{
    public static class SharpFormat
    {
        public static string SFormat(this string str, params object[] args)
        {
            return String.Format(str, args);
        }
    }
}
