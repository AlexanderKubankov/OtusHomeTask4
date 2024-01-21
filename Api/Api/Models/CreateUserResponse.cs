using System.Text.Json.Serialization;

namespace Api.Models
{
    public class CreateUserResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
