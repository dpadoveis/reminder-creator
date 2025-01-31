using Microsoft.EntityFrameworkCore;
using ReminderAPI.Exceptions;

namespace ReminderAPI.Services
{
    public class DeleteReminder
    {
        private readonly RemindersDbContext _dbContext;

        public DeleteReminder()
        {
            _dbContext = new RemindersDbContext();
        }
        public async Task Delete(Guid id)
        {
            var reminder = await _dbContext.Reminders.FindAsync(id);
            if (reminder == null)
            {
                throw new NotFoundException("Lembrete não encontrado.");
            }

            _dbContext.Reminders.Remove(reminder);
            await _dbContext.SaveChangesAsync();
        }
    }
}
