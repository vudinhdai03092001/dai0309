
using BackendAPI.Contracts;
using BackendAPI.Entities;
using BackendAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatHangController: ControllerBase 
    {
        private IRepositoryBase<Donhang> _repoWrapper;
        
        public DatHangController(IRepositoryBase<Donhang> repoWrapper)
        {
            _repoWrapper = repoWrapper;
           
        }

        [HttpPost("TaoHoaDon")]
        public IActionResult TaoHoaDon([FromBody] DonhangRequest request)
        {
            int tongtien = 0;

            Donhang dh = new Donhang()
            {
                Id = Guid.NewGuid(),
                NameCustomer = request.Donhang.NameCustomer,
                NumberPhone = request.Donhang.NumberPhone,
                Address = request.Donhang.Address,
                Note = request.Donhang.Note,              
                Total = 0,
                Status = 1,
            };
            _repoWrapper.Create(dh);
            _repoWrapper.Save();
            foreach (var ctddh in request.DonDatHang)
            {

                Guid idDonhang = dh.Id;
                DonDatHang ddh = new DonDatHang()
                {
                    IdDonhang = idDonhang,
                    IdProduct = ctddh.IdProduct,
                    Quantity = ctddh.Quantity,
                    Price = ctddh.Price,
                    Total = ctddh.Price * ctddh.Total

                };
                _repoWrapper.CreateDH(ddh);
                tongtien += ddh.Total;
            }
            dh.Total = tongtien;
            _repoWrapper.Save();
            return Ok();

        }
        [HttpGet("GetAllDonHang/{page}")]
        public IActionResult GetAllDonHang(int page,[FromQuery] SearchRequest request)
        {
           
            var DonHang = _repoWrapper.LayDonHang(request);
            var pageResults = 5f;
            var HoaDon = DonHang
            .Skip((page) * (int)pageResults)
            .Take((int)pageResults)
            .Select(x => new DonhangResponse()
            {
                Id = x.Donhang.Id,
                
                NameCustomer = x.Donhang.NameCustomer,
                NumberPhone = x.Donhang.NumberPhone,
                Address = x.Donhang.Address,
                NameProduct = x.Product.NameProduct,
                Quantity = x.Quantity,
                Price = x.Price,
                Total = x.Price * x.Quantity,
                Status = x.Donhang.Status,
                Note = x.Donhang.Note,
            }) 
            ; 
            return Ok(HoaDon);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = _repoWrapper.GetById(id);
            _repoWrapper.Delete(product);
            _repoWrapper.Save();
            return Ok();
        }

        [HttpGet("GetAllDonHangXacNhan")]
        public IActionResult GetAllDonHangXacNhan([FromQuery] SearchRequest request)
        {
            var DonHang = _repoWrapper.LayDonHang(request);

            var HoaDon = DonHang.Select(x => new DonhangResponse()
            {
                Id = x.Donhang.Id,
                NameCustomer = x.Donhang.NameCustomer,
                NumberPhone = x.Donhang.NumberPhone,
                Address = x.Donhang.Address,
                NameProduct = x.Product.NameProduct,
                Quantity = x.Quantity,
                Price = x.Price,
                Total = x.Price * x.Quantity,
                Status = x.Donhang.Status,
                Note = x.Donhang.Note,
            }).Where(s => s.Status == 2);
            return Ok(HoaDon);
        }
        [HttpGet("GetAllDonHangDaHuy")]
        public IActionResult GetAllDonHangDaHuy([FromQuery] SearchRequest request)
        {
            var DonHang = _repoWrapper.LayDonHang(request);

            var HoaDon = DonHang.Select(x => new DonhangResponse()
            {
                Id = x.Donhang.Id,
                NameCustomer = x.Donhang.NameCustomer,
                NumberPhone = x.Donhang.NumberPhone,
                Address = x.Donhang.Address,
                NameProduct = x.Product.NameProduct,
                Quantity = x.Quantity,
                Price = x.Price,
                Total = x.Price * x.Quantity,
                Status = x.Donhang.Status,
                Note = x.Donhang.Note,
            }).Where(s => s.Status == 3);
            return Ok(HoaDon);
        }
        [HttpGet("GetAllDonHangDangGiao")]
        public IActionResult GetAllDonHangDangGiao([FromQuery] SearchRequest request)
        {
            var DonHang = _repoWrapper.LayDonHang(request);

            var HoaDon = DonHang.Select(x => new DonhangResponse()
            {
                Id = x.Donhang.Id,
                NameCustomer = x.Donhang.NameCustomer,
                NumberPhone = x.Donhang.NumberPhone,
                Address = x.Donhang.Address,
                NameProduct = x.Product.NameProduct,
                Quantity = x.Quantity,
                Price = x.Price,
                Total = x.Price * x.Quantity,
                Status = x.Donhang.Status,
                Note = x.Donhang.Note,
            }).Where(s => s.Status == 4);
            return Ok(HoaDon);
        }

        [HttpGet("GetAllDonHangChuaXacNhan")]
        public IActionResult GetAllDonHangChuaXacNhan([FromQuery] SearchRequest request)
        {
            var DonHang = _repoWrapper.LayDonHang(request);

            var HoaDon = DonHang.Select(x => new DonhangResponse()
            {
                Id = x.Donhang.Id,
                NameCustomer = x.Donhang.NameCustomer,
                NumberPhone = x.Donhang.NumberPhone,
                Address = x.Donhang.Address,
                NameProduct = x.Product.NameProduct,
                Quantity = x.Quantity,
                Price = x.Price,
                Total = x.Price * x.Quantity,
                Status = x.Donhang.Status,
                Note = x.Donhang.Note,
            }).Where(s => s.Status == 1);
            return Ok(HoaDon);
        }
        [HttpGet("GetAllDonHangDaGiao")]
        public IActionResult GetAllDonHangDaGiao([FromQuery] SearchRequest request)
        {
            var DonHang = _repoWrapper.LayDonHang(request);

            var HoaDon = DonHang.Select(x => new DonhangResponse()
            {
                Id = x.Donhang.Id,
                NameCustomer = x.Donhang.NameCustomer,
                NumberPhone = x.Donhang.NumberPhone,
                Address = x.Donhang.Address,
                NameProduct = x.Product.NameProduct,
                Quantity = x.Quantity,
                Price = x.Price,
                Total = x.Price * x.Quantity,
                Status = x.Donhang.Status,
                Note = x.Donhang.Note,
            }).Where(s => s.Status == 5);
            return Ok(HoaDon);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateDonHang(Guid id, Donhang dh)
        {
            var _dh = _repoWrapper.GetById(id);
            _dh.NameCustomer = dh.NameCustomer;
            _dh.Address = dh.Address;
            _dh.NumberPhone = dh.NumberPhone;
            _dh.Note = dh.Note;
            _dh.Status = dh.Status;
            _repoWrapper.Update(_dh);
            _repoWrapper.Save();
            return Ok();
        }
       
    }
}
