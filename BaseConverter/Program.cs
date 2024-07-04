using BaseConverter.Logic;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseConverter
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Task.Run(() =>
            {
                int fontLength = Properties.Resources.amiga4ever_pro2.Length;
                byte[] fontdata = Properties.Resources.amiga4ever_pro2;
                IntPtr data = Marshal.AllocCoTaskMem(fontLength);
                Marshal.Copy(fontdata, 0, data, fontLength);
                Globals.Fonts.AddMemoryFont(data, fontLength);
            });

            Application.Run(new MainView());
        }
    }
}