using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReminderAPI.Controllers;
using ReminderAPI.Entities;
using ReminderAPI.Exceptions;
using ReminderAPI.Responses;
namespace ReminderAPI.Test

{
    public class ReminderControllerTests
    {
        [Fact(DisplayName = "Given Reminder, when create with empty name then should Fail.")]
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

        [Fact(DisplayName = "Given Reminder, when create with a date before the current one then should Fail.")]
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