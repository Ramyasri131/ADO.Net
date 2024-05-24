namespace EmployeeDirectory.DAL.Interfaces
{
    public interface ILocationRepository
    {
        public Dictionary<int, string> GetLocations();

    }
}
