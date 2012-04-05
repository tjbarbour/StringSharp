using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringSharp
{
    public static class SharpFormat
    {
        public static string SFormat(this string sharpFormat, params object[] args)
        {
            // for trolls
            if (sharpFormat == null) return String.Format(sharpFormat, args); // punt

            StringBuilder format = new StringBuilder();
            for (int i = 0; i < sharpFormat.Length; i++)
            {
                if (sharpFormat[i] == '#' && sharpFormat[i+1] == '#')
                {
                    format.Append('#');
                    ++i;
                }
                else if (sharpFormat[i] == '#')
                {
                    format.Append("{0}");
                }
                else
                {
                    format.Append(sharpFormat[i]);
                }
            }

            return String.Format(format.ToString(), args);
        }
    }
}
