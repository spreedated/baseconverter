/*
Base Converter - Convert numbers between bin/oct/dec/hex

Copyright (C) 2024  Kim Fastrup Larsen

This program is free software: you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation, either ver-
sion 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be use-
ful, but WITHOUT ANY WARRANTY; without even the implied war-
ranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
See the GNU General Public License for more details.

You should have received a copy of the GNU General Public Li-
cense along with this program. If not, see
<http://www.gnu.org/licenses/>.

The author can be contacted on <kimflarsen@hotmail.com>
*/

#ifndef CONVERT_H
#define CONVERT_H

/* digit_value: Convert a character to an integer

   Numeric characters will convert to their integer counterparts, ie. '0'
   will convert to 0, '1' to 1, etc.

   'a' and 'A' will convert to 10, 'b' and 'B' to 11, and so on, up to 'z' /
   'Z'.

   Any other character will convert to -1. */
int digit_value(int c);

/* s_to_long: Convert a string to a long

   Given a string representing of a number in the given base, this function
   will return the value as a long. The first character can be '-' to
   represent negative numbers.

   Alphabetic characters (for bases greater than 10) can be either lower or
   upper case.

   Conversion will be cut short at any character that isn't a valid digit in
   the base.

   A string representing a positive number that is outside the range of a
   long, but inside the range of an unsigned long, will be converted to a
   negative number that can be cast to unsigned long to get the correct
   positive value.
   
   A string representing a number outside the range of both long and unsigned
   long will return a meaningless value. */
long s_to_long(const char *s, long base);

/* long_to_s: Convert a long to a string

   Writes characters to the provided buffer that represent the given value in
   the given base, and terminates with a NULL character.

   The base must be at least 2 and at most 16.

   It is the caller's responsibility to provide a buffer large enough to
   fit a representation of any long on the architecture. */
void long_to_s(char *buf, long value, long base);

/* ulong_to_s: Convert an unsigned long to a string

   Writes characters to the provided buffer that represent the given value in
   the given base, and terminates with a NULL character.

   The base must be at least 2 and at most 16.

   It is the caller's responsibility to provide a buffer large enough to
   fit a representation of any unsigned long on the architecture. */
void ulong_to_s(char *buf, unsigned long value, unsigned long base);

#endif
