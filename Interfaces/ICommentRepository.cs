using dotnet_web_api.DTOs.Comment;
using dotnet_web_api.Helpers;
using dotnet_web_api.Models;

namespace dotnet_web_api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync(CommentQueryObject queryObject);
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment commentModel);
        Task<Comment?> UpdateAsync(int id, UpdateCommentRequestDto updateCommentDto);
        Task<Comment?> DeleteAsync(int id);
    }
}
