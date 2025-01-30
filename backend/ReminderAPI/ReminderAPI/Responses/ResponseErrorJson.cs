namespace ReminderAPI.Responses
{
    public class ResponseErrorJson
    {
        public string Message { get; set; } = string.Empty;
        /// <summary>
        /// Representa uma resposta de erro em formato JSON.
        /// </summary>
        /// <param name="message"></param>
        public ResponseErrorJson(string message) 
        {
            Message = message;
        }
    }
}
