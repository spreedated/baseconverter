using BaseConverter.Logic;
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
        private BaseConvWrapper baseConvWrapper;

        #region Constructor
        public MainViewModel()
        {
            this.Logger?.LogTrace("MainViewModel initialized.");
        }
        #endregion

        private void UpdateDisplayValues()
        {
            this.BinInput = this.BaseConvWrapper.Binary;
            this.OctInput = this.BaseConvWrapper.Octal;
            this.DecInput = this.BaseConvWrapper.Decimal.ToString();
            this.HexInput = this.BaseConvWrapper.Hexadecimal;
            this.Logger?.LogTrace("Display values updated.");
        }

        public void CalculateFrom(string value, Base @base)
        {
            this.Logger?.LogInformation("Calculating from {Base} of value \"{Value}\"", @base.ToString(), value);

            Stopwatch sw = Stopwatch.StartNew();

            switch (@base)
            {
                case Base.Binary:
                    this.BaseConvWrapper = BaseConvWrapper.FromBinary(Convert.ToInt64(value));
                    break;
                case Base.Octal:
                    this.BaseConvWrapper = BaseConvWrapper.FromOctal(Convert.ToInt64(value));
                    break;
                case Base.Decimal:
                    this.BaseConvWrapper = BaseConvWrapper.FromDecimal(Convert.ToInt64(value));
                    break;
                case Base.Hexadecimal:
                    this.BaseConvWrapper = BaseConvWrapper.FromHexadecimal(value);
                    break;
            }

            sw.Stop();

            this.Logger?.LogInformation("Result from {Base} of value \"{Value}\"\nBin: {BinValue}\nOct: {OctValue}\nDec: {DecValue}\nHex: {HexValue}\n\nOperation took {OpTime}",
                @base.ToString(),
                value,
                this.BaseConvWrapper.Binary,
                this.BaseConvWrapper.Octal,
                this.BaseConvWrapper.Decimal,
                this.BaseConvWrapper.Hexadecimal,
                sw.Elapsed.ToString("mm\\:ss\\:ffffff"));

            this.UpdateDisplayValues();
        }
    }
}
