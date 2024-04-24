using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _CargoOperationService;

        public CargoOperationController(ICargoOperationService CargoOperationService)
        {
            _CargoOperationService = CargoOperationService;
        }
        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _CargoOperationService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation CargoOperation = new CargoOperation()
            {
                Barcode = createCargoOperationDto.Barcode,
                CargoOperationId = createCargoOperationDto.CargoOperationId,
                OperationDate = createCargoOperationDto.OperationDate
            };
            _CargoOperationService.TInsert(CargoOperation);
            return Ok("Cargo Operation Added");
        }
        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _CargoOperationService.TDelete(id);
            return Ok("Cargo Operation Removed");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var values = _CargoOperationService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            //I can do AutoMapper
            CargoOperation CargoOperation = new CargoOperation()
            {
                Barcode = updateCargoOperationDto.Barcode,
                CargoOperationId = updateCargoOperationDto.CargoOperationId,
                Description = updateCargoOperationDto.Description,
                OperationDate = updateCargoOperationDto.OperationDate
            };
            _CargoOperationService.TUpdate(CargoOperation);
            return Ok("Cargo Operation Updated");
        }
    }
}
