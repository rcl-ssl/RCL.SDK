using System.Threading.Tasks;

namespace RCL.SDK
{
    public interface IHttpService
    {
        Task<T> GetAsync<T>(string uri) where T:class;
        Task<T> PostAsync<T>(string uri, object payload) where T : class;
        Task<string> GetAccessToken(string resource);
    }
}
