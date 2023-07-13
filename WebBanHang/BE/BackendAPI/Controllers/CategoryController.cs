using BackendAPI.Contracts;
using BackendAPI.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CategoryController : ControllerBase
    {
        private IRepositoryBase<CategoryRequest> _repoWrapper;
       
        public CategoryController(IRepositoryBase<CategoryRequest> repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }        

        [HttpGet]
        public IActionResult Get()
        {
            var category = _repoWrapper.FindAll();
            return Ok(category);
        }
        [HttpGet("Get/{id}")]
        public IActionResult GetById(Guid id)
        {
            var category = _repoWrapper.GetById(id);
            return Ok(category);
        }
        [HttpGet("{page}")]
        public IActionResult GetPage(int page,[FromQuery]  SearchRequest request)
        {
            if (_repoWrapper.SearchCategory(request) == null)
                return NotFound();
            var PageSize = 5f;
            var category = _repoWrapper.SearchCategory(request)
            .Skip((page) * (int)PageSize)
            .Take((int)PageSize)
            .ToList();
            return Ok(category);
        }
        [HttpGet("Getallproducts/{id}")]
        public IActionResult GetpById(Guid id)
        {
            var category = _repoWrapper.GetProductById(id);
            _repoWrapper.Save();
            return Ok(category);
        }    
   
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryRequest request)
        {
            _repoWrapper.Create(request);
            _repoWrapper.Save();
            return Ok(request);

        }
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(Guid id, [FromBody] CategoryRequest request)
        {
            _repoWrapper.GetId(id);
            _repoWrapper.Update(request);
            _repoWrapper.Save();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(Guid id)
        {
            var category = _repoWrapper.GetById(id);
            _repoWrapper.Delete(category);
            _repoWrapper.Save();
            return NoContent();
        }
    }
}
