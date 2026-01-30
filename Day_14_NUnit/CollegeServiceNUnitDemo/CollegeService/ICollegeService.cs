namespace CollegeService
{
    public interface ICollegeService
    {
        string GetWelcomeNote(string name);
        string GetFarewellNote(string name);
    }
}
