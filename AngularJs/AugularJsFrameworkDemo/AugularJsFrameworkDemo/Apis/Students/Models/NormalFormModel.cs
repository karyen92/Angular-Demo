namespace AugularJsFrameworkDemo.Apis.Students.Models
{
    public class NormalFormModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
    }

    public class Error
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}