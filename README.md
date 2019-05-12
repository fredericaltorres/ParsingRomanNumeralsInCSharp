# Parsing Roman Numerals in C#

## Overview
Starting with the wikipedia page
[Roman numerals](https://en.wikipedia.org/wiki/Roman_numerals)

I wrote a rule engine that starting
- from left to right
- from 1000, then 100, then 10, then less than 10

Grab the expected expression, convert into numeric and recursively
continue to evaluate the expression.

See class RomanNumerals.Parser_V1.cs for my first implementation
with no refactoring

