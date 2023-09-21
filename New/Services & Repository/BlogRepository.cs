using Microsoft.EntityFrameworkCore;
using New.Data;
using New.Models;

namespace New.Services___Repository
{
    public class BlogRepository : DbContext
    {
        private readonly BlogDbContext _context;

        public BlogRepository (BlogDbContext context)
        {
            _context = context;
        }
         public async Task<IEnumerable<Blog>> GetAllBlogAsync()
         {
         return await _context.Blogs.Include(p => p.Posts).ToListAsync();
         }

            public async Task<Blog> GetByIdAsync(int id)
            {
                return await _context.Blogs.Include(p => p.Posts).FirstOrDefaultAsync(p => p.BlogId == id);
            }


        public async Task CreateAsync(Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
        }



        public async Task Update(Blog update)
        {
            _context.Blogs.Update(update);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
            {
                var _delete = await _context.Blogs.Include(p=>p.Posts).Where(_=>_.BlogId==id).FirstOrDefaultAsync();
                _context.Blogs.Remove(_delete);
                await _context.SaveChangesAsync();
            }
        }
    }
