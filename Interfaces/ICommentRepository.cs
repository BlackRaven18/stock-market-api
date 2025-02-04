using dotnet_web_api.Models;

namespace dotnet_web_api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
    }
}
