using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringSharp
{
    public static class SharpFormat
    {
        private static char SHARP = '#';
        public static string SFormat(this string sharpFormat, params object[] args)
        {
            StringBuilder format = new StringBuilder();
            int argCount = 0;
            for (int i = 0; i < sharpFormat.Length; i++)
            {
                char current = sharpFormat[i];
                char next = i + 1 < sharpFormat.Length ? sharpFormat[i + 1] : ' ';
                if (current != SHARP)
                {
                    int nextSharp = sharpFormat.IndexOf(SHARP, i);
                    int until = nextSharp > 0 ? nextSharp : sharpFormat.Length;
                    format.Append(sharpFormat.Substring(i, until - i ));
                    i = until - 1;
                }
                else if (next == SHARP)
                {
                    format.Append(SHARP);
                    ++i;
                }
                else if (char.IsNumber(next))
                {
                    format.Append(String.Format("{{{0}}}", next));
                    ++i;
                }
                else
                {
                    format.Append(String.Format("{{{0}}}", argCount++));
                }
            }

            return String.Format(format.ToString(), args);
        }
    }
}
