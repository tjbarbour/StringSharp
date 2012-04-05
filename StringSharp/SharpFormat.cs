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
            StringBuilder format = new StringBuilder();
            for (int i = 0; i < sharpFormat.Length; i++)
            {
                char current = sharpFormat[i];
                char next = i + 1 < sharpFormat.Length ? sharpFormat[i + 1] : ' ';
                if (current == '#' && next == '#')
                {
                    format.Append('#');
                    ++i;
                }
                else if (current == '#')
                {
                    format.Append("{0}");
                }
                else
                {
                    format.Append(current);
                }
            }

            return String.Format(format.ToString(), args);
        }
    }
}
