

using BackendAPI.Contracts;
using BackendAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private IRepositoryBase<KhachHangRequest> _repoWrapper;

        public CustomerController(IRepositoryBase<KhachHangRequest> repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customer = _repoWrapper.FindAll();
            return Ok(customer);
        }
        [HttpPost]
        public IActionResult Post([FromBody] KhachHangRequest request)
        {
            request.Dob = DateTime.SpecifyKind(request.Dob, DateTimeKind.Utc);
            _repoWrapper.Create(request);
            _repoWrapper.Save();
            return Ok(request);

        }
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, KhachHangRequest request)
        {
            request.Dob = DateTime.SpecifyKind(request.Dob, DateTimeKind.Utc);
            _repoWrapper.GetId(id);
            _repoWrapper.Update(request);
            _repoWrapper.Save();
            return Ok(request);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var customer = _repoWrapper.GetById(id);
            _repoWrapper.Delete(customer);
            _repoWrapper.Save();
            return Ok();

        }
        [HttpGet("{page}")]
        public IActionResult Get(int page)
        {
            if (_repoWrapper.FindAll() == null)
                return NotFound();
            var pageResults = 5f;
            var customer = _repoWrapper.GetDb().KhachHang
            .Skip((page) * (int)pageResults)
            .Take((int)pageResults)
            .ToList();
            return Ok(customer);
        }
    }
}
