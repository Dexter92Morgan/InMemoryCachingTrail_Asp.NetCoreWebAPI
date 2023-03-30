using System.ComponentModel.DataAnnotations;

namespace InMemoryCaching.Domain.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string? FullName { get; set; }
        public string? EmpCode { get; set; }
        public string? Position { get; set; }
        public string? OfficeLocation { get; set; }

    }
}
