using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;


namespace RomanNumerals
{
    public class Parser_V1 : IParser
    {
        public int Eval(string romanExpr)
        {
            if(string.IsNullOrEmpty(romanExpr))
                return this.ThrowInvalidNumeralException(romanExpr);

            return InternalToInt(romanExpr.ToUpperInvariant());
        }

        /// <summary>
        /// This function is called recusively to parse a piece of the 
        /// expression, first the 1000, then the 100, then the 10 and finally the
        /// less than 10.
        /// </summary>
        /// <param name="romanExpr"></param>
        /// <returns></returns>
        private int InternalToInt(string romanExpr)
        {
            // Expression evaluated with success, backtrack
            if (string.IsNullOrEmpty(romanExpr))
                return 0;

            // Evaluation in the exact right order is key

            if (romanExpr.StartsWith("MMMM")) // 4000
                return 4000 + this.InternalToInt(romanExpr.Substring(4));
            else if (romanExpr.StartsWith("MMM")) // 3000
                return 3000 + this.InternalToInt(romanExpr.Substring(3));
            else if (romanExpr.StartsWith("MM"))  // 2000
                return 2000 + this.InternalToInt(romanExpr.Substring(2));
            else if (romanExpr.StartsWith("M"))  // 1000
                return 1000 + this.InternalToInt(romanExpr.Substring(1));

            else if (romanExpr.StartsWith("CM")) // 900
                return 900 + this.InternalToInt(romanExpr.Substring(2));
            else if (romanExpr.StartsWith("DCCC")) // 800
                return 800 + this.InternalToInt(romanExpr.Substring(4));
            else if (romanExpr.StartsWith("DCC")) // 700
                return 700 + this.InternalToInt(romanExpr.Substring(3));
            else if (romanExpr.StartsWith("DC")) // 600
                return 600 + this.InternalToInt(romanExpr.Substring(2));
            else if (romanExpr.StartsWith("D")) // 500
                return 500 + this.InternalToInt(romanExpr.Substring(1));
            else if (romanExpr.StartsWith("CD")) // 400
                return 400 + this.InternalToInt(romanExpr.Substring(2));
            else if (romanExpr.StartsWith("CCC")) // 300
                return 300 + this.InternalToInt(romanExpr.Substring(3));
            else if (romanExpr.StartsWith("CC")) // 200
                return 200 + this.InternalToInt(romanExpr.Substring(2));
            else if (romanExpr.StartsWith("C")) // 100
                return 100 + this.InternalToInt(romanExpr.Substring(1));

            else if (romanExpr.StartsWith("XC")) // 90
                return 90 + this.InternalToInt(romanExpr.Substring(2));
            else if (romanExpr.StartsWith("LXXX")) // 80
                return 80 + this.InternalToInt(romanExpr.Substring(4));
            else if (romanExpr.StartsWith("LXX")) // 70
                return 70 + this.InternalToInt(romanExpr.Substring(3));
            else if (romanExpr.StartsWith("LX")) // 60
                return 60 + this.InternalToInt(romanExpr.Substring(2));
            else if (romanExpr.StartsWith("L")) // 50
                return 50 + this.InternalToInt(romanExpr.Substring(1));
            else if (romanExpr.StartsWith("XL")) // 40
                return 40 + this.InternalToInt(romanExpr.Substring(2));
            else if (romanExpr.StartsWith("XXX")) // 30
                return 30 + this.InternalToInt(romanExpr.Substring(3));
            else if (romanExpr.StartsWith("XX")) // 20
                return 20 + this.InternalToInt(romanExpr.Substring(2));
            else if (romanExpr.StartsWith("X")) // 10
                return 10 + this.InternalToInt(romanExpr.Substring(1));

            else if (romanExpr.StartsWith("IX")) // 9
                return 9 + this.InternalToInt(romanExpr.Substring(2));
            else if (romanExpr.StartsWith("VIII")) // 8
                return 8 + this.InternalToInt(romanExpr.Substring(4));
            else if (romanExpr.StartsWith("VII")) // 7
                return 7 + this.InternalToInt(romanExpr.Substring(3));
            else if (romanExpr.StartsWith("VI")) // 6
                return 6 + this.InternalToInt(romanExpr.Substring(2));
            else if (romanExpr.StartsWith("V")) // 5
                return 5 + this.InternalToInt(romanExpr.Substring(1));
            else if (romanExpr.StartsWith("IV")) // 4
                return 4 + this.InternalToInt(romanExpr.Substring(2));
            else if (romanExpr.StartsWith("III")) // 3
                return 3 + this.InternalToInt(romanExpr.Substring(3));
            else if (romanExpr.StartsWith("II")) // 2
                return 2 + this.InternalToInt(romanExpr.Substring(2));
            else if (romanExpr.StartsWith("I")) // 1
                return 1 + this.InternalToInt(romanExpr.Substring(1));

            return this.ThrowInvalidNumeralException(romanExpr);
        }

        public int ThrowInvalidNumeralException(string roman)
        {
            throw new Exception("Invalid Roman Numeral String: " + roman);
        }
    }
}