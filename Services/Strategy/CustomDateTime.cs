namespace CoreWebApplication1.Services.Strategy
{
    public class CustomDateTime : ICalcDateStrategy
    {
        private DateTime _customdate;
        public CustomDateTime(DateTime customDate) { _customdate = customDate; }
        public DateTime Calc()
        {
            return _customdate;
        }
    }
}
