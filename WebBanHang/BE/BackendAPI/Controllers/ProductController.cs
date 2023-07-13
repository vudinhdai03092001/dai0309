using BackendAPI.Contracts;
using BackendAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IRepositoryBase<ProductRequest> _repoWrapper;
        private string _path;
        public ProductController(IRepositoryBase<ProductRequest> repoWrapper, IConfiguration configuration)
        {
            _repoWrapper = repoWrapper;
            _path = configuration["AppSettings:PATH"];
        }
        [HttpGet]
        public IActionResult Get()
        {
            var product = _repoWrapper.FindAll();
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = _repoWrapper.GetById(id);
            _repoWrapper.Delete(product);
            _repoWrapper.Save();
            return Ok();
        }
        [HttpGet("Get/{id}")]
        public IActionResult GetId(Guid id)
        {
            var product = _repoWrapper.GetById(id);
            return Ok(product);
        }
        
        [HttpPut("{id}")]
        public IActionResult EditProduct(Guid id, ProductRequest request)
        {
           _repoWrapper.GetId(id);              
            _repoWrapper.Update(request); 
            _repoWrapper.Save();
            return Ok(request);
        }
        [HttpPost]
        public IActionResult Create( ProductRequest request)
        {        
            _repoWrapper.Create(request);
            _repoWrapper.Save();
            return Ok(request);
        }
   
        [HttpGet("{page}")]
        public IActionResult Get(int page,[FromQuery]  SearchRequest request)
        {
            if (_repoWrapper.SearchProduct(request) == null)
                return NotFound();
            var pageResults = 5f;    
            var product = _repoWrapper.SearchProduct(request)
            .Skip((page) * (int)pageResults)
            .Take((int)pageResults)
            .ToList();
          
            return Ok(product);
        }
       
    }
}
