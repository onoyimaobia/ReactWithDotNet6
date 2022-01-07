using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restore.Core.Models;

namespace Restore.Core.Data.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetPostsAsync();
         Task<Product> GetPostById(long postId);
         Task<bool> AddPost(Product post);
         Task<bool> DeletePost(long postId);
        Task<bool> UpdatePost(Product post);
    }
}