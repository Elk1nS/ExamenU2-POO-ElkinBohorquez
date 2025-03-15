using System.Text.Json.Serialization;

namespace ExamenU2_POO_ElkinBohorquez.Dtos.Common
{
    public class ResponseDto<T>
    {
        [JsonIgnore]
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public T Data { get; set; }
    }
}
