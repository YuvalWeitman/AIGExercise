namespace CoreWebApplication1.Services.Strategy
{
    public class ThisWeekend : ICalcDateStrategy
    {
        // Friday at 8:00. (only if on Sunday-Thursday, othewise NextWeek clac)
        public DateTime Calc()
        {
            DateTime now = DateTime.Now;
            DateTime thisFriday = now.AddDays(5 - (int)now.DayOfWeek);

            if(thisFriday <= DateTime.Now)
            {
                return new NextWeek().Calc();
            }

            return thisFriday.Date + new TimeSpan(8, 0, 0);
        }
    }
}
