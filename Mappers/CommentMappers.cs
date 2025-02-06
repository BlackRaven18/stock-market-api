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
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                CreatedBy = commentModel.AppUser.UserName,
                StockId = commentModel.StockId,
            };
        }

        public static Comment ToCommentFromCreateDto(this CreateCommentRequestDto createCommentDto, int stockId)
        {
            return new Comment
            {
                Title = createCommentDto.Title,
                Content = createCommentDto.Content,
                StockId = stockId
            };
        }
    }
}
