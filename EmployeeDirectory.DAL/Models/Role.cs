namespace EmployeeDirectory.DAL.Models
{
    public class Role
    {
        public required int Id { get; set; }

        public required string? Name { get; set; }

        public required int Location { get; set; }

        public required int Department { get; set; }

        public string? Description { get; set; }
    }
}