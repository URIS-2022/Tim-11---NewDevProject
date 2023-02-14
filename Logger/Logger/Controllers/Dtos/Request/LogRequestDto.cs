using System.ComponentModel.DataAnnotations;

namespace Logger.Controllers.Dtos.Request
{
    public class LogRequestDto
    {
        [Required]
        public string Message { get; set; }

        [Required]
        public bool IsError { get; set; }
    }
}
