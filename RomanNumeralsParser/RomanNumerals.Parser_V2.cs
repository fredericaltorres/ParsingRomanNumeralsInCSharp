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
        public string GetNextExpression(string expression)
        {
            return expression.Substring(this.GetExpressionLen());
        }
        public bool ApplyToExpression(string romanExpression)
        {
            return romanExpression.StartsWith(this.Expression);
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

            return InternalEval(romanExpr.ToUpperInvariant());
        }

        /// <summary>
        /// This function is called recusively to parse a piece of the 
        /// expression, first the 1000, then the 100, then the 10 and finally the
        /// less than 10.
        /// </summary>
        /// <param name="romanExpression"></param>
        /// <returns></returns>
        private int InternalEval(string romanExpression)
        {
            // Expression evaluated with success, backtrack
            if (string.IsNullOrEmpty(romanExpression)) 
                return 0;

            // Find the first rule that apply to the current expression
            // Execute the rule and recursively move to the next part of the expression
            foreach(var rule in _parsingRules)
                if (rule.ApplyToExpression(romanExpression))
                    return rule.Value + this.InternalEval(rule.GetNextExpression(romanExpression));

            return this.ThrowInvalidNumeralException(romanExpression);
        }

	    private int ThrowInvalidNumeralException(string roman)
	    {
		    throw new Exception("Invalid Roman Numeral String: " + roman);
	    }
    }
}