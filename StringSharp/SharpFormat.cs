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
                if (current == SHARP && next == SHARP)
                {
                    format.Append(SHARP);
                    ++i;
                }
                else if (current == SHARP && char.IsNumber(next))
                {
                    format.Append(String.Format("{{{0}}}", next));
                    ++i;
                }
                else if (current == SHARP)
                {
                    format.Append(String.Format("{{{0}}}", argCount++));
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
