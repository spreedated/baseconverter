using BaseConverter.Logic;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using static BaseConverter.Enumerations.BaseEnumerations;

namespace BaseConverter.ViewModel
{
    internal partial class MainViewModel : ObservableObject
    {
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

        private void UpdateDisplayValues()
        {
            this.BinInput = this.BaseConvWrapper.Binary;
            this.OctInput = this.BaseConvWrapper.Octal;
            this.DecInput = this.BaseConvWrapper.Decimal.ToString();
            this.HexInput = this.BaseConvWrapper.Hexadecimal;
        }

        public void CalculateFrom(string value, Base @base)
        {
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

            this.UpdateDisplayValues();
        }
    }
}
