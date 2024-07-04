using System.Text.RegularExpressions;

namespace BaseConverter
{
    internal static partial class PreCompiledRegex
    {
        [GeneratedRegex("^[0-1]*$", RegexOptions.Compiled)]
        internal static partial Regex BinaryOnly();

        [GeneratedRegex("^[0-7]*$", RegexOptions.Compiled)]
        internal static partial Regex OctalOnly();

        [GeneratedRegex("^[0-9]*$", RegexOptions.Compiled)]
        internal static partial Regex DecimalOnly();

        [GeneratedRegex("^[0-9, a-f]*$", RegexOptions.Compiled)]
        internal static partial Regex HexadecimalOnly();
    }
}
