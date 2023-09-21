using Azure.Messaging;
using Microsoft.AspNetCore.Mvc;
using New.Entity.ViewModel;
using New.Models;
using New.Response;
using New.Services___Repository;

namespace New.Controllers
{
    [Route("api/v1/blog")]
    [ApiController]

    public class BlogController : ControllerBase
    {
        private readonly BlogService _service;

        public BlogController(BlogService service)
        {
            _service = service;
        }
        

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var All_blog = await _service.GetAllAsync();
            return Ok(new HttpResponse<IEnumerable<Blog>>(StatusCodes.Status200OK, "Success", All_blog));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Findedblog = await _service.GetByIdAsync(id);
            return Ok(new HttpResponse<Blog>(StatusCodes.Status200OK, "Success", Findedblog));
        }


        [HttpPost]

        public async Task<IActionResult> Post([FromBody] BlogModel blogModel)
        {
            await _service.CreateAsync(blogModel);
            return Ok(new HttpResponse<BlogModel>(StatusCodes.Status200OK, "Success", blogModel));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Blog blog)
        {
            await _service.UpdateAsync(blog);
            return Ok(new HttpResponse<Blog>(StatusCodes.Status200OK, "Success", blog));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(new HttpResponse<Blog>(StatusCodes.Status200OK, "Success",null));

        }

    }
}




