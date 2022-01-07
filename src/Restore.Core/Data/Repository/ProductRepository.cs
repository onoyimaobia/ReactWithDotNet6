using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restore.Core.Models;

namespace Restore.Core.Data.Repository
{
    public class ProductRepository: IProductRepository
    {
         private readonly RestoreContext _db;
        public ProductRepository(RestoreContext db)
        {
            _db = db;
        }

        public async Task<bool> AddPost(Product post)
        {
            await _db.Products.AddAsync(post);
            return await _db.SaveChangesAsync() >= 1;
        }

        public async Task<bool> DeletePost(long postId)
        {
            var post = await GetPostById(postId);
            _db.Products.Remove(post);
            return await _db.SaveChangesAsync() >= 1;
        }

        public async Task<Product> GetPostById(long postId)
        {
            return  await _db.Products.Where(s => s.ProductId == postId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetPostsAsync()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<bool> UpdatePost(Product post)
        {
             _db.Products.Update(post);
            return await _db.SaveChangesAsync() >= 1;
        }
    }
}