using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReminderAPI.Entities;
using ReminderAPI.Exceptions;
using ReminderAPI.Services;

namespace ReminderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {

        /// <summary>
        /// Cria um lembrete no banco de dados, inserindo nome e data
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Instância do lembrete criada</returns>
        /// <exception cref="ErrorOnValidationException"></exception>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] Reminder request)
        {
            var service = new CreateReminder();
            var response = await service.Execute(request);
            return CreatedAtAction(nameof(GetAll), new { id = response.Id }, response);
        }


        /// <summary>
        /// Encontra todos os lembretes criados no banco de dados
        /// </summary>
        /// <returns>Todos os lembretes disponíveis no banco</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var service = new GetAllReminders();
            var reminders = await service.GetAll();
            return Ok(reminders);
        }


        /// <summary>
        /// Deleta um lembrete específico pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status HTTP indicando que a solicitação foi bem sucedida</returns>
        /// <exception cref="NotFoundException"></exception>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var service = new DeleteReminder();
            await service.Delete(id);
            return NoContent();
        }

    }
}

