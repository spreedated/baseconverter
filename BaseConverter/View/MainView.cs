using BaseConverter.Logic;
using BaseConverter.ViewModel;
using System;
using System.Linq;
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

        public MainView()
        {
            this.InitializeComponent();
            this.ViewModel = new();

            this.TXT_Bin.DataBindings.Add("Text", this.ViewModel, "BinInput", true, DataSourceUpdateMode.OnPropertyChanged);
            this.TXT_Oct.DataBindings.Add("Text", this.ViewModel, "OctInput", true, DataSourceUpdateMode.OnPropertyChanged);
            this.TXT_Dec.DataBindings.Add("Text", this.ViewModel, "DecInput", true, DataSourceUpdateMode.OnPropertyChanged);
            this.TXT_Hex.DataBindings.Add("Text", this.ViewModel, "HexInput", true, DataSourceUpdateMode.OnPropertyChanged);

            Task.Run(async () =>
            {
                while (Globals.Fonts.Families.Length == 0 || !this.IsHandleCreated)
                {
                    await Task.Delay(50);
                }

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
            });
        }

        private void TXT_Bin_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is not TextBox txt)
            {
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                this.ViewModel.CalculateFrom(txt.Text, Enum.Parse<Base>(txt.Tag.ToString()));
            }
        }
    }
}
