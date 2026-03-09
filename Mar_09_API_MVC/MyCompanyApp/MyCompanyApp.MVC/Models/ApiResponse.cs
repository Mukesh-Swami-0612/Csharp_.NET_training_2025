namespace MyCompanyApp.MVC.Models
{
    public class ApiResponse
    {
        public int TotalRecords { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public List<PersonViewModel> Data { get; set; } = new();
    }
}