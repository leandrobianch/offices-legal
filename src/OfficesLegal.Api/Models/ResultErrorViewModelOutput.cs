namespace OfficesLegal.Api.Models
{
    public class ResultErrorViewModelOutput
    {
        public string Message { get; set; }
        public ResultErrorViewModelOutput(string message)
        {
            Message = message;
        }
    }
}
