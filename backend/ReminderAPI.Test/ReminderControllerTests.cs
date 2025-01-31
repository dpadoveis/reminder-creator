using ReminderAPI.Controllers;
using ReminderAPI.Entities;
using ReminderAPI.Exceptions;
namespace ReminderAPI.Test

{
    public class ReminderControllerTests
    {
        [Fact(DisplayName = "Given Reminder, when create with empty name then should fail.")]
        public async Task GivenReminderWithEmptyName_WhenCreate_ThenShouldFail()
        {
            ReminderController controller = new ReminderController();
            var testReminder = new Reminder
            {
                Name = "",
                Date = DateTime.Now,
            };


            var result = await Assert.ThrowsAsync<ErrorOnValidationException>(() => controller.Create(testReminder));
        }

        [Fact(DisplayName = "Given Reminder, when create with a date before the current one then should fail.")]
        public async Task GivenReminderWithOldDate_WhenCreate_ThenShouldFail()
        {
            ReminderController controller = new ReminderController();
            var testReminder = new Reminder
            {
                Name = "Test1",
                Date = DateTime.Now.AddDays(-10),
            };


            var result = await Assert.ThrowsAsync<ErrorOnValidationException>(() => controller.Create(testReminder));
        }
    }
}