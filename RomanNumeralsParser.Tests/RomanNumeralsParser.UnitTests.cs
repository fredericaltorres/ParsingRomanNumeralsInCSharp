using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using System;

namespace RomanNumerals
{
    [TestFixture]
    public class RomanNumeralsParser_UnitTests
    {
	    [SetUp]
	    public void SetUp()
	    {

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
	        var converter = new RomanNumerals.Parser_V1();

	        var result = converter.ToInt(numeralString);

	        Assert.AreEqual(result, expected);
        }

        [TestCase("MMMI", 3001)]
        [TestCase("MMMXII", 3012)]
        [TestCase("MMMCXXIII", 3123)]
        
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
            var converter = new RomanNumerals.Parser_V1();

            var result = converter.ToInt(numeralString);

            Assert.AreEqual(result, expected);
        }

    }
}
