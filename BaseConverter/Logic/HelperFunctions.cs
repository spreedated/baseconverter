using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BaseConverter.Logic
{
    internal static class HelperFunctions
    {
        /// <summary>
        /// Checks the validity of the input text in a <see cref="TextBox"/> against the matching <see cref="Regex"/>.<br/>
        /// If fails, the last character is removed and the cursor is set to the end of the text.
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="regex"></param>
        internal static void ValidityGate(TextBox textBox, Regex regex)
        {
            if (!regex.IsMatch(textBox.Text))
            {
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
                textBox.SelectionStart = textBox.Text.Length;
            }
        }
    }
}
