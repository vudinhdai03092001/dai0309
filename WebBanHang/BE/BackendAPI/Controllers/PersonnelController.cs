using BackendAPI.Contracts;
using BackendAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PersonnelController : ControllerBase
    {
        private IRepositoryBase<PersonnelRequest> _repoWrapper;

        public PersonnelController(IRepositoryBase<PersonnelRequest> repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        [HttpPost]
        public IActionResult Post([FromBody] PersonnelRequest request)
        {
            request.Dob = DateTime.SpecifyKind(request.Dob, DateTimeKind.Utc);
            _repoWrapper.Create(request);
            _repoWrapper.Save();
            return Ok(request);

        }
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, PersonnelRequest request)
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
            var personnels = _repoWrapper.GetById(id);
            _repoWrapper.Delete(personnels);
            _repoWrapper.Save();
            return Ok();

        }
        [HttpGet("{page}")]
        public IActionResult Get(int page)
        {
            if (_repoWrapper.FindAll() == null)
                return NotFound();
            var pageResults = 5f;
            var personnels = _repoWrapper.GetDb().Personnel
            .Skip((page) * (int)pageResults)
            .Take((int)pageResults)
            .ToList();
            return Ok(personnels);
        }
    }
}
