using BaseConverter.Logic;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseConverter
{
    internal static class Program
    {
        internal static Microsoft.Extensions.Logging.ILogger ApplicationLogger { get; set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            LoadLogger();

            Task.Run(async () =>
            {
                await LoadFonts();
                ApplicationLogger.LogTrace("Fonts loaded successfully.");

                Globals.PreloadComplete = true;
            });

            Application.Run(new MainView(new SerilogLoggerFactory(Log.Logger).CreateLogger("mainView")));
        }

        private static void LoadLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Verbose()
                .WriteTo.Debug()
                .WriteTo.Console()
                .CreateLogger();

            ApplicationLogger = new SerilogLoggerFactory(Log.Logger).CreateLogger("programStart");
            ApplicationLogger.LogTrace("Logger initialized.");
        }

        private static async Task LoadFonts()
        {
            int fontLength = Properties.Resources.amiga4ever_pro2.Length;
            byte[] fontdata = Properties.Resources.amiga4ever_pro2;
            IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            Globals.Fonts.AddMemoryFont(data, fontLength);

            await Task.CompletedTask;
        }
    }
}