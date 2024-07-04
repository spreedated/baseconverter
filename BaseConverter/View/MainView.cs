using BaseConverter.Logic;
using BaseConverter.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BaseConverter.Enumerations.BaseEnumerations;
using static BaseConverter.Enumerations.WinForms;
using static BaseConverter.Logic.HelperFunctions;

namespace BaseConverter
{
    public partial class MainView : Form
    {
        internal MainViewModel ViewModel { get; init; }

        /// <summary>
        /// Allow only horizontal resizing by dragging the form from the top edge.
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case 0x84: //WM_NCHITTEST
                    var result = (HitTest)m.Result.ToInt32();
                    if (result == HitTest.Top || result == HitTest.Bottom)
                    {
                        m.Result = new IntPtr((int)HitTest.Caption);
                    }

                    if (result == HitTest.TopLeft || result == HitTest.BottomLeft)
                    {
                        m.Result = new IntPtr((int)HitTest.Left);
                    }

                    if (result == HitTest.TopRight || result == HitTest.BottomRight)
                    {
                        m.Result = new IntPtr((int)HitTest.Right);
                    }

                    break;
            }
        }

        private void TXT_Bin_TextChanged(object sender, EventArgs e)
        {
            ValidityGate(this.TXT_Bin, PreCompiledRegex.BinaryOnly());
        }

        private void TXT_Oct_TextChanged(object sender, EventArgs e)
        {
            ValidityGate(this.TXT_Oct, PreCompiledRegex.OctalOnly());
        }

        private void TXT_Dec_TextChanged(object sender, EventArgs e)
        {
            ValidityGate(this.TXT_Dec, PreCompiledRegex.DecimalOnly());
        }

        private void TXT_Hex_TextChanged(object sender, EventArgs e)
        {
            ValidityGate(this.TXT_Hex, PreCompiledRegex.HexadecimalOnly());
        }

        #region Constructor
        public MainView()
        {
            this.InitializeComponent();
            this.MinimumSize = this.Size;
            this.BackColor = Globals.BACKCOLOR;
            this.ViewModel = new();

            this.SetBindings();

            Task.Run(async () =>
            {
                while (!Globals.PreloadComplete || !this.IsHandleCreated)
                {
                    await Task.Delay(50);
                }

                await this.SetWindowTitle();
                await this.AssignFontsToControls();
            });
        }

        public MainView(ILogger logger) : this()
        {
            this.ViewModel.Logger = logger;
        }
        #endregion

        private void SetBindings()
        {
            foreach (Control t in this.Controls.OfType<Control>().Where(x => x is TextBox))
            {
                t.DataBindings.Add("Text", this.ViewModel, $"{t.Name[(t.Name.IndexOf('_') + 1)..]}Input", true, DataSourceUpdateMode.OnPropertyChanged);
                t.BackColor = Globals.BACKCOLOR;
                this.ViewModel.Logger?.LogTrace("Binding set for {Control}", t.Name);
            }
        }

        private async Task SetWindowTitle()
        {
            Assembly a = Assembly.GetExecutingAssembly();

            this.Invoke(() =>
            {
                this.Text = $"{a.GetCustomAttribute<AssemblyTitleAttribute>()?.Title} v{a.GetName().Version}";
                this.ViewModel.Logger?.LogTrace("Window title set to {Title}", this.Text);
            });

            await Task.CompletedTask;
        }

        private async Task AssignFontsToControls()
        {
            foreach (Control c in this.Controls.OfType<Control>().Where(x => x is TextBox || x is Label))
            {
                this.Invoke(() =>
                {
                    c.Font = new(Globals.Fonts.Families[0], Globals.FONTSIZE);
                });
            }

            this.Invoke(() =>
            {
                this.Font = new(Globals.Fonts.Families[0], Globals.FONTSIZE);
            });

            await Task.CompletedTask;
        }

        private void Textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is not TextBox txt)
            {
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                this.ViewModel.CalculateFrom(txt.Text, Enum.Parse<Base>(txt.Tag.ToString()));

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
