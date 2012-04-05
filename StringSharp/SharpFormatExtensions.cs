using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringSharp
{
    public static class SharpFormatExtensions
    {
        /// <summary>
        /// 'SharpFormat' Replace # with {x++} for string formats. 
        /// For example: String.Format("First {0} is #1 then {1} is #2 after {0} of course",10,20) --> "First # is ##1 then # is ##2 after #0 of course.".SFormat(10,20)
        /// </summary>
        /// <remarks>
        /// Use ## to escape to a single #
        /// Use #n to refer to a previous argument
        /// For Example: "# first # second then #0 first again".SFormat(10,20)
        /// </remarks>
        /// <param name="sharpFormat">String format where {x} is simply replaced with # (the number is inferred)</param>
        /// <param name="args">Arguments to be formatted into the string, passed directly to String.Format(s,args)</param>
        /// <returns>The string formatted by String.Format</returns>
        public static string SharpFormat(this string sharpFormat, params object[] args)
        {
            StringBuilder format = new StringBuilder();
            int argCount = 0;
            int progress = 0;
            while(progress < sharpFormat.Length)
            {
                char current = sharpFormat[progress];
                // fallback on space for the next character to simplify code, 
                //  unimportant as long as it doesn't satisfy any of the next tests below
                char next = progress + 1 < sharpFormat.Length ? sharpFormat[progress + 1] : ' ';
                if (current != SHARP)
                {
                    int nextSharp = sharpFormat.IndexOf(SHARP, progress);
                    int until = nextSharp > 0 ? nextSharp : sharpFormat.Length;
                    format.Append(sharpFormat.Substring(progress, until - progress ));
                    progress = until;
                }
                else if (next == SHARP)
                {
                    format.Append(SHARP);
                    progress += 2;
                }
                else if (char.IsNumber(next))
                {
                    format.Append(String.Format("{{{0}}}", next));
                    progress +=2;
                }
                else // regular old sharp
                {
                    format.Append(String.Format("{{{0}}}", argCount++));
                    ++progress;
                }
            }

            return String.Format(format.ToString(), args);
        }
        private static char SHARP = '#';
        /// <summary>
        /// Shortcut to SharpFormat(...)
        /// </summary>
        /// <param name="sharpFormat"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string SFmt(this string sharpFormat, params object[] args)
        {
            return sharpFormat.SharpFormat(args);
        }

        /// <summary>
        /// For lazies (like me)
        /// </summary>
        /// <param name="sharpFormat"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string SF(this string sharpFormat, params object[] args)
        {
            return sharpFormat.SharpFormat(args);
        }
    }
}
