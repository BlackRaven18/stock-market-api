using dotnet_web_api.DTOs.Comment;
using dotnet_web_api.Models;

namespace dotnet_web_api.Mappers
{
    public static class CommentMappers
    {

        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId,
            };
        }
    }
}
