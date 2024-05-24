namespace EmployeeDirectory.BAL.DTO
{
    public class Employee
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public long MobileNumber { get; set; }

        public required string DateOfBirth { get; set; }

        public required string DateOfJoin { get; set; }

        public required string Location { get; set; } 

        public required string JobTitle { get; set; } 

        public required string Department { get; set; }

        public required string Manager { get; set; }

        public required string Project { get; set; } 
    }
}