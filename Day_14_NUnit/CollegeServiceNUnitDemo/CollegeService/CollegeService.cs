namespace CollegeService
{
    public class CollegeService : ICollegeService
    {
        public string GetWelcomeNote(string name)
        {
            return $"Welcome, {name}";
        }

        public string GetFarewellNote(string name)
        {
            return $"All the best, {name}";
        }
    }
}
