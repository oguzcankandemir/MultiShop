using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _CargoDetailService;

        public CargoDetailController(ICargoDetailService CargoDetailService)
        {
            _CargoDetailService = CargoDetailService;
        }
        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _CargoDetailService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail CargoDetail = new CargoDetail()
            {
                CargoCompanyId = createCargoDetailDto.CargoCompanyId,
                Barcode = createCargoDetailDto.Barcode,
                RecieverCustomer = createCargoDetailDto.RecieverCustomer,
                SenderCustomer = createCargoDetailDto.SenderCustomer
            };
            _CargoDetailService.TInsert(CargoDetail);
            return Ok("Cargo Detail Added");
        }
        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _CargoDetailService.TDelete(id);
            return Ok("Cargo Detail Removed");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var values = _CargoDetailService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            //I can do AutoMapper
            CargoDetail CargoDetail = new CargoDetail()
            {
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
                Barcode = updateCargoDetailDto.Barcode,
                CargoDetailId = updateCargoDetailDto.CargoDetailId,
                RecieverCustomer = updateCargoDetailDto.RecieverCustomer,
                SenderCustomer = updateCargoDetailDto.SenderCustomer
            };
            _CargoDetailService.TUpdate(CargoDetail);
            return Ok("Cargo Detail Updated");
        }
    }
}
