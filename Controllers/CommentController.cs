using dotnet_web_api.Interfaces;
using dotnet_web_api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_web_api.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;

        public CommentController(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepo.GetAllAsync();

            var commentsDto = comments.Select(c => c.ToCommentDto());

            return Ok(commentsDto);
        }
    }
}
