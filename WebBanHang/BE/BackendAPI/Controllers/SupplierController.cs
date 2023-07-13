using BackendAPI.Contracts;
using BackendAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private IRepositoryBase<SupplierRequest> _repoWrapper;
        private string _path;
        public SupplierController(IRepositoryBase<SupplierRequest> repoWrapper, IConfiguration configuration)
        {
            _repoWrapper = repoWrapper;
            _path = configuration["AppSettings:PATH"];
        }
        [HttpGet]
        public IActionResult Get()
        {
            var blog = _repoWrapper.FindAll();
            return Ok(blog);
        }
        [HttpDelete("{id}")]
        public IActionResult Deleteblog(Guid id)
        {
            var blog = _repoWrapper.GetById(id);
            _repoWrapper.Delete(blog);
            _repoWrapper.Save();
            return Ok();
        }
        [HttpGet("Get/{id}")]
        public IActionResult GetId(Guid id)
        {
            var blog = _repoWrapper.GetById(id);
            return Ok(blog);
        }

        [HttpPut("{id}")]
        public IActionResult EditSupplier(Guid id, SupplierRequest request)
        {
            _repoWrapper.GetId(id);
            _repoWrapper.Update(request);
            _repoWrapper.Save();
            return Ok(request);
        }
        [HttpPost]
        public IActionResult Create(SupplierRequest request)
        {
            _repoWrapper.Create(request);
            _repoWrapper.Save();
            return Ok(request);
        }
        [HttpGet("{page}")]
        public IActionResult Get(int page)
        {
            if (_repoWrapper.FindAll() == null)
                return NotFound();
            var pageResults = 6f;
            var blog = _repoWrapper.GetDb().Suppliers
            .Skip((page) * (int)pageResults)
            .Take((int)pageResults)
            .ToList();
            return Ok(blog);
        }
    }
}

