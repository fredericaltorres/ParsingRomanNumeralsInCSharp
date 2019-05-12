using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;


namespace RomanNumerals
{
    public class Parser_V1
    {
        public int ToInt(string roman)
        {
            if (string.IsNullOrEmpty(roman)) // Expression evaluated with success
                return 0;

            roman = roman.ToUpperInvariant();

            // Evaluation in the exact right order is key

            if (roman.StartsWith("MMMM")) // 4000
                return 4000 + this.ToInt(roman.Substring(3));
            else if (roman.StartsWith("MMM")) // 3000
                return 3000 + this.ToInt(roman.Substring(3));
            else if (roman.StartsWith("MM"))  // 2000
                return 2000 + this.ToInt(roman.Substring(2));
            else if (roman.StartsWith("M"))  // 1000
                return 1000 + this.ToInt(roman.Substring(1));

            else if (roman.StartsWith("CM")) // 900
                return 900 + this.ToInt(roman.Substring(2));
            else if (roman.StartsWith("DCCC")) // 800
                return 800 + this.ToInt(roman.Substring(4));
            else if (roman.StartsWith("DCC")) // 700
                return 700 + this.ToInt(roman.Substring(3));
            else if (roman.StartsWith("DC")) // 600
                return 600 + this.ToInt(roman.Substring(2));
            else if (roman.StartsWith("D")) // 500
                return 500 + this.ToInt(roman.Substring(1));
            else if (roman.StartsWith("CD")) // 400
                return 400 + this.ToInt(roman.Substring(2));
            else if (roman.StartsWith("CCC")) // 300
                return 300 + this.ToInt(roman.Substring(3));
            else if (roman.StartsWith("CC")) // 200
                return 200 + this.ToInt(roman.Substring(2));
            else if (roman.StartsWith("C")) // 100
                return 100 + this.ToInt(roman.Substring(1));

            else if (roman.StartsWith("XC")) // 90
                return 90 + this.ToInt(roman.Substring(2));
            else if (roman.StartsWith("LXXX")) // 80
                return 80 + this.ToInt(roman.Substring(4));
            else if (roman.StartsWith("LXX")) // 70
                return 70 + this.ToInt(roman.Substring(3));
            else if (roman.StartsWith("LX")) // 60
                return 60 + this.ToInt(roman.Substring(2));
            else if (roman.StartsWith("L")) // 50
                return 50 + this.ToInt(roman.Substring(1));
            else if (roman.StartsWith("XL")) // 40
                return 40 + this.ToInt(roman.Substring(2));
            else if (roman.StartsWith("XXX")) // 30
                return 30 + this.ToInt(roman.Substring(3));
            else if (roman.StartsWith("XX")) // 20
                return 20 + this.ToInt(roman.Substring(2));
            else if (roman.StartsWith("X")) // 10
                return 10 + this.ToInt(roman.Substring(1));

            else if (roman.StartsWith("IX")) // 9
                return 9 + this.ToInt(roman.Substring(2));
            else if (roman.StartsWith("VIII")) // 8
                return 8 + this.ToInt(roman.Substring(4));
            else if (roman.StartsWith("VII")) // 7
                return 7 + this.ToInt(roman.Substring(3));
            else if (roman.StartsWith("VI")) // 6
                return 6 + this.ToInt(roman.Substring(2));
            else if (roman.StartsWith("V")) // 5
                return 5 + this.ToInt(roman.Substring(1));
            else if (roman.StartsWith("IV")) // 4
                return 4 + this.ToInt(roman.Substring(2));
            else if (roman.StartsWith("III")) // 3
                return 3 + this.ToInt(roman.Substring(3));
            else if (roman.StartsWith("II")) // 2
                return 2 + this.ToInt(roman.Substring(2));
            else if (roman.StartsWith("I")) // 1
                return 1 + this.ToInt(roman.Substring(1));

            return this.ThrowInvalidNumeralException(roman);
        }

	    public int ThrowInvalidNumeralException(string roman)
	    {
		    throw new Exception("Invalid Roman Numeral String: " + roman);
	    }
    }
}