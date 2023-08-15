namespace CoreWebApplication1.Services.Strategy
{
    public class LaterToday : ICalcDateStrategy
    {
        // now + 3 hour
        public DateTime Calc()
        {
            return DateTime.Now.AddHours(3);
        }
    }
}
