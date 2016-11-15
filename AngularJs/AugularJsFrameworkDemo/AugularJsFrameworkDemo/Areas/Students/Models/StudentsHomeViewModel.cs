namespace AugularJsFrameworkDemo.Areas.Students.Models
{
    public class StudentsHomeViewModel
    {
        public UserProfile UserProfile { get; set; }
    }

    public class UserProfile
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
}