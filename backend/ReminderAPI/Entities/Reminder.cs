namespace ReminderAPI.Entities
{
    public class Reminder
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.MinValue;
    }
}
