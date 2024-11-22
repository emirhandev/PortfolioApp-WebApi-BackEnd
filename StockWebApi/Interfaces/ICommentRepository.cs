using StockWebApi.Dtos.Comment;
using StockWebApi.Helpers;
using StockWebApi.Models;

namespace StockWebApi.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync(CommentQueryObject queryObject);
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment commentModel);
        Task<Comment?> UpdateAsync(int id,UpdateCommentRequestDto commentDto);
        Task<Comment?> DeleteAsync(int id);

    }
}
