using System.Text.Json;

namespace WebApiDapperApp.Models
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }

        public string Message { get; set; } = default!;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
