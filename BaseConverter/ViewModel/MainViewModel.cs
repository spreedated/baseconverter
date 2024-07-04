using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using static BaseConverter.Enumerations.BaseEnumerations;

namespace BaseConverter.ViewModel
{
    internal partial class MainViewModel : ObservableObject
    {
        internal ILogger Logger { get; set; }

        [ObservableProperty]
        private string binInput = "0";

        [ObservableProperty]
        private string octInput = "0";

        [ObservableProperty]
        private string decInput = "0";

        [ObservableProperty]
        private string hexInput = "0";

        [ObservableProperty]
        private BaseConvWrapper.BaseConverter baseConvWrap;

        #region Constructor
        public MainViewModel()
        {
            this.Logger?.LogTrace("MainViewModel initialized.");
        }
        #endregion

        private void UpdateDisplayValues()
        {
            this.BinInput = this.BaseConvWrap.Binary;
            this.OctInput = this.BaseConvWrap.Octal;
            this.DecInput = this.BaseConvWrap.Decimal.ToString();
            this.HexInput = this.BaseConvWrap.Hexadecimal;
            this.Logger?.LogTrace("Display values updated.");
        }

        public void CalculateFrom(string value, Base @base)
        {
            this.Logger?.LogInformation("Calculating from {Base} of value \"{Value}\"", @base.ToString(), value);

            Stopwatch sw = Stopwatch.StartNew();

            switch (@base)
            {
                case Base.Binary:
                    this.BaseConvWrap = BaseConvWrapper.BaseConverter.FromBinary(Convert.ToInt64(value));
                    break;
                case Base.Octal:
                    this.BaseConvWrap = BaseConvWrapper.BaseConverter.FromOctal(Convert.ToInt64(value));
                    break;
                case Base.Decimal:
                    this.BaseConvWrap = BaseConvWrapper.BaseConverter.FromDecimal(Convert.ToInt64(value));
                    break;
                case Base.Hexadecimal:
                    this.BaseConvWrap = BaseConvWrapper.BaseConverter.FromHexadecimal(value);
                    break;
            }

            sw.Stop();

            this.Logger?.LogInformation("Result from {Base} of value \"{Value}\"\nBin: {BinValue}\nOct: {OctValue}\nDec: {DecValue}\nHex: {HexValue}\n\nOperation took {OpTime}",
                @base.ToString(),
                value,
                this.BaseConvWrap.Binary,
                this.BaseConvWrap.Octal,
                this.BaseConvWrap.Decimal,
                this.BaseConvWrap.Hexadecimal,
                sw.Elapsed.ToString("mm\\:ss\\:ffffff"));

            this.UpdateDisplayValues();
        }
    }
}
