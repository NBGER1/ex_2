namespace Notifications
{
    public abstract class EventParams
    {
        private static EmptyEventParams _eep = new EmptyEventParams();
        
        public static EmptyEventParams Empty => _eep;
    }
}