namespace Sting.Controls
{
    public class ZipCodeViewModel : ViewModelBase
    {
        private string[] _zipCodeDependecyProperty = new[] { nameof(HigherCode) };

        private int _zipCode;

        public int ZipCode
        {
            get => _zipCode;
            set => UpdateValueField(value, ref _zipCode, _zipCodeDependecyProperty);
        }

        public int HigherCode
        {
            get => ZipCode / 10000;
            set => ZipCode = ZipCode % 10000 + value * 10000;
        }

        public int LowerCode
        {
            get => ZipCode % 10000;
            set => ZipCode = ZipCode - ZipCode % 10000 + value % 10000;
        }
    }
}