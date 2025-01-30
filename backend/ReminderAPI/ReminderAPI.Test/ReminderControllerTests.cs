using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReminderAPI.Controllers;
using ReminderAPI.Entities;
using ReminderAPI.Exceptions;
using ReminderAPI.Responses;
namespace ReminderAPI.Test

{
    public class UnitTest1
    {
        [Fact(DisplayName = "Given Reminder, when create with empty name then should Fail.")]
        public async void GivenReminderWithEmptyName_WhenCreate_ThenShouldFail()
        {
            ReminderController controller = new ReminderController();
            var testReminder = new Reminder
            {
                Name = "",
                Date = DateTime.Now,
            };


            var result = await Assert.ThrowsAsync<ErrorOnValidationException>(() => controller.Create(testReminder));
        }

        [Fact(DisplayName = "Given random Id, when delete then should Fail.")]
        public async void GivenReminder_WhenDelete_ThenShouldSucces()
        {
            ReminderController controller = new ReminderController();
            Guid Id = Guid.NewGuid();


            var result = await Assert.ThrowsAsync<NotFoundException>(() => controller.Delete(Id));
        }
    }
}