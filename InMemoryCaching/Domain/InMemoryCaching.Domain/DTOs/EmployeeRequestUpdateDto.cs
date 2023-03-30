using System.ComponentModel.DataAnnotations;

namespace InMemoryCaching.Domain.DTOs
{

    public class EmployeeRequestUpdateDto
    {
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? EmpCode { get; set; }
        [Required]
        public string? Position { get; set; }
        [Required]
        public string? OfficeLocation { get; set; }
    }
}
