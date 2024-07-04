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

#include <ctype.h>
#include <limits.h>
#include <stdlib.h>

#include "convert.h"

extern "C" __declspec(dllexport) long StringToLong(const char* s, long base)
{
    return s_to_long(s, base);
}

extern "C" __declspec(dllexport) void LongToString(char* s, long n, long base)
{
    return long_to_s(s, n, base);
}

extern "C" __declspec(dllexport) void ULongToString(char* s, long n, long base)
{
    return ulong_to_s(s, n, base);
}

#define LONG_BITS (CHAR_BIT * sizeof(long)) /* number of bits in a long */

typedef enum { NO, YES } Bool;

/* To increase the upper bound of base (currently 16) in the following
   functions, simply add more characters to the digits string. */
static const char *const digits = "0123456789abcdef";

int digit_value(int c)
{
    return (isdigit(c)) ? c - '0'
         : (isalpha(c)) ? tolower(c) - 'a' + 10
         : -1;
}

long s_to_long(const char *s, long base)
{
    long n = 0, v;
    Bool negate = NO;

    if (*s == '-') {
        negate = YES;
        ++s;
    }
    for (;;) {
        v = digit_value(*s);
        if (v < 0 || v >= base)
            break;
        n = n * base + v;
        ++s;
    }
    return (negate) ? -n : n;
}

void long_to_s(char *s, long n, long base)
{
    char buf[LONG_BITS], *b = buf;
    ldiv_t q;

    if (n < 0)
        *s++ = '-';
    do {
        q = ldiv(n, base);
        *b++ = digits[(q.rem >= 0) ? q.rem : -q.rem];
        n = q.quot;
    } while (n != 0);
    do {
        *s++ = *--b;
    } while (b != buf);
    *s = '\0';
}

void ulong_to_s(char *s, unsigned long n, unsigned long base)
{
    char buf[LONG_BITS], *b = buf;

    do {
        *b++ = digits[n % base];
        n /= base;
    } while (n != 0);
    do {
        *s++ = *--b;
    } while (b != buf);
    *s = '\0';
}
