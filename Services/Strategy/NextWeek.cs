namespace CoreWebApplication1.Services.Strategy
{
    public class NextWeek : ICalcDateStrategy
    {
        //Sunday at 8:00
        public DateTime Calc()
        {
            DateTime now = DateTime.Now;
            DateTime nextSunday = now.AddDays(7 - (int)now.DayOfWeek);

            return nextSunday.Date + new TimeSpan(8, 0, 0);
        }
    }
}
