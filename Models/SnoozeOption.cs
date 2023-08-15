namespace CoreWebApplication1.Models
{
    public enum SnoozeOption
    {
        LaterToday, // now + 3 hour
        Tommorrow, //now + 1d 8:00
        LaterThisWeek, // now + 2d 8:00
        ThisWeekend, // fri 8:00
        NextWeek, //sun 8:00
        CustomDateTime
    }
}
