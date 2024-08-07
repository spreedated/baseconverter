﻿#pragma warning disable SYSLIB1054
#pragma warning disable CA2101

using System.Runtime.InteropServices;
using System.Text;

namespace BaseConvWrapper
{
    public readonly struct BaseConverter
    {
        [DllImport("BaseConv.dll", CharSet = CharSet.Ansi)]
        internal static extern long StringToLong([MarshalAs(UnmanagedType.LPStr)] string s, long @base);

        [DllImport("BaseConv.dll", CharSet = CharSet.Ansi)]
        internal static extern void LongToString(StringBuilder s, long n, long @base);

        [DllImport("BaseConv.dll", CharSet = CharSet.Ansi)]
        internal static extern void ULongToString(StringBuilder s, long n, long @base);

        public readonly string Binary
        {
            get
            {
                return this.ToBase(2);
            }
        }

        public long Decimal { get; init; }

        public readonly string Hexadecimal
        {
            get
            {
                return this.ToBase(16);
            }
        }

        public readonly string Octal
        {
            get
            {
                return this.ToBase(8);
            }
        }

        BaseConverter(long @decimal)
        {
            this.Decimal = @decimal;
        }

        private string ToBase(long @base)
        {
            StringBuilder val = new();
            ULongToString(val, this.Decimal, @base);

            return val.ToString();
        }

        public static BaseConverter FromBinary(long value)
        {
            return new BaseConverter(StringToLong(value.ToString(), 2));
        }
        public static BaseConverter FromDecimal(long value)
        {
            return new BaseConverter(StringToLong(value.ToString(), 10));
        }
        public static BaseConverter FromHexadecimal(string value)
        {
            return new BaseConverter(StringToLong(value.ToString(), 16));
        }
        public static BaseConverter FromOctal(long value)
        {
            return new BaseConverter(StringToLong(value.ToString(), 8));
        }
    }
}
