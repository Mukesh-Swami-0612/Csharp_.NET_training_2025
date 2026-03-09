namespace MyCompanyApp.MVC.Models
{
    public class PersonViewModel
    {
        public int BusinessEntityId { get; set; }
        public string PersonType { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
    }
}
