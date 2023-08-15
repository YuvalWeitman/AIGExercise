namespace CoreWebApplication1.Services.Strategy
{
    public class LaterThisWeek : ICalcDateStrategy
    {
        // now + 2 days 8:00 (only if on Sunday-Thursday, othewise another clac)
        public DateTime Calc()
        {
            DateTime now = DateTime.Now;
            TimeSpan ts = new TimeSpan(8, 0, 0);
            DateTime retVal = now.AddDays(2).Date + ts;

            DayOfWeek dayOfWeek =  now.DayOfWeek;

            if(dayOfWeek == DayOfWeek.Friday)
            {
                retVal = new Tommorrow().Calc().Date;
            }
            else if(dayOfWeek == DayOfWeek.Saturday)
            {
                retVal = new LaterToday().Calc();
            }

            return retVal;
        }
    }
}
