using Microsoft.AspNetCore.Mvc;
using New.Entity.ViewModel;
using New.Models;

namespace New.Services___Repository
{
    public class BlogService 
    {
        private readonly BlogRepository _repository;
        public BlogService(BlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return await _repository.GetAllBlogAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
           return await _repository.GetByIdAsync(id);
        
        }   
        public async Task CreateAsync([FromBody]BlogModel blogModel)
        {
            var newBlog = new Blog
            {
                BlogName = blogModel.BlogName,
            };
            var post = blogModel.Posts.Select(s => new Post { PostName = s.PostName, BlogId = s.BlogId }).ToList();
            newBlog.Posts = post;
            await _repository.CreateAsync(newBlog);
        }
        
        public async Task UpdateAsync(Blog blog)
        {
            await _repository.Update(blog);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
