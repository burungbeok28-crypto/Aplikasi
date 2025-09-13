namespace SPP.Core.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NISN { get; set; }
        public string Class { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string ParentName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Balance { get; set; }
    }
}