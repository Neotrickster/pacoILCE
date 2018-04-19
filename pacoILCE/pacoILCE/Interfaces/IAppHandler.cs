using System.Threading.Tasks;

namespace pacoILCE.Interfaces
{
    public interface IAppHandler
    {
        Task<bool> LaunchApp(string uri);
    }
}
