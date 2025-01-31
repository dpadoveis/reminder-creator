namespace ReminderAPI.Exceptions
{
    public class NotFoundException : ReminderException
    {
        /// <summary>
        /// Exceção para indicar que um recurso não foi encontrado.
        /// </summary>
        /// <param name="message"></param>
        public NotFoundException(string message) : base(message) { }
    }
}
