using BackendAPI.Contracts;
using BackendAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class HoadonnhapController : ControllerBase
    {
        private IRepositoryBase<HoadonnhapRequest> _repoWrapper;

        public HoadonnhapController(IRepositoryBase<HoadonnhapRequest> repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
       
        [HttpPost]
        public IActionResult Post([FromBody] HoadonnhapRequest request)
        {
            request.BuyDate = DateTime.SpecifyKind(request.BuyDate, DateTimeKind.Utc);
            _repoWrapper.Create(request);
            _repoWrapper.Save();
            return Ok(request);

        }
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, HoadonnhapRequest request)
        {
            request.BuyDate = DateTime.SpecifyKind(request.BuyDate, DateTimeKind.Utc);
            _repoWrapper.GetId(id);
            _repoWrapper.Update(request);
            _repoWrapper.Save();
            return Ok(request);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var hoadonnhaps = _repoWrapper.GetById(id);
            _repoWrapper.Delete(hoadonnhaps);
            _repoWrapper.Save();
            return Ok();

        }
        [HttpGet("{page}")]
        public IActionResult Get(int page)
        {
            if (_repoWrapper.FindAll() == null)
                return NotFound();
            var pageResults = 5f;
            var hoadonnhaps = _repoWrapper.GetDb().Hoadonnhaps
            .Skip((page) * (int)pageResults)
            .Take((int)pageResults)
            .ToList();
            return Ok(hoadonnhaps);
        }
    }
}
