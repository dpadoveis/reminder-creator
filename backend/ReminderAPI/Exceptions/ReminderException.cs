namespace ReminderAPI.Exceptions
{

    public class ReminderException : SystemException
    {
        /// <summary>
        /// Exceção base para erros relacionados a entidade lembrete.
        /// </summary>
        public ReminderException(string message) : base(message) { }
    }
}
