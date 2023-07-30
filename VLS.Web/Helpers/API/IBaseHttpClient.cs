using VLS.Domain.CustomModels;

namespace VLS.Web.Helpers.API
{
    public interface IBaseHttpClient
    {
        void AddHeader(KeyValuePair<string, string> header);
        void RemoveHeader(string header);
        void SetBaseAddress(Uri domain);
        Task<ActionResponse<T>> GetAsync<T>(string url);
        Task<Stream?> GetStreamAsync(string url);
        Task<T?> PostAsync<T>(string url, string body, string? contentType = "application/json");
        Task<T?> PutAsync<T>(string url, string body, string? contentType = "application/json");
        Task<T?> DeleteAsync<T>(string url);
    }
}
