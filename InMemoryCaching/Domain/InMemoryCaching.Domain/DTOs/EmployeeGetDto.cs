namespace InMemoryCaching.Domain.DTOs
{
    public class EmployeeGetDto
    {
        public int EmployeeId { get; set; }
        public string? FullName { get; set; }
        public string? EmpCode { get; set; }
        public string? Position { get; set; }
        public string? OfficeLocation { get; set; }
    }
}
