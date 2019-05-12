using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using System;

namespace RomanNumerals
{
    [TestFixture]
    public class RomanNumeralsParser_UnitTests
    {
        IParser _parser = null;

	    [SetUp]
	    public void SetUp()
	    {
            _parser = new RomanNumerals.Parser_V2();
        }

        [TestCase("MMM", 3000)]
        [TestCase("MM", 2000)]
        [TestCase("M", 1000)]
        [TestCase("CM", 900)]
        [TestCase("DCCC", 800)]
        [TestCase("DCC", 700)]
        [TestCase("DC", 600)]
        [TestCase("D", 500)]
        [TestCase("CD", 400)]
        [TestCase("CCC", 300)]
        [TestCase("CC", 200)]
        [TestCase("C", 100)]
        [TestCase("XC", 90)]
        [TestCase("LXXX", 80)]
        [TestCase("LXX", 70)]
        [TestCase("LX", 60)]
        [TestCase("L", 50)]
        [TestCase("XL", 40)]
        [TestCase("XXX", 30)]
        [TestCase("XX", 20)]
        [TestCase("X", 10)]
        [TestCase("IX", 9)]
        [TestCase("VIII", 8)]
        [TestCase("VII", 7)]
        [TestCase("VI", 6)]
        [TestCase("V", 5)]
        [TestCase("IV", 4)]
        [TestCase("III", 3)]
        [TestCase("II", 2)]
        [TestCase("I", 1)]
        public void Parse_Thousand_Hundred_Ten(string numeralString, int expected)
        {
	        var result = _parser.Eval(numeralString);

	        Assert.AreEqual(expected, result);
        }


        [TestCase("MMMM", 4000)]
        [TestCase("MMMCMXII", 3912)]
        [TestCase("MMMDCCCLXVII", 3867)]
        [TestCase("MMMDCCLXXVII", 3777)]
        [TestCase("MMMDCLXVI", 3666)]
        [TestCase("MMMDLV", 3555)]
        [TestCase("MMMCDXLIV", 3444)]
        [TestCase("MMMCCCXXXIII", 3333)]
        [TestCase("MMMCCXXII", 3222)]
        [TestCase("MMMCXXIII", 3123)]
        [TestCase("MMMCXI", 3111)]
        [TestCase("MMMXII", 3012)]
        [TestCase("MMM", 3000)]

        [TestCase("MMCMXCIX", 2999)]
        [TestCase("MMDCCCLXXXVIII", 2888)]
        [TestCase("MMDCCLXXVII", 2777)]
        [TestCase("MMDCLXVI", 2666)]
        [TestCase("MMDLV", 2555)]
        [TestCase("MMCDXLIV", 2444)]

        [TestCase("MM", 2000)]
        [TestCase("M", 1000)]
        [TestCase("CM", 900)]
        [TestCase("DCCC", 800)]
        [TestCase("DCC", 700)]
        [TestCase("DC", 600)]
        [TestCase("D", 500)]
        [TestCase("CD", 400)]
        [TestCase("CCC", 300)]
        [TestCase("CC", 200)]
        [TestCase("C", 100)]
        [TestCase("XC", 90)]
        [TestCase("LXXX", 80)]
        [TestCase("LXX", 70)]
        [TestCase("LX", 60)]
        [TestCase("L", 50)]
        [TestCase("XL", 40)]
        [TestCase("XXX", 30)]
        [TestCase("XX", 20)]
        [TestCase("X", 10)]
        [TestCase("IX", 9)]
        [TestCase("VIII", 8)]
        [TestCase("VII", 7)]
        [TestCase("VI", 6)]
        [TestCase("V", 5)]
        [TestCase("IV", 4)]
        [TestCase("III", 3)]
        [TestCase("II", 2)]
        [TestCase("I", 1)]
        public void Parse_Numbers(string numeralString, int expected)
        {
            var result = _parser.Eval(numeralString);

            Assert.AreEqual(expected, result);
        }

        [TestCase("BAD-EXPRESSION", 0)]
        [TestCase("", 0)]
        [TestCase(null, 0)]
        //[TestCase("MCIIV", 0)]
        //[TestCase("MCIIIV", 0)]
        //[TestCase("MCIIIIV", 0)]
        //[TestCase("MCIIX", 1103)]
        //[TestCase("MCIIIX", 1103)]
        public void ParseInvalidExpressions(string numeralString, int expected)
        {
            Assert.Throws<Exception>(() =>
                _parser.Eval(numeralString)
            );
        }
    }
}



