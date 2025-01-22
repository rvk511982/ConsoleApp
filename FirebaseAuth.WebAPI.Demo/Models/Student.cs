namespace FirebaseAuthWebAPI.Demo.Models
{
    public class Student
    {
        public string? Id { get; set; }
        public string? Student_id { get; set; }
        public string? fullname { get; set; }
        public string? degree_title { get; set; }
        public string? address { get; set; }
        public string? phone { get; set; }
    }

    public class UserDemo
    {
        public string Id { get; set; }

        public string EmailAddress { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedDate { get; set; }
    }
}
