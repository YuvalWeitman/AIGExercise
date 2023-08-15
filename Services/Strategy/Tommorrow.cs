namespace CoreWebApplication1.Services.Strategy
{
    public class Tommorrow : ICalcDateStrategy
    {
        //now + 1 day at 8:00
        public DateTime Calc()
        {
            return DateTime.Now.AddDays(1).Date + new TimeSpan(8, 0, 0);
        }
    }
}
