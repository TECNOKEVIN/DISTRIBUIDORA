using Distribuidora.Shared.Responses;

namespace Distribuidora.API.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string servicePrefix, string controller);
    }
}

