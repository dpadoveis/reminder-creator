namespace ReminderAPI.Exceptions
{
    public class ErrorOnValidationException : ReminderException
    {
        /// <summary>
        /// Exceção para indicar falha na validação dos dados de entrada.
        /// </summary>
        /// <param name="message"></param>
        public ErrorOnValidationException(string message) : base(message) { }
    }
}
