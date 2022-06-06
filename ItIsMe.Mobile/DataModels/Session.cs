namespace ItIsMe.Mobile.DataModels
{
    public class Session
    {
        public DateTime Date { get; set; }

        public bool IsHandled { get; set; }

        public Psychologist Psychologist { get; set; }
    }
}
