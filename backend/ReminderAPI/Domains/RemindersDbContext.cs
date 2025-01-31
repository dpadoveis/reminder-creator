using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReminderAPI.Entities;


namespace ReminderAPI
{
    public class RemindersDbContext : DbContext
    {
        public DbSet<Reminder> Reminders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = RemindersDb.db");
        }
    }
}