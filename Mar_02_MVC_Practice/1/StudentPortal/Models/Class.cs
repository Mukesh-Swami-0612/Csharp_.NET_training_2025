namespace StudentPortal.Models
{
    public class DashboardViewModel
    {
        public int TotalStudents { get; set; }
        public int TotalCourses { get; set; }
        public decimal TotalPaidAmount { get; set; }
        public int PendingPayments { get; set; }
    }
}