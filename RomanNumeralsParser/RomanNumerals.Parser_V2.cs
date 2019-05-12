using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;


namespace RomanNumerals
{
    internal class ParsingRule {
        public string Expression;
        public int Value;
        internal ParsingRule(string expression, int value)
        {
            this.Expression = expression;
            this.Value = value;
        }
        public int GetExpressionLen()
        {
            return this.Expression.Length;
        }
    }
    internal class ParsingRules : List<ParsingRule>
    {
        public ParsingRules Add(string expression, int value)
        {
            this.Add(new ParsingRule(expression, value));
            return this;
        }
    }

    public class Parser_V2 : IParser
    {
        /// <summary>
        /// Evaluation must occur in the exact order the rules are declared
        /// </summary>
        private ParsingRules _parsingRules = new ParsingRules()
              .Add("MMMM", 4000)
              .Add("MMM", 3000)
              .Add("MM", 2000)
              .Add("M", 1000)
              .Add("CM", 900)
              .Add("DCCC", 800)
              .Add("DCC", 700)
              .Add("DC", 600)
              .Add("D", 500)
              .Add("CD", 400)
              .Add("CCC", 300)
              .Add("CC", 200)
              .Add("C", 100)
              .Add("XC", 90)
              .Add("LXXX", 80)
              .Add("LXX", 70)
              .Add("LX", 60)
              .Add("L", 50)
              .Add("XL", 40)
              .Add("XXX", 30)
              .Add("XX", 20)
              .Add("X", 10)
              .Add("IX", 9)
              .Add("VIII", 8)
              .Add("VII", 7)
              .Add("VI", 6)
              .Add("V", 5)
              .Add("IV", 4)
              .Add("III", 3)
              .Add("II", 2)
              .Add("I", 1)
              ;

        public int Eval(string romanExpr)
        {
            if(string.IsNullOrEmpty(romanExpr))
                return this.ThrowInvalidNumeralException(romanExpr);

            romanExpr = romanExpr.ToUpperInvariant();

            return InternalEval(romanExpr);
        }

        private int InternalEval(string romanExpr)
        {
            if (string.IsNullOrEmpty(romanExpr)) // Expression evaluated with success
                return 0;

            foreach(var rule in _parsingRules)
                if (romanExpr.StartsWith(rule.Expression))
                    return rule.Value + this.InternalEval(romanExpr.Substring(rule.GetExpressionLen()));

            return this.ThrowInvalidNumeralException(romanExpr);
        }

	    private int ThrowInvalidNumeralException(string roman)
	    {
		    throw new Exception("Invalid Roman Numeral String: " + roman);
	    }
    }
}