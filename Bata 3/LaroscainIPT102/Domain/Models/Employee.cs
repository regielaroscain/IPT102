namespace Domain.Models
{
    public class Employee
    {
        public int Id { get; set; } // Inalis ang '?' para maging solid na int
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
    }
}