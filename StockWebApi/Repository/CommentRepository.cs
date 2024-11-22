using Microsoft.EntityFrameworkCore;
using StockWebApi.Data;
using StockWebApi.Dtos.Comment;
using StockWebApi.Helpers;
using StockWebApi.Interfaces;
using StockWebApi.Models;

namespace StockWebApi.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context=context;
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
          var commentModel = await _context.Comments.FindAsync(id);
            if (commentModel == null)
            {
                return null;
            
            }
            _context.Comments.Remove(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;



        }

        public async Task<List<Comment>> GetAllAsync(CommentQueryObject queryObject)
        {
            var comments =  _context.Comments.Include(a => a.AppUser).AsQueryable();
            if(!string.IsNullOrWhiteSpace(queryObject.symbol))
            {
                comments= comments.Where(s=>s.Stock.Symbol== queryObject.symbol);
            };
            if(queryObject.IsDescending==true)
            {
                comments = comments.OrderByDescending(c => c.CreatedOn);
            }

            return await comments.ToListAsync();
             
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.Include(a => a.AppUser).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comment> UpdateAsync(int id, UpdateCommentRequestDto commentDto)
        {

     
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return null;
            }

            comment.Title= commentDto.Title;
            comment.Content= commentDto.Content;
            await _context.SaveChangesAsync();

            return comment;


        }
    }
}
