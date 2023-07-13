using BackendAPI.Contracts;
using BackendAPI.Entities;
using BackendAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HoadonbanController : ControllerBase
    {
        private IRepositoryBase<HoadonbanRequest> _repoWrapper;

        public HoadonbanController(IRepositoryBase<HoadonbanRequest> repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] SearchRequest request)
        {
            var hdb = _repoWrapper.SearchHDB(request);
            var Hoadonban = hdb.Select(x => new HoadonbanResponse()
            {
                Id = x.Id,
                BuyDate = x.BuyDate,
                Quantity = x.Quantity,
                TotalPrice = x.TotalPrice,
                IdCustomer = x.IdCustomer,
                NameCustomer = x.KhachHang.NameCustomer,
                NameProduct = x.Products.NameProduct,
                IdProduct = x.IdProduct,
            });
            return Ok(Hoadonban);
        }
        [HttpPost]
        public IActionResult Post(Hoadonban request)
        {
            //request.BuyDate = DateTime.SpecifyKind(request.BuyDate, DateTimeKind.Utc);
            var hdb = new HoadonbanRequest
            {
                IdCustomer = request.IdCustomer,
                IdProduct = request.IdProduct,
                BuyDate = request.BuyDate = DateTime.SpecifyKind(request.BuyDate, DateTimeKind.Utc),
                Quantity = request.Quantity,
                TotalPrice = request.TotalPrice,
            };
            _repoWrapper.Create(hdb);
            _repoWrapper.Save();
            return Ok(hdb);
        }
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Hoadonban request)
        {
            var hdb =_repoWrapper.GetById(id);
            hdb.IdCustomer = request.IdCustomer;
            hdb.IdProduct = request.IdProduct;
            hdb.BuyDate = request.BuyDate = DateTime.SpecifyKind(request.BuyDate, DateTimeKind.Utc);
            hdb.Quantity = request.Quantity;
            hdb.TotalPrice = request.TotalPrice;
            _repoWrapper.Update(hdb);
            _repoWrapper.Save();
            return Ok(hdb);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var Hdb = _repoWrapper.GetById(id);
            _repoWrapper.Delete(Hdb);
            _repoWrapper.Save();
            return Ok();
        }
        [HttpGet("{page}")]
        public IActionResult Get(int page, [FromQuery] SearchRequest request)
        {
            if (_repoWrapper.SearchHDB(request) == null)
                return NotFound();
            var PageResults = 5f;
            var hdb = _repoWrapper.SearchHDB(request)
                .Skip((page) * (int)PageResults)
                .Take((int)PageResults)
                .ToList();
            var Hoadonban = hdb.Select(x => new HoadonbanResponse()
            {
                Id = x.Id,
                BuyDate = x.BuyDate,
                Quantity = x.Quantity,
                TotalPrice = x.TotalPrice,
                IdCustomer = x.IdCustomer,
                NameCustomer = x.KhachHang.NameCustomer,
                NameProduct = x.Products.NameProduct,
                IdProduct = x.IdProduct,
            });
            return Ok(Hoadonban);
        }
    }
}
