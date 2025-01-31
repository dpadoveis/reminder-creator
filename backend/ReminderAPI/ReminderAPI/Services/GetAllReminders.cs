using Microsoft.EntityFrameworkCore;

namespace ReminderAPI.Services
{
    public class GetAllReminders
    {
        private readonly RemindersDbContext _dbContext;

        public GetAllReminders()
        {
            _dbContext = new RemindersDbContext();
        }
        public async Task<List<object>> GetAll()
        {
            var reminders = await _dbContext.Reminders.ToListAsync();

            if (!reminders.Any())
            {
                return new List<object>(); 
            }
            return reminders.Select(reminder => new
            {
                reminder.Id,
                reminder.Name,
                reminder.Date
            }).ToList<object>();
        }
    }
}
