using ReminderAPI.Entities;
using ReminderAPI.Exceptions;

namespace ReminderAPI.Services
{
    public class CreateReminder
    {
        private readonly RemindersDbContext _dbContext;

        public CreateReminder()
        {
            _dbContext = new RemindersDbContext();
        }

        public async Task<Reminder> Execute(Reminder request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ErrorOnValidationException("Nome inválido!");
            }

            if (request.Date < DateTime.UtcNow) {
                throw new ErrorOnValidationException("A data não pode ser anterior à data atual!");
            }


            var reminder = new Reminder
            {
                Name = request.Name,
                Date = request.Date,
            };

            _dbContext.Reminders.Add(reminder);
            await _dbContext.SaveChangesAsync();

            return reminder;
        }
    }
}
