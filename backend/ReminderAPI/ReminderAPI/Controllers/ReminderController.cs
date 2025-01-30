using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReminderAPI.Entities;
using ReminderAPI.Exceptions;

namespace ReminderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        private readonly RemindersDbContext _dbContext;

        public ReminderController()
        {
            _dbContext = new RemindersDbContext();
        }



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
        [Route("CreateReminder")]
        public async Task<IActionResult> Create([FromBody] Reminder request)
        {

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ErrorOnValidationException("Nome inválido!");
            }

            var reminder = new Reminder
            {
                Name = request.Name,
                Date = request.Date,
            };

            _dbContext.Reminders.Add(reminder);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = reminder.Id }, reminder);
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
        [Route("GetAllReminders")]
        public async Task<IActionResult> GetAll()
        {
            var reminders = await _dbContext.Reminders.ToListAsync(); 

            var response = reminders.Select(reminder => new
            {
                reminder.Id,
                reminder.Name,
                reminder.Date
            }).ToList();

            return Ok(response);
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
                var reminder = await _dbContext.Reminders.FindAsync(id);
                if (reminder == null)
                {
                    throw new NotFoundException("Lembrete não encontrado.");
                }

                _dbContext.Reminders.Remove(reminder);
                await _dbContext.SaveChangesAsync();

                return NoContent();
            }
            
        }
    }
    
