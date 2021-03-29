namespace Presentation.Utils.JsonModels.Models
{
    public class ResultJson
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public dynamic Data { get; set; }
    }
}