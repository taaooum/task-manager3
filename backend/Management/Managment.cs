using backend.Services;

namespace backend.Management
{
    public interface IManagement
    {
        // something
    }
    
    /// <summary>
    /// The management is for database operations responsible
    /// </summary>
    /// <param name="dataContext"></param>
    public partial class Managment(DataContextService dataContext) : IManagement
    {
        // something
    }
}