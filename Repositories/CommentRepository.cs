using System.Windows.Input;
using dotnet_web_api.Data;
using dotnet_web_api.Interfaces;
using dotnet_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_web_api.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;

        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            return comment;
        }
    }
}
